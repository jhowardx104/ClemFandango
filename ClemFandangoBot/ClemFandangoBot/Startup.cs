using ClemFandango.Common.DependencyInjection;
using ClemFandango.Common.IO.Json;
using ClemFandango.Common.OAuth.DependencyInjection;
using ClemFandangoBot.ApiClients.BungieNetApiClient;
using ClemFandangoBot.ApiClients.SpotifyApiClient;
using ClemFandangoBot.Options;
using ClemFandangoBot.Services;
using Discord;
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
        
        var spotifyApiOptions = JsonParser.Parse<SpotifyApiOptions>("./Secrets/spotify.json");
        services.AddSingleton(spotifyApiOptions);
        
        var bungieNetApiOptions = JsonParser.Parse<BungieNetApiOptions>("./Secrets/bungie.json");
        services.AddSingleton(bungieNetApiOptions);
        
        /* REGISTER LOGGER */
        services.AddConsoleLogger();
        
        /* REGISTER DISCORD BOT */
        services.ConfigureDiscordBot();
        
        /* REGISTER SPOTIFY API CLIENT */
        services.ConfigureSpotifyApiClient(spotifyApiOptions);
        
        /* REGISTER BUNGIE.NET API CLIENT */
        services.ConfigureBungieNetApiClient(bungieNetApiOptions);
    }
    
    private static void ConfigureBungieNetApiClient(this IServiceCollection services, BungieNetApiOptions bungieNetApiOptions)
    {
        services.AddHttpClient<BungieNetApiClient>((_, client) =>
            {
                client.BaseAddress = new Uri(bungieNetApiOptions.BaseUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", bungieNetApiOptions.ApiKey);
            });
        
        services.AddScoped(sp => new BungieNetApiClient(sp.GetRequiredService<IHttpClientFactory>().CreateClient("BungieNetApiClient")));
    }
    
    private static void ConfigureSpotifyApiClient(this IServiceCollection services, SpotifyApiOptions spotifyApiOptions)
    {
        services.AddHttpClient<SpotifyApiClient>((_, client) =>
            {
                client.BaseAddress = new Uri(spotifyApiOptions.ApiUrl);
            })
            .AddOAuthDelegatingHandler(
                spotifyApiOptions.AuthUrl, 
                spotifyApiOptions.ClientId, 
                spotifyApiOptions.ClientSecret);
        
        services.AddScoped(sp => new SpotifyApiClient(sp.GetRequiredService<IHttpClientFactory>().CreateClient("SpotifyApiClient")));
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
}