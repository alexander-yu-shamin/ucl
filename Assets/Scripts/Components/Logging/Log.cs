using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UCL.Assets.Scripts.Components.Logging;

public static class Log
{
    public static void LogTrace(string category, string message)
    {
        LogInternal(LogLevel.Trace, category, message);
    }

    public static void LogDebug(string category, string message)
    {
        LogInternal(LogLevel.Debug, category, message);
    }

    public static void LogInfo(string category, string message)
    {
        LogInternal(LogLevel.Information, category, message);
    }

    public static void LogWarning(string category, string message)
    {
        LogInternal(LogLevel.Warning, category, message);
    }

    public static void LogError(string category, string message)
    {
        LogInternal(LogLevel.Error, category, message);
    }

    public static void LogCritical(string category, string message)
    {
        LogInternal(LogLevel.Critical, category, message);
    }

    public static void LogException(Exception exception, string category = null, string message = null)
    {

    }

    private static void LogInternal(LogLevel level, string category, string message)
    {

    }
}
