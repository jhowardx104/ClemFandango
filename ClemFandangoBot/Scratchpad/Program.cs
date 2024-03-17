// See https://aka.ms/new-console-template for more information
using ClemFandango.Common.OAuth.DependencyInjection;
using ClemFandangoBot.ApiClients.SpotifyApiClient;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

var provider = services.BuildServiceProvider();
var spotifyHttpClient = provider.GetRequiredService<IHttpClientFactory>().CreateClient("SpotifyApiClient");
var client = new SpotifyApiClient(spotifyHttpClient);
var episode = await client.GetLatestEpisode("0SclJGlu8h74Q7NGkqO1UA");
Console.WriteLine("Episode: " + episode.Name);