using System.Threading.Tasks;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Events;

namespace video_trimmer.Processing
{
    public interface IVideoProcessor
    {
        string InputFile { get; }
        string OutputFile { get; }

        IConversion Conversion { get; set; }
        IConversionResult Result { get; set; }
        bool IsProcessing { get; set; }
        Task ConversionSetup(string inputFile, string outputFile, TimeSpan start, TimeSpan end, bool overwriteInput);
        Task Start(ConversionProgressEventHandler onProgressEventHandler, Action<IVideoProcessor, IConversionResult> onCompleteHandler);
    }
}