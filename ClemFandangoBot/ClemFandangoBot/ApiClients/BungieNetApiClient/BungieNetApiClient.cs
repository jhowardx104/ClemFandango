using System.Net.Http.Json;
using ClemFandangoBot.ApiClients.BungieNetApiClient.Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ClemFandangoBot.ApiClients.BungieNetApiClient;

public class BungieNetApiClient(HttpClient client)
{
    private readonly HttpClient _client = client ?? throw new ArgumentNullException(nameof(client));
    public async Task<Manifest?> GetManifestAsync()
    {
        var bungieApiResponse = await _client.GetFromJsonAsync<BungieApiResponse<Manifest>>("Destiny2/Manifest");
        return bungieApiResponse?.Response;
    }
}