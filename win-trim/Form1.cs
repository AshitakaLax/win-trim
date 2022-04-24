using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;
using Xabe.FFmpeg;

namespace win_trim
{
    public partial class Form1 : Form
    {
        private string SelectedFile;
        private string SelectedDirectory;
        public Form1()
        {
            InitializeComponent();

            player.settings.autoStart = false;
            player2.settings.autoStart = false;
            player2.CurrentMediaItemAvailable += Player_CurrentMediaItemAvailable;
            if(!string.IsNullOrEmpty(Properties.Settings.Default.DefaultDirectory))
            {
                SelectedDirectory = Properties.Settings.Default.DefaultDirectory;
                LoadFiles();
            }
        }

        private void Player_CurrentMediaItemAvailable(object sender, AxWMPLib._WMPOCXEvents_CurrentMediaItemAvailableEvent e)
        {
            player2.Ctlcontrols.currentPosition = player2.currentMedia.duration - 60.00;

        }

        private void DirectoryButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                FileListBox.Items.Clear();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    SelectedDirectory = fbd.SelectedPath;
                    Properties.Settings.Default.DefaultDirectory = SelectedDirectory;
                    Properties.Settings.Default.Save();
                    LoadFiles();
                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }

        private void LoadFiles()
        {
            this.DirectoryLabel.Text = $"Select Directory\n{SelectedDirectory}";
            string[] files = Directory.GetFiles(SelectedDirectory, "*.mp4");
            string[] filesOnly = files.Select(file => Path.GetFileName(file)).ToArray();
            FileListBox.Items.AddRange(filesOnly);

        }

        private async void QueueButton_Click(object sender, EventArgs e)
        {
            // Fetch the start time and end time
            double trimStartSeconds = player.Ctlcontrols.currentPosition;
            double trimEndSeconds = player2.Ctlcontrols.currentPosition;
            TimeSpan endTime = TimeSpan.FromSeconds(trimEndSeconds);
            // close out the media players
            player.Ctlcontrols.stop();
            player2.Ctlcontrols.stop();

            // start a new thread to create the new video file
            await TrimVideo(TimeSpan.FromSeconds(trimStartSeconds), endTime); 
            // replace the original file with the new video file.
        }
        private async Task TrimVideo(TimeSpan start, TimeSpan end)
        {
            string endString = end.ToString(@"hh\:mm\:ss");
            var inputInfo = await FFmpeg.GetMediaInfo(Path.Combine(SelectedDirectory, SelectedFile));
            var temp = await FFmpeg.Conversions.New()
                .AddStream(inputInfo.Streams)
                .SetSeek(start)
                .AddParameter($"-to {endString}")
                .SetOutput(Path.Combine(SelectedDirectory, $"temp-{SelectedFile}"))
                .Start();

        }

        private void FileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedFile = (string)FileListBox.SelectedItem;
            player.URL = Path.Combine(SelectedDirectory, SelectedFile);
            player2.URL = Path.Combine(SelectedDirectory, SelectedFile);

            StatsLabel.Text = $"STATS: {SelectedFile} \nDuration:{player.currentMedia.duration}";
            player.Ctlcontrols.currentPosition = 60.00;
        }

        private void player_KeyPressEvent(object sender, AxWMPLib._WMPOCXEvents_KeyPressEvent e)
        {
            if (e.nKeyAscii == 0)
            {
                player.Ctlcontrols.currentPosition = player.Ctlcontrols.currentPosition + 10;
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
