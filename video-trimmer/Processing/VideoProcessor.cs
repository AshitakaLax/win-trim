using System.Threading.Tasks;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Events;

namespace video_trimmer.Processing
{
    public class VideoProcessor : IVideoProcessor
    {

        public IConversion Conversion { get; set; }

        public IConversionResult Result { get; set; }
        public bool IsProcessing { get; set; } = false;

        public bool OverwriteOriginal { get; set; }

        public string InputFile { get; private set; }
        public string OutputFile { get; private set; }
        public int ThreadId { get; private set; } = -1;
        public async Task ConversionSetup(string inputFile, string outputFile, TimeSpan start, TimeSpan end, bool overwrite)
        {
            OverwriteOriginal = overwrite;
            InputFile = inputFile;
            OutputFile = outputFile;
            string endString = end.ToString(@"hh\:mm\:ss");
            var inputInfo = await FFmpeg.GetMediaInfo(inputFile);
            Conversion = FFmpeg.Conversions.New()
                .AddStream(inputInfo.Streams)
                .SetSeek(start)
                .AddParameter($"-to {endString}")
                .SetOutput(outputFile);  
        }

        public async Task Start(ConversionProgressEventHandler onProgressEventHandler, Action<IVideoProcessor, IConversionResult> onCompleteHandler)
        {
            if(Conversion == null)
            {
                throw new InvalidOperationException("Create Video must be called before.");
            }

            Conversion.OnProgress += onProgressEventHandler;
            await Task.Run(async () =>
            {
                IsProcessing = true;
                Result = await Conversion.Start();
            }).ContinueWith((obj)=> {
                IsProcessing = false;
                onProgressEventHandler.Invoke(this, new ConversionProgressEventArgs(TimeSpan.Zero, TimeSpan.MaxValue, 0));
                onCompleteHandler(this, Result);
                ReplaceOriginal();
            });
        }

        private void ReplaceOriginal()
        {
            if (OverwriteOriginal)
            {
                try
                {
                    File.Move(OutputFile, InputFile, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to move file {OutputFile} to {InputFile}. {ex.Message}");
                }
            }
        }
    }
}