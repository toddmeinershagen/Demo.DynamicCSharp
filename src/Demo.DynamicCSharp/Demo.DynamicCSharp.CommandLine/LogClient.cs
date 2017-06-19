using System;

namespace Demo.DynamicCSharp.CommandLine
{
    public class LogClient : ILogClient
    {
        public void Error(string message, params object[] args)
        {
            var formattedMessage = string.Format(message, args);
            var dateString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"{dateString} ERROR:  {formattedMessage}");
        }
    }
}
