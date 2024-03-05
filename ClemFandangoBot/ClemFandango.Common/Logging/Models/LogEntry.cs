using ClemFandango.Common.Logging.Enums;

namespace ClemFandango.Common.Logging.Models;

public class LogEntry
{
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }
    public string Source { get; set; }
    public LogLevel Level { get; set; }
    public Exception? Exception { get; set; }
    public Dictionary<string, object>? ExtendedProperties { get; set; } 
}