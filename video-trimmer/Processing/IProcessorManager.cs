using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace video_trimmer.Processing
{
    public interface IProcessorManager
    {
        void AddProcessor(IVideoProcessor processor);
        ConcurrentQueue<IVideoProcessor> ProcessorQueue { get; }

        Action<(int jobs, double progress)> UpdateHandler { get; set; }

        int MaxConcurrentThreads { get; set; }
    }
}
