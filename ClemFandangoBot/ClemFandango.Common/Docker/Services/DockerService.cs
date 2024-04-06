using Docker.DotNet;
using Docker.DotNet.Models;

namespace ClemFandango.Common.Docker.Services;

public class DockerService(IDockerClient client) : IDockerService
{
    private readonly IDockerClient _client = client ?? throw new ArgumentNullException(nameof(client));

    public async Task<IList<ContainerListResponse>> ListContainersAsync(ContainersListParameters? parameters = null, CancellationToken cancellationToken = default)
    {
        if (parameters is not null) return await _client.Containers.ListContainersAsync(parameters, cancellationToken);
        return await _client.Containers.ListContainersAsync(GetDefaultListParams(), cancellationToken);
    }

    public async Task<ContainerInspectResponse> GetContainerAsync(string containerName, CancellationToken cancellationToken = default)
    {
        var paramList = new ContainersListParameters
        {
            All = true,
            Filters = new Dictionary<string, IDictionary<string, bool>>
            {
                {
                    "name", new Dictionary<string, bool>
                    {
                        {containerName, true}
                    }
                }
            }
        };
        var container = await ListContainersAsync(paramList, cancellationToken);
        if (container.Count == 0) throw new Exception($"Container {containerName} not found.");
        return await _client.Containers.InspectContainerAsync(container.First().ID, cancellationToken);
    }
    
    public async Task<bool> StartContainerAsync(string containerName, ContainerStartParameters? startParams = null, CancellationToken cancellationToken = default)
    {
        var container = await GetContainerAsync(containerName);
        return await StartContainerAsync(container, startParams, cancellationToken);
    }
    
    public async Task<bool> StartContainerAsync(ContainerInspectResponse container, ContainerStartParameters? startParams = null, CancellationToken cancellationToken = default)
    {
        if (startParams is not null) return await _client.Containers.StartContainerAsync(container.ID, startParams, cancellationToken);
        return await _client.Containers.StartContainerAsync(container.ID, GetDefaultStartParams(), cancellationToken);
    }
    
    public async Task<bool> StopContainerAsync(string containerName, ContainerStopParameters? stopParams = null, CancellationToken cancellationToken = default)
    {
        var container = await GetContainerAsync(containerName);
        return await StopContainerAsync(container, stopParams, cancellationToken);
    }
    
    public async Task<bool> StopContainerAsync(ContainerInspectResponse container, ContainerStopParameters? stopParams = null, CancellationToken cancellationToken = default)
    {
        if (stopParams is not null) return await _client.Containers.StopContainerAsync(container.ID, stopParams, cancellationToken);
        return await _client.Containers.StopContainerAsync(container.ID, GetDefaultStopParams(), cancellationToken);
    }

    public async Task<bool> RestartContainerAsync(ContainerInspectResponse container, ContainerStartParameters? startParams = null, ContainerStopParameters? stopParams = null, CancellationToken cancellationToken = default)
    {
        var stopped = await StopContainerAsync(container, stopParams, cancellationToken);
        if (!stopped) return false;
        
        return await StartContainerAsync(container, startParams, cancellationToken);
    }
    
    public async Task<bool> RestartContainerAsync(string containerName, ContainerStartParameters? startParams = null, ContainerStopParameters? stopParams = null, CancellationToken cancellationToken = default)
    {
        var container = await GetContainerAsync(containerName);
        return await RestartContainerAsync(container, startParams, stopParams, cancellationToken);
    }
    
    private ContainerStopParameters GetDefaultStopParams()
    {
        return new ContainerStopParameters
        {
            WaitBeforeKillSeconds = 10
        };
    }
    
    private ContainerStartParameters GetDefaultStartParams()
    {
        return new ContainerStartParameters();
    }
    
    private ContainersListParameters GetDefaultListParams()
    {
        return new ContainersListParameters();
    }
    
    
}