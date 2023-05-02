using System.Diagnostics;

namespace EventLogger.Models;

public static class EventLogger
{
    private const string Source = "MyApp";
    private const string Log = "Application";

    public static void LogError(string message) => LogEvent(EventLogEntryType.Error, message);

    public static void LogWarning(string message) => LogEvent(EventLogEntryType.Warning, message);

    public static void LogInformation(string message) => LogEvent(EventLogEntryType.Information, message);

    private static void LogEvent(EventLogEntryType type, string message)
    {
        if (!EventLog.SourceExists(Source))
        {
            EventLog.CreateEventSource(Source, Log);
        }

        EventLog.WriteEntry(Source, message, type);
    }
}