﻿using ClemFandango.Common.Docker.Services;
using ClemFandangoBot.Services.Commands.Data;
using Discord.Interactions;

namespace ClemFandangoBot.Services.Commands;

public class DockerModule(IDockerService dockerService): InteractionModuleBase
{
    private readonly Dictionary<Dictionaries.DockerContainer, string> _containerNames = Dictionaries.DockerContainerNames;
    private readonly IDockerService _docker = dockerService ?? throw new ArgumentNullException(nameof(dockerService));
    private readonly List<string> DockerAdmins = new() {"jkmstr101", "its_eso", "ludaire"};
    
    [SlashCommand("get-container-status", "Get information about a container.")]
    public async Task GetContainerStatus(Dictionaries.DockerContainer container)
    {
        var containerName = _containerNames[container];
        if (DockerAdmins.Any(x => x == Context.User.Username))
        {
            await RespondAsync("Getting container information. This may take a moment.", ephemeral: true);
            var containerInfo = await _docker.GetContainerAsync(containerName);
            await FollowupAsync($"Container {containerName} is {containerInfo.State.Status}.");
        }
        else
        {
            await RespondAsync("You do not have permission to get container information.");
        }
    }
    
    [SlashCommand("start-container", "Start a container.")]
    public async Task StartContainer(Dictionaries.DockerContainer container)
    {
        var containerName = _containerNames[container];
        if (DockerAdmins.Any(x => x == Context.User.Username))
        {
            await RespondAsync("Starting container. This may take a moment.", ephemeral: true);
            if(!await _docker.StartContainerAsync(containerName))
            {
                await FollowupAsync($"Failed to start container {containerName}.");
                return;
            }
        
            await FollowupAsync($"Container {containerName} has been started.");
        }
        else
        {
            await RespondAsync("You do not have permission to start containers.");
        }
    }
    
    [SlashCommand("stop-container", "Stop a container.")]
    public async Task StopContainer(Dictionaries.DockerContainer container)
    {
        var containerName = _containerNames[container];
        if (DockerAdmins.Any(x => x == Context.User.Username))
        {
            await RespondAsync("Stopping container. This may take a moment.", ephemeral: true);
            if(!await _docker.StopContainerAsync(containerName))
            {
                await FollowupAsync($"Failed to stop container {containerName}.");
                return;
            }
        
            await FollowupAsync($"Container {containerName} has been stopped.");
        }
        else
        {
            await RespondAsync("You do not have permission to stop containers.");
        }
    }
    
    [SlashCommand("bounce-container", "Bounce a container.")]
    public async Task BounceContainer(Dictionaries.DockerContainer container)
    {
        var containerName = _containerNames[container];
        if (DockerAdmins.Any(x => x == Context.User.Username))
        {
            await RespondAsync("Bouncing container. This may take a moment.", ephemeral: true);
            if(!await _docker.RestartContainerAsync(containerName))
            {
                await FollowupAsync($"Failed to bounce container {containerName}.");
                return;
            }
        
            await FollowupAsync($"Container {containerName} has been bounced.");
        }
        else
        {
            await RespondAsync("You do not have permission to bounce containers.");
        }
    }
}