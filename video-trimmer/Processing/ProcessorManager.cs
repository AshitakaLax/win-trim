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
        private Action<(int jobs, double progress)> UpdateProgressHandler;
        private Dictionary<long, int> ProcessStatusDictionary = new Dictionary<long, int>();
        public List<IVideoProcessor> ProcessorList { get; set; } = new List<IVideoProcessor>();
        public Action<(int jobs, double progress)> UpdateHandler { get => UpdateProgressHandler; set => UpdateProgressHandler = value; }

        public void AddProcessor(IVideoProcessor processor)
        {
            ProcessorList.Add(processor);

            processor.Start(handleOnProgress, OnProcessorFinished);
        }

        private void handleOnProgress(Object sender, ConversionProgressEventArgs args)
        {
            ProcessStatusDictionary[args.ProcessId] = args.Percent;
            if(args.Percent > 99)
            {
                ProcessStatusDictionary.Remove(args.ProcessId);
                if(ProcessStatusDictionary.Count == 0)
                {
                    UpdateHandler?.Invoke((0, 100));
                }
            }
            //sum up all of the Processor status's and 
            if (ProcessStatusDictionary.Count > 0)
            {
                // TODO cross thread issue
                double progressTotal = ProcessStatusDictionary.Values.Sum() / ProcessStatusDictionary.Count;
                UpdateHandler?.Invoke((ProcessorList.Count, progressTotal));
            }
        }

        private void OnProcessorFinished(IVideoProcessor processor, IConversionResult results)
        {
            processor.Conversion.OnProgress -= handleOnProgress;
            ProcessorList?.Remove(processor);
        }
    }
}
