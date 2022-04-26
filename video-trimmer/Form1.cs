using LibVLCSharp.Shared;
using video_trimmer.Processing;
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

        private readonly IVideoProcessor VideoProcessor = new VideoProcessor();

        public VideoTrimmerForm()
        {
            InitializeComponent();
            Core.Initialize();
            //this.KeyPreview = true;
            // VLC Player 1
            LibVLCOne = new LibVLC();
            mediaPlayerOne = new MediaPlayer(LibVLCOne);
            videoView.MediaPlayer = mediaPlayerOne;

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

        private async void QueueJobButton_Click(object sender, EventArgs e)
        {
            // Fetch the start time and end time
            long trimStartSeconds = mediaPlayerOne.Time;
            long trimEndSeconds = mediaPlayerTwo.Time;
            TimeSpan startTime = TimeSpan.FromMilliseconds(trimStartSeconds);
            TimeSpan endTime = TimeSpan.FromMilliseconds(trimEndSeconds);

            // input file
            string inputFile = Path.Combine(SelectedDirectory, SelectedFile);
            string outputFile = Path.Combine(SelectedDirectory, $"temp-{SelectedFile}");

            // close out the media players
            // start a new thread to create the new video file
            await VideoProcessor.TrimVideo(inputFile, outputFile, startTime, endTime);
            // replace the original file with the new video file.

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

        private async void FileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedFile = (string)FileListBox.SelectedItem;
            string videoURL = Path.Combine(SelectedDirectory, SelectedFile);
            mediaPlayerOne.Media = new Media(LibVLCOne, videoURL);
            mediaPlayerTwo.Media = new Media(LibVLCOne, videoURL);
           
            await mediaPlayerOne.Media.Parse();
            StatsLabel.Text = $"STATS: {SelectedFile} \nDuration:{TimeSpan.FromMilliseconds(mediaPlayerOne.Media.Duration)}";
            mediaPlayerOne.SeekTo(TimeSpan.FromSeconds(60));
            mediaPlayerOne.Playing += MediaPlayerOne_Playing;
            mediaPlayerOne.Volume = 0;
            mediaPlayerOne.PositionChanged += MediaPlayerOne_PositionChanged;
            mediaPlayerOne.Play();
        }

        private void MediaPlayerOne_PositionChanged(object? sender, MediaPlayerPositionChangedEventArgs e)
        {
            mediaPlayerOne.Pause();
        }

        private void MediaPlayerOne_Playing(object? sender, EventArgs e)
        {
            //mediaPlayerOne.NextFrame();
            //mediaPlayerOne.Pause();
            //mediaPlayerOne.NextFrame();

        }
    }
}