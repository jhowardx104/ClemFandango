using Docker.DotNet;

namespace ClemFandango.Common.Docker.Services;

public class DockerService(IDockerClient client)
{
    private readonly IDockerClient _client = client ?? throw new ArgumentNullException(nameof(client));
}