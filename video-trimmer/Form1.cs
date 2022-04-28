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
            await mediaPlayerTwo.Media.Parse();
            StatsLabel.Text = $"STATS: {SelectedFile} \nDuration:{TimeSpan.FromMilliseconds(mediaPlayerOne.Media.Duration)}";
            mediaPlayerOne.SeekTo(TimeSpan.FromSeconds(60));
            mediaPlayerOne.Volume = 0;
            mediaPlayerOne.PositionChanged += MediaPlayer_PositionChanged;
            mediaPlayerOne.Play();
            // update media Player two
            TimeSpan duration = TimeSpan.FromMilliseconds(mediaPlayerOne.Media.Duration);
            mediaPlayerTwo.SeekTo(duration.Subtract(TimeSpan.FromSeconds(60)));
            mediaPlayerTwo.Volume = 0;
            mediaPlayerTwo.PositionChanged += MediaPlayerTwo_PositionChanged;
            mediaPlayerTwo.Play();
        }

        private void MediaPlayerTwo_PositionChanged(object? sender, MediaPlayerPositionChangedEventArgs e)
        {
            mediaPlayerTwo.Pause();
        }

        private void MediaPlayer_PositionChanged(object? sender, MediaPlayerPositionChangedEventArgs e)
        {
            mediaPlayerOne.Pause();
        }

        private void MediaPlayerOne_Playing(object? sender, EventArgs e)
        {
            //mediaPlayerOne.NextFrame();
            //mediaPlayerOne.Pause();
            //mediaPlayerOne.NextFrame();

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            //Todo update the current position within the first 5 minutes of the 
            TimeSpan target = TimeSpan.FromSeconds(trackBar1.Value);
            mediaPlayerOne.SeekTo(target);
            StartTrimLabel.Text = $"Start Trim: {target.ToString(@"hh\:mm\:ss")}";
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan target = TimeSpan.FromMilliseconds(mediaPlayerTwo.Media.Duration + (trackBar2.Value * 1000));
            // TrackBar2 value is between 0(the end), and -600(10 minutes from the end).
            mediaPlayerTwo.SeekTo(target);
            EndTrimLabel.Text = $"End Trim: {target.ToString(@"hh\:mm\:ss")}";    
        }
    }
}