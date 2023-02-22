using System;

namespace UCL.Assets.Scripts.Components.Logging
{
    public enum LogLevel
    {
        Trace = 0,
        Debug = 1,
        Information = 2,
        Warning = 3,
        Error = 4,
        Critical = 5,
        None = 6,
        Exception = 255
    }

    public interface ILogger
    {
        public void Log(LogLevel level, string category, string message);
        public void LogException(Exception exception, string category = null, string message = null);
    }
}