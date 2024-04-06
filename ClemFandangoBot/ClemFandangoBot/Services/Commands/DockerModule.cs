using ClemFandango.Common.Docker.Services;
using ClemFandangoBot.Services.Commands.Data;
using Discord.Interactions;

namespace ClemFandangoBot.Services.Commands;

public class DockerModule(IDockerService dockerService): InteractionModuleBase
{
    private readonly Dictionary<Dictionaries.DockerContainer, string> _containerNames = Dictionaries.DockerContainerNames;
    private readonly IDockerService _docker = dockerService ?? throw new ArgumentNullException(nameof(dockerService));
    private readonly List<string> DockerAdmins = new() {"jkmstr101", "its_eso", "ludaire"};
    
    [SlashCommand("bounce", "Bounce a container.")]
    public async Task BounceContainer(Dictionaries.DockerContainer container)
    {
        var containerName = _containerNames[container];
        if (DockerAdmins.Any(x => x == Context.User.Username))
        {
            await RespondAsync("Bouncing container. This may take a moment.");
            if(!await _docker.RestartContainerAsync(containerName))
            {
                await RespondAsync($"Failed to bounce container {containerName}.");
                return;
            }
        
            await RespondAsync($"Container {containerName} has been bounced.");
        }
        else
        {
            await RespondAsync("You do not have permission to bounce containers.");
        }
    }
}