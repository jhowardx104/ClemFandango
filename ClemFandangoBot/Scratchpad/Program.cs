// See https://aka.ms/new-console-template for more information

using ClemFandangoBot.ApiClients.BungieNetApiClient;

var client = new BungieNetApiClient();
var manifest = await client.GetManifestAsync();
Console.WriteLine($"Manifest version: {manifest?.Version}");
Console.WriteLine($"MobileAssetContentPath: {manifest?.MobileAssetContentPath}");