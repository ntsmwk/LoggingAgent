using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingAgent
{
    class LoggingAgent : ILoggingService
    {
        public Task AddLog(LogEntry entry)
        {
            Task dbLogWriteTask = new Task(() => DbLogChannel.Log(entry));
            dbLogWriteTask.Start();
            return dbLogWriteTask;
        }
    }
}
