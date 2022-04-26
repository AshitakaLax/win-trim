using System.Threading.Tasks;
using Xabe.FFmpeg;

namespace video_trimmer.Processing
{
    public class VideoProcessor : IVideoProcessor
    {
        public VideoProcessor()
        {

        }
        //TODO create a new model that contains both the Conversion, as well as the needed information in order to report progress
        // of all the conversions combined.
        List<IConversion> Conversions { get; set; } = new List<IConversion>();
        
        public async Task TrimVideo(string inputFile, string outputFile, TimeSpan start, TimeSpan end)
        {
            string endString = end.ToString(@"hh\:mm\:ss");
            var inputInfo = await FFmpeg.GetMediaInfo(inputFile);
            IConversion conversion = FFmpeg.Conversions.New()
                .AddStream(inputInfo.Streams)
                .SetSeek(start)
                .AddParameter($"-to {endString}")
                .SetOutput(outputFile);
            conversion.OnProgress += (sender, args) =>
             {
                 //Show all output from FFmpeg to console
                 System.Diagnostics.Debug.WriteLine($"[{args.Duration}/{args.TotalLength}][{args.Percent}%]");
             };
            Conversions.Add(conversion);

            // todo start this on a new thread.
            conversion.Start();

        }

    }
}