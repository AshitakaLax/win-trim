using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
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
        private ConcurrentDictionary<long, int> ProcessStatusDictionary = new ConcurrentDictionary<long, int>();
        public ProcessorManager(int maxConcurrentThreads = 3)
        {
            MaxConcurrentThreads = maxConcurrentThreads;
        }

        public int MaxConcurrentThreads { get; set; }
        public ConcurrentQueue<IVideoProcessor> ProcessorQueue { get; private set; } = new ConcurrentQueue<IVideoProcessor>();
        public ConcurrentDictionary<string, IVideoProcessor> ProcessorDictionary { get; set; } = new ConcurrentDictionary<string, IVideoProcessor>();
        public Action<(int jobs, double progress)> UpdateHandler { get => UpdateProgressHandler; set => UpdateProgressHandler = value; }

        public void AddProcessor(IVideoProcessor processor)
        {
            if(ProcessorDictionary.ContainsKey(processor.InputFile))
            {
                MessageBox.Show($"File({processor.InputFile}) is already being processed");
                return;
            }
            ProcessorDictionary[processor.InputFile] = processor;

            if(ProcessorDictionary.Count >= MaxConcurrentThreads)
            {
                // queue up the new processor, and don't start it.
                ProcessorQueue.Enqueue(processor);
                return;
            }


            processor.Start(handleOnProgress, OnProcessorFinished);
        }

        private void handleOnProgress(Object sender, ConversionProgressEventArgs args)
        {
            if(args.ProcessId == 0)
            {
                CleanUpProcesses();
                if (ProcessStatusDictionary.Count == 0)
                {
                    UpdateHandler?.Invoke((0, 100));
                    return;
                }

                double progressTotal = ProcessStatusDictionary.Values.Sum() / ProcessStatusDictionary.Count;
                UpdateHandler?.Invoke((ProcessorDictionary.Count, progressTotal));
            }
            ProcessStatusDictionary[args.ProcessId] = args.Percent;
            
            //sum up all of the Processor status's and 
            if (ProcessStatusDictionary.Count > 0)
            {
                double progressTotal = ProcessStatusDictionary.Values.Sum() / ProcessStatusDictionary.Count;
                UpdateHandler?.Invoke((ProcessorDictionary.Count, progressTotal));
            }
        }
        private void CleanUpProcesses()
        {
            Process[] processlist = Process.GetProcesses();
            List<long> processIdList = processlist.Select(p => (long)p.Id).ToList();
            long[] existingProcesses = ProcessStatusDictionary.Keys.Intersect(processIdList).ToArray();

            List<KeyValuePair<long, int>> itemsToRemove = ProcessStatusDictionary.Where(element => !existingProcesses.Any(p => p == element.Key)).ToList();
            foreach (KeyValuePair<long, int> pair in itemsToRemove)
            {
                ProcessStatusDictionary.Remove(pair.Key, out _);
            }
        }

        private void OnProcessorFinished(IVideoProcessor processor, IConversionResult results)
        {
            ProcessorDictionary.Remove(processor.InputFile, out _);
            //if there are still processes in the queue start the next one.
            if(!ProcessorQueue.IsEmpty)
            {
                ProcessorQueue.TryDequeue(out IVideoProcessor nextProcessor);

                nextProcessor.Start(handleOnProgress, OnProcessorFinished);
            }
        }
    }
}
