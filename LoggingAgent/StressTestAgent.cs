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
            LoggingAgent logging = new LoggingAgent();
            Parallel.For(0, 100, (i) =>
            {
                new Task(() =>
                {
                    
                    int j = 0;
                    for (;;)
                    {
                        
                        LogEntry l = new LogEntry
                        {
                            Message = "message" + ++j,
                            EventTime = DateTime.Now,
                            LogSource = "Source" + i
                        };
                        logging.AddLog(l);
                        Thread.Sleep(new Random().Next(10,500));
                    }

                }).Start();

                Console.WriteLine("added Log Entry to queue" + i);
            });
             
            Console.WriteLine("Finished!");
            Console.ReadKey();
            return 0;
        }
    }
}