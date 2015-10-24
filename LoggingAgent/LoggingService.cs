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
        private DbLogChannel dbLogChannel = new DbLogChannel();

        public Task AddLog(LogEntry entry)
        {
            Task dbLogWriteTask = new TaskFactory().StartNew(() =>  dbLogChannel.Log(entry));
            return dbLogWriteTask;
        }
    }
}
