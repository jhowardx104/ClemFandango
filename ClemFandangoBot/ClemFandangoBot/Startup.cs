using ClemFandango.Common.DependencyInjection;
using ClemFandangoBot.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ClemFandangoBot;

public static class Startup
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddConsoleLogger();
        services.AddSingleton<IDiscordBot, DiscordBot>();
    }
}