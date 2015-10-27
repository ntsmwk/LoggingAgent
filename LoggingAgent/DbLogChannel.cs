using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace LoggingAgent
{
    internal class DbLogChannel
    {
        private LogEntriesDBEntities _contextEntities = new LogEntriesDBEntities();
        private ConcurrentQueue<LogEntry> logEntries = new ConcurrentQueue<LogEntry>();

        private static int MAX_LOG_ENTRIES = 100;

        public DbLogChannel()
        {
            new TaskFactory().StartNew(async () =>
            {
                for (;;)
                {
                    if (logEntries.Count >= MAX_LOG_ENTRIES)
                    {
                        lock (logEntries)
                        {
                            _contextEntities.LogEntry.AddRange(logEntries);
                            int i = _contextEntities.SaveChanges();
                            Console.WriteLine("Log Batch written!");
                            logEntries = new ConcurrentQueue<LogEntry>();
                        }

                    }
                    await Task.Delay(500);
                }
            });
        }
     

        public void Log(LogEntry logEntry)
        { 
            logEntries.Enqueue(logEntry);
        }
    }
}