using System.Text.Json.Serialization;

namespace ClemFandangoBot.Options;

public class SpotifyApiOptions
{
    [JsonPropertyName("api_url")]
    public string ApiUrl { get; set; }
    [JsonPropertyName("auth_url")]
    public string AuthUrl { get; set; }
    [JsonPropertyName("client_id")]
    public string ClientId { get; set; }
    [JsonPropertyName("client_secret")]
    public string ClientSecret { get; set; }
    [JsonPropertyName("subscriptions")]
    public List<SpotifyEpisodeSubscription> Subscriptions { get; set; }
}

public class SpotifyEpisodeSubscription
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("release_cron")]
    public string ReleaseCron { get; set; }
}