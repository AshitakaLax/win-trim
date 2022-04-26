using System.Threading.Tasks;
using Xabe.FFmpeg;

namespace video_trimmer.Processing
{
    public interface IVideoProcessor
    {
        Task TrimVideo(string inputFile, string outputFile, TimeSpan start, TimeSpan end);
    }
}