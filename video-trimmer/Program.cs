using Xabe.FFmpeg.Events;

namespace video_trimmer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConversionProgressEventArgs temp = new ConversionProgressEventArgs(TimeSpan.MinValue, TimeSpan.MaxValue, Thread.CurrentThread.ManagedThreadId);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new VideoTrimmerForm());
        }
    }
}