using System.Net.Http.Json;
using ClemFandangoBot.ApiClients.SpotifyApiClient.Models;

namespace ClemFandangoBot.ApiClients.SpotifyApiClient;

public class SpotifyApiClient(HttpClient client)
{
    private readonly HttpClient _client = client ?? throw new ArgumentNullException(nameof(client));

    public async Task<SpotifyEpisode> GetLatestEpisode(string podcastId)
    {
        var episodeList = 
            await _client.GetFromJsonAsync<SpotifyPaginatedResponse<SpotifyEpisode>>($"shows/{podcastId}/episodes?limit=1");
        return episodeList.Items.First();
    }
}