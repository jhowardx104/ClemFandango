using ClemFandango.Common.DependencyInjection;
using ClemFandango.Common.IO.Json;
using ClemFandangoBot.Options;
using ClemFandangoBot.Services;
using Discord;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace ClemFandangoBot;

public static class Startup
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        /* REGISTER OPTIONS */
        var discordOptions = JsonParser.Parse<DiscordOptions>("./Secrets/discord.json");
        services.AddSingleton(discordOptions);
        
        /* REGISTER LOGGER */
        services.AddConsoleLogger();
        
        /* REGISTER DISCORD BOT */
        services.ConfigureDiscordBot();
    }

    private static void ConfigureDiscordBot(this IServiceCollection services)
    {
        var discordConfig = new DiscordSocketConfig
        {
            AlwaysDownloadUsers = true,
            LogLevel = LogSeverity.Debug,
        };
        
        var interactionServiceConfig = new InteractionServiceConfig
        {
            LogLevel = LogSeverity.Debug,
        };

        services
            .AddSingleton(discordConfig)
            .AddSingleton<IDiscordClient, DiscordSocketClient>()
            .AddSingleton<DiscordSocketClient>()
            .AddSingleton(interactionServiceConfig)
            .AddSingleton<InteractionService>();
        
        services.AddSingleton<IDiscordBot, DiscordBot>();
    }
    
    private static void RegisterSlashCommands(this IServiceCollection services)
    {
        
    }
}