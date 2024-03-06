using ClemFandango.Common.Logging.Interfaces;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace ClemFandangoBot.Services;

public class DiscordBot: IDiscordBot
{
    private readonly DiscordSocketClient _client;
    private readonly CommandService _commands;
    private readonly ILogger _logger;

    public DiscordBot(DiscordSocketClient client, CommandService commandService, ILogger logger)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _commands = commandService ?? throw new ArgumentNullException(nameof(commandService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        InstallCommandsAsync().Wait();
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

    public async Task MessageReceivedAsync(SocketMessage messageParam)
    {
        //_logger.Info("Message received: " + message.Content);
        var message = messageParam as SocketUserMessage;
        if (message == null) return;

        // Create a number to track where the prefix ends and the command begins
        int argPos = 0;

        // Determine if the message is a command based on the prefix and make sure no bots trigger commands
        if (!(message.HasCharPrefix('!', ref argPos) || 
              message.HasMentionPrefix(_client.CurrentUser, ref argPos)) ||
            message.Author.IsBot)
            return;

        // Create a WebSocket-based command context based on the message
        var context = new SocketCommandContext(_client, message);

        // Execute the command with the command context we just
        // created, along with the service provider for precondition checks.
        await _commands.ExecuteAsync(
            context: context, 
            argPos: argPos,
            services: null);
    }

    public async Task InstallCommandsAsync()
    {
        
    }
}