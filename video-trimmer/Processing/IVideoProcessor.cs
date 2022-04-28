using System.Threading.Tasks;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Events;

namespace video_trimmer.Processing
{
    public interface IVideoProcessor
    {
        IConversion Conversion { get; set; }
        IConversionResult Result { get; set; }
        bool IsProcessing { get; set; }
        Task CreateVideo(string inputFile, string outputFile, TimeSpan start, TimeSpan end);
        Task Start(ConversionProgressEventHandler onProgressEventHandler, Action<IVideoProcessor, IConversionResult> onCompleteHandler);
    }
}