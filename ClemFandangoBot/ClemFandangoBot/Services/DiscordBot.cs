using ClemFandango.Common.Logging.Interfaces;

namespace ClemFandangoBot.Services;

public class DiscordBot(ILogger logger): IDiscordBot
{
    private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    public async Task ConnectAsync()
    {
        _logger.Info("connected...");
    }

    public async Task DisconnectAsync()
    {
        _logger.Info("disconnected...");
    }

    public async Task SendMessageAsync(string message)
    {
        _logger.Info($"sending message: {message}");
    }

    public async Task ProcessMessageAsync(string message)
    {
        _logger.Info($"processing message: {message}");
    }
}