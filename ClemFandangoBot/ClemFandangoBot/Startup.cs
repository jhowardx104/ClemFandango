using ClemFandango.Common.DependencyInjection;
using ClemFandango.Common.IO.Json;
using ClemFandangoBot.Options;
using ClemFandangoBot.Services;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace ClemFandangoBot;

public static class Startup
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddSingleton(JsonParser.Parse<DiscordOptions>("./Secrets/discord.json"));
        services.AddSingleton<IDiscordBot, DiscordBot>();
        services.ConfigureDiscordSocketClient();
        services.AddConsoleLogger();
    }

    private static void ConfigureDiscordSocketClient(this IServiceCollection services)
    {
        services.AddSingleton<IDiscordClient>(provider =>
        {
            var discordOptions = provider.GetRequiredService<DiscordOptions>();
            var client = new DiscordSocketClient(new DiscordSocketConfig
            {
                AlwaysDownloadUsers = true,
                LogLevel = LogSeverity.Debug,
            });
            var discordBot = provider.GetRequiredService<IDiscordBot>();
            client.Log += discordBot.LogAsync;
            client.Ready += discordBot.ReadyAsync;
            client.MessageReceived += discordBot.MessageReceivedAsync;

            client.LoginAsync(TokenType.Bot, discordOptions.Token).Wait();
            client.StartAsync().Wait();
            return client;
        });
    }
}