using ClemFandango.Common.Logging.Interfaces;
using ClemFandango.Common.Logging.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ClemFandango.Common.DependencyInjection;

public static class LoggingDependencyInjectionExtensions
{
    public static IServiceCollection AddConsoleLogger(this IServiceCollection services)
    {
        services.AddSingleton<ILogger, ConsoleLogger>();
        return services;
    }
}