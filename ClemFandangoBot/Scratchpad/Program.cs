using System.Text.Json;
using ClemFandango.Common.Docker;
using ClemFandango.Common.Docker.Models;
using ClemFandango.Common.Docker.Services;
using Microsoft.Extensions.DependencyInjection;

IServiceCollection services = new ServiceCollection();

services.AddDockerService(new DockerConfig
{
    Host = "tcp://192.168.1.251:2375"
});

var serviceProvider = services.BuildServiceProvider();
var dockerService = serviceProvider.GetRequiredService<IDockerService>();

var container = await dockerService.GetContainerAsync("/Palworld");
Console.WriteLine(JsonSerializer.Serialize(container));

