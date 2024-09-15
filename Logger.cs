using System;
using System.IO;

namespace Unity_Game_StringToCSV
{
    public class Logger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
            LogToFile(message);
        }

        public void LogException(Exception ex)
        {
            string message = $"[{DateTime.Now}] Error: {ex.Message}\nStack Trace: {ex.StackTrace}\n";
            Console.WriteLine(message);
            LogToFile(message);
        }

        private void LogToFile(string message)
        {
            string logFilePath = "error.log";
            File.AppendAllText(logFilePath, message);
        }
    }
}