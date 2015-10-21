using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingAgent
{
     class StressTestAgent
    {
        static int Main(string[] args)
        {
            LogDBEntities1 _contextEntities = new LogDBEntities1();
            _contextEntities.Configuration.AutoDetectChangesEnabled = false;
            
            _contextEntities.LogEntry.Add(new LogEntry
                    {
                        Message = "message",
                        EventTime = new DateTime(),
                        LogSource = "Source1",
                        LogId = 2
    });
                int i = _contextEntities.SaveChanges();
                Console.WriteLine("Count " + _contextEntities.LogEntry.Count());

                /*
                for (int i = 2; i < 10; i++)
                {
                    LogEntry l = new LogEntry
                    {
                        Message = "message" + i,
                        EventTime = new DateTime(),
                        LogSource = "Source1",
                        LogId = i
                    };
                    new LoggingAgent().AddLog(l);
                }
                */
                Console.ReadKey();
            return 0;
        }
    }
}
