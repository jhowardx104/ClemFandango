using System.Reflection;
using ClemFandango.Common.Logging.Interfaces;
using ClemFandangoBot.Options;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;

namespace ClemFandangoBot.Services;

public class DiscordBot: IDiscordBot
{
    private readonly DiscordOptions _options;
    private readonly DiscordSocketClient _client;
    private readonly InteractionService _interactionService;
    private readonly ILogger _logger;
    private readonly IServiceProvider _serviceProvider;

    public DiscordBot(DiscordOptions options, DiscordSocketClient client, InteractionService interactionService, ILogger logger, IServiceProvider serviceProvider)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _interactionService = interactionService ?? throw new ArgumentNullException(nameof(interactionService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
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
        await RegisterSlashCommands();
    }
    
    public async Task SlashCommandHandler(SocketSlashCommand command)
    {
        var context = new InteractionContext(_client, command);
        await _interactionService.ExecuteCommandAsync(context, _serviceProvider);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    private async Task RegisterSlashCommands()
    {
        //Get all values marked with attribute SlashCommand that are in the assembly
        await _interactionService.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), services: _serviceProvider);
        
        foreach (var guild in _client.Guilds)
        {
            foreach(var command in _interactionService.SlashCommands)
            {
                var commandBuilder = new SlashCommandBuilder();
                commandBuilder.WithName(command.Name);
                commandBuilder.WithDescription(command.Description);
                foreach(var param in command.Parameters)
                {
                    if (param.ParameterType.IsEnum)
                    {
                        var slashCommandOptionBuilder = new SlashCommandOptionBuilder()
                            .WithName(param.Name)
                            .WithDescription(param.Description)
                            .WithRequired(param.IsRequired)
                            .WithType(ApplicationCommandOptionType.String);
                        
                        foreach (var value in Enum.GetValues(param.ParameterType))
                        {
                            // see if value has ChoiceDisplay attribute
                            var memberInfo = param.ParameterType.GetMember(value.ToString());
                            var attributes = memberInfo[0].GetCustomAttributes(typeof(ChoiceDisplayAttribute), false);
                            if (attributes.Length > 0)
                            {
                                var choiceDisplayAttribute = (ChoiceDisplayAttribute)attributes[0];
                                slashCommandOptionBuilder.AddChoice(choiceDisplayAttribute.Name, value.ToString());
                            }
                            else
                            {
                                slashCommandOptionBuilder.AddChoice(value.ToString(), value.ToString());
                            }
                        }
                        
                        commandBuilder.AddOption(slashCommandOptionBuilder);
                    }
                    else
                    {
                        commandBuilder.AddOption(param.Name, param.DiscordOptionType!.Value, param.Description, param.IsRequired);
                    }
                }
                
                await guild.CreateApplicationCommandAsync(commandBuilder.Build());
            }
        }
        
    }
}