using Docker.DotNet.Models;

namespace ClemFandango.Common.Docker.Services;

public interface IDockerService
{
    Task<IList<ContainerListResponse>> ListContainersAsync(ContainersListParameters? parameters = null, CancellationToken cancellationToken = default);
    Task<ContainerInspectResponse> GetContainerAsync(string containerName, CancellationToken cancellationToken = default);
    Task<bool> StartContainerAsync(string containerName, ContainerStartParameters? startParams = null, CancellationToken cancellationToken = default);
    Task<bool> StartContainerAsync(ContainerInspectResponse container, ContainerStartParameters? startParams = null, CancellationToken cancellationToken = default);
    Task<bool> StopContainerAsync(string containerName, ContainerStopParameters? stopParams = null, CancellationToken cancellationToken = default);
    Task<bool> StopContainerAsync(ContainerInspectResponse container, ContainerStopParameters? stopParams = null, CancellationToken cancellationToken = default);
    Task<bool> RestartContainerAsync(ContainerInspectResponse container, ContainerStartParameters? startParams = null, ContainerStopParameters? stopParams = null, CancellationToken cancellationToken = default);
    Task<bool> RestartContainerAsync(string containerName, ContainerStartParameters? startParams = null, ContainerStopParameters? stopParams = null, CancellationToken cancellationToken = default);
}