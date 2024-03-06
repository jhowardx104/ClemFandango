using ClemFandango.Common.Logging.Interfaces;
using Discord;
using Discord.WebSocket;

namespace ClemFandangoBot.Services;

public class DiscordBot(ILogger logger): IDiscordBot
{
    private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    public async Task LogAsync(LogMessage message)
    {
        switch (message.Severity)
        {
            case LogSeverity.Info:
                _logger.Info(message.Message, message.Exception);
                break;
            case LogSeverity.Critical:
                _logger.Critical(message.Message, message.Exception);
                break;
            case LogSeverity.Error:
                _logger.Error(message.Message, message.Exception);
                break;
            case LogSeverity.Warning:
                _logger.Warn(message.Message, message.Exception);
                break;
            case LogSeverity.Verbose:
            case LogSeverity.Debug:
                _logger.Debug(message.Message, message.Exception);
                break;
            default:
                _logger.Error(message.Message);
                break;
        }
    }

    public async Task ReadyAsync()
    {
        _logger.Info("Discord client is ready.");
    }

    public async Task MessageReceivedAsync(SocketMessage message)
    {
        _logger.Info("Message received: " + message.Content);
    }
}