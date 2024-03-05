using ClemFandango.Common.Logging.Models;

namespace ClemFandango.Common.Logging.Interfaces;

public interface ILogger
{
    public void Log(LogEntry log);
    public void Critical(string message, Exception? exception = null, Dictionary<string, object>? extendedProperties = null);
    public void Error(string message, Exception? exception = null, Dictionary<string, object>? extendedProperties = null);
    public void Warn(string message, Exception? exception = null, Dictionary<string, object>? extendedProperties = null);
    public void Info(string message, Exception? exception = null, Dictionary<string, object>? extendedProperties = null);
    public void Debug(string message, Exception? exception = null, Dictionary<string, object>? extendedProperties = null);
}