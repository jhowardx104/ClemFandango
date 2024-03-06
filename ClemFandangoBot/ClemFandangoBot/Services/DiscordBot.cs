using System.Reflection;
using ClemFandango.Common.Logging.Interfaces;
using ClemFandangoBot.Options;
using Discord;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;

namespace ClemFandangoBot.Services;

public class DiscordBot: IDiscordBot
{
    private readonly DiscordOptions _options;
    private readonly DiscordSocketClient _client;
    private readonly InteractionService _interactionService;
    private readonly ILogger _logger;

    public DiscordBot(DiscordOptions options, DiscordSocketClient client, InteractionService interactionService, ILogger logger)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _interactionService = interactionService ?? throw new ArgumentNullException(nameof(interactionService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        InitializeClientAsync().Wait();
    }

    private async Task InitializeClientAsync()
    {
        _client.Log += LogAsync;
        _client.Ready += ReadyAsync;
        _client.SlashCommandExecuted += SlashCommandHandler;
        await _client.LoginAsync(TokenType.Bot, _options.Token);
        await _client.StartAsync();
    }
    
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
    
    public Task SlashCommandHandler(SocketSlashCommand command)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}