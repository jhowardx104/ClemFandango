using ClemFandangoBot.ApiClients.BungieNetApiClient.Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ClemFandangoBot.ApiClients.BungieNetApiClient;

public class BungieNetApiClient
{
    public async Task<Manifest?> GetManifestAsync()
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("https://www.bungie.net/Platform/Destiny2/Manifest/");
        var content = await response.Content.ReadAsStringAsync();
        var bungieApiResponse = JsonSerializer.Deserialize<BungieApiResponse<Manifest>>(content);
        return bungieApiResponse?.Response;
    }
}