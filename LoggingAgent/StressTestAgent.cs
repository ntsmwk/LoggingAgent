using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LoggingAgent
{
    internal class StressTestAgent
    {
        private static int Main(string[] args)
        {
            LoggingService loggingService = new LoggingService();
            Parallel.For(0, 100, (i) =>
            {
                new TaskFactory().StartNew(async() =>
                {
                    for (int j = 0;;j++)
                    {
                        LogEntry l = new LogEntry
                        {
                            Message = "message " + ++j,
                            EventTime = DateTime.Now,
                            LogSource = "source " + i
                        };
                        await loggingService.AddLog(l);
                        await Task.Delay(new Random().Next(10, 500));
                    }
                });
            });
             
            Console.WriteLine("Finished!");
            Console.ReadKey();
            return 0;
        }
    }
}