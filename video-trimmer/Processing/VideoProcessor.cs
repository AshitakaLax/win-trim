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
        public async Task CreateVideo(string inputFile, string outputFile, TimeSpan start, TimeSpan end)
        {
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
                IsProcessing = false;
                onCompleteHandler(this, Result);
            });
        }
    }
}