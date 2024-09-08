using ClemFandango.Common.Logging.Interfaces;
using ClemFandango.Common.Logging.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ClemFandango.Common.Logging;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddConsoleLogger(this IServiceCollection services)
    {
        services.AddSingleton<ILogger, ConsoleLogger>();
        return services;
    }
}