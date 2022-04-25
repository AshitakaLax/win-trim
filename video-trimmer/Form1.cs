using LibVLCSharp.Shared;
using Xabe.FFmpeg;

namespace video_trimmer
{
    public partial class VideoTrimmerForm : Form
    {
        private string SelectedFile;
        private string SelectedDirectory;
        // VLC Player 1
        public LibVLC LibVLCOne;
        public MediaPlayer mediaPlayerOne;
        public Media mediaOne;
        // VLC Player 2
        public MediaPlayer mediaPlayerTwo;
        public Media mediaTwo;

        public VideoTrimmerForm()
        {
            InitializeComponent();
            Core.Initialize();
            //this.KeyPreview = true;
            // VLC Player 1
            LibVLCOne = new LibVLC();
            mediaPlayerOne = new MediaPlayer(LibVLCOne);
            videoView1.MediaPlayer = mediaPlayerOne;

            // VLC Player 2
            mediaPlayerTwo = new MediaPlayer(LibVLCOne);
            videoView2.MediaPlayer = mediaPlayerTwo;
        }
        private void LoadFiles()
        {
            this.DirectoryLabel.Text = $"Select Directory\n{SelectedDirectory}";
            string[] files = Directory.GetFiles(SelectedDirectory, "*.mp4");
            string[] filesOnly = files.Select(file => Path.GetFileName(file)).ToArray();
            FileListBox.Items.AddRange(filesOnly);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void QueueJobButton_Click(object sender, EventArgs e)
        {
            // Fetch the start time and end time
            long trimStartSeconds = mediaPlayerOne.Time;
            long trimEndSeconds = mediaPlayerTwo.Time;
            TimeSpan endTime = TimeSpan.FromMilliseconds(trimEndSeconds);

            // close out the media players
            // start a new thread to create the new video file
            await TrimVideo(TimeSpan.FromMilliseconds(trimStartSeconds), endTime);
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

        private void SelectDirectoryButton_Click(object sender, EventArgs e)
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

        private void FileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedFile = (string)FileListBox.SelectedItem;
            string videoURL = Path.Combine(SelectedDirectory, SelectedFile);
            mediaPlayerOne.Media = new Media(LibVLCOne, videoURL);
            mediaPlayerTwo.Media = new Media(LibVLCOne, videoURL);
           
            StatsLabel.Text = $"STATS: {SelectedFile} \nDuration:{mediaPlayerOne.Media.Duration}";
            mediaPlayerOne.SeekTo(TimeSpan.FromSeconds(60));            
        }
    }
}