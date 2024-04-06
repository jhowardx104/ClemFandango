using ClemFandango.Common.Caching.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ClemFandango.Common.Caching;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddInMemoryCaching(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<ICacheService, InMemoryCacheService>();
        return services;
    }
}