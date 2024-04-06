using ClemFandango.Common.Docker.Models;
using ClemFandango.Common.Docker.Services;
using Docker.DotNet;
using Microsoft.Extensions.DependencyInjection;

namespace ClemFandango.Common.Docker;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddDockerService(this IServiceCollection services, DockerConfig dockerConfig)
    {
        services.AddScoped<IDockerClient>(_ => new DockerClientConfiguration(new Uri(dockerConfig.Host)).CreateClient());
        services.AddScoped<IDockerService, DockerService>();
        return services;
    }
}