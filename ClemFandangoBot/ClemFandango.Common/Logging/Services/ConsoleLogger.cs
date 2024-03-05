using ClemFandango.Common.Logging.Enums;
using ClemFandango.Common.Logging.Interfaces;
using ClemFandango.Common.Logging.Models;

namespace ClemFandango.Common.Logging.Services;

public class ConsoleLogger: Logger
{
    public override void Log(LogEntry log)
    {
        switch(log.Level)
        {
            case LogLevel.Critical:
                Console.WriteLine("Critical: " + log.Message, log);
                break;
            case LogLevel.Error:
                Console.WriteLine("Error: " + log.Message, log);
                break;
            case LogLevel.Warning:
                Console.WriteLine("Warning: " + log.Message, log);
                break;
            case LogLevel.Information:
                Console.WriteLine("Information: " + log.Message, log);
                break;
            case LogLevel.Debug:
                Console.WriteLine("Debug: " + log.Message, log);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}