using System;

namespace BoyScoutsCamp.Service
{
    public class LoggerService : ILoggerService
    {
        public void WriteLog(string message)
        {
            Console.WriteLine(message);
        }
    }
}
