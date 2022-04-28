using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Events;

namespace video_trimmer.Processing
{
    public class ProcessorManager : IProcessorManager
    {
        public List<IVideoProcessor> ProcessorList { get; set; } = new List<IVideoProcessor>();
        public Action<(int jobs, double progress)> UpdateHandler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddProcessor(IVideoProcessor processor)
        {
            ProcessorList.Add(processor);

            processor.Start(handleOnProgress, OnProcessorFinished);
        }

        private void handleOnProgress(Object sender, ConversionProgressEventArgs args)
        {

        }

        private void OnProcessorFinished(IVideoProcessor processor, IConversionResult results)
        {

        }
    }
}
