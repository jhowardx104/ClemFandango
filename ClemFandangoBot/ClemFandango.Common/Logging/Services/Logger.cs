using ClemFandango.Common.Logging.Enums;
using ClemFandango.Common.Logging.Interfaces;
using ClemFandango.Common.Logging.Models;

namespace ClemFandango.Common.Logging.Services;

public abstract class Logger: ILogger
{
    public abstract void Log(LogEntry log);

    public void Critical(string message, Exception? exception = null, Dictionary<string, object>? extendedProperties = null)
    {
        Log(new LogEntry { Message = message, Level = LogLevel.Critical, Exception = exception, ExtendedProperties = extendedProperties });
    }

    public void Error(string message, Exception? exception = null, Dictionary<string, object>? extendedProperties = null)
    {
        Log(new LogEntry { Message = message, Level = LogLevel.Error, Exception = exception, ExtendedProperties = extendedProperties });
    }

    public void Warn(string message, Exception? exception = null, Dictionary<string, object>? extendedProperties = null)
    {
        Log(new LogEntry { Message = message, Level = LogLevel.Warning, Exception = exception, ExtendedProperties = extendedProperties });
    }

    public void Info(string message, Exception? exception = null, Dictionary<string, object>? extendedProperties = null)
    {
        Log(new LogEntry { Message = message, Level = LogLevel.Information, Exception = exception, ExtendedProperties = extendedProperties });
    }

    public void Debug(string message, Exception? exception = null, Dictionary<string, object>? extendedProperties = null)
    {
        Log(new LogEntry { Message = message, Level = LogLevel.Debug, Exception = exception, ExtendedProperties = extendedProperties });
    }
}