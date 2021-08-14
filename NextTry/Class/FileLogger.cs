using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.IO;

namespace NextTry.Class
{
    /*
     
     раскраска для консоли:

     logger.LogCritical("LogCritical {0}", context.Request.Path);
     logger.LogDebug("LogDebug {0}", context.Request.Path);
     logger.LogError("LogError {0}", context.Request.Path);
     logger.LogInformation("LogInformation {0}", context.Request.Path);
     logger.LogWarning("LogWarning {0}", context.Request.Path);

     в конструктор передать = ILoggerFactory loggerFactory

     в метод = loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "log.txt"));
               var logger = loggerFactory.CreateLogger("FileLogger");
    */

    public class FileLogger : ILogger
    {
        private string filePath;
        private static object _lock = new object();
        public FileLogger(string path)
        {
            filePath = path;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            //return logLevel == LogLevel.Trace;
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                lock (_lock)
                {
                    File.AppendAllText(filePath, formatter(state, exception) + Environment.NewLine);
                }
            }
        }
    }
}
