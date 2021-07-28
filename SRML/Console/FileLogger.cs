using System.Text.RegularExpressions;
using BepInEx.Logging;
using SRML.Utils;

namespace SRML
{
    /// <summary>
    /// The logger for the log file
    /// </summary>
    public static class FileLogger
    {
        /// <summary>
        /// Logs a info message
        /// </summary>
        /// <param name="message">Message to log</param>
        public static void Log(string message)
        {
            LogEntry(LogLevel.Info, message);
        }

        /// <summary>
        /// Logs a warning message
        /// </summary>
        /// <param name="message">Message to log</param>
        public static void LogWarning(string message)
        {
            LogEntry(LogLevel.Warning, message);
        }

        /// <summary>
        /// Logs an error message
        /// </summary>
        /// <param name="message">Message to log</param>
        public static void LogError(string message)
        {
            LogEntry(LogLevel.Error, message);
        }

        internal static void LogEntry(LogLevel logType, string message)
        {
            message = $"{Regex.Replace(message, @"<material[^>]*>|<\/material>|<size[^>]*>|<\/size>|<quad[^>]*>|<b>|<\/b>|<color=[^>]*>|<\/color>|<i>|<\/i>", "")}";

            LogUtils.BepInExLog.Log(logType, message);
        }
    }
}
