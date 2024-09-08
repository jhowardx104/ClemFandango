using System.Text.Json.Serialization;

namespace ClemFandangoBot.ApiClients.BungieNetApiClient.Models;

public class Manifest
{
    [JsonPropertyName("version")]
    public string Version { get; set; }
    [JsonPropertyName("mobileAssetContentPath")]
    public string MobileAssetContentPath { get; set; }
    [JsonPropertyName("mobileGearAssetDataBases")]
    public List<AssetDatabase> MobileGearAssetDataBases { get; set; }
    [JsonPropertyName("mobileWorldContentPaths")]
    public Dictionary<string, string> MobileWorldContentPaths { get; set; }
    [JsonPropertyName("jsonWorldContentPaths")]
    public Dictionary<string, string> JsonWorldContentPaths { get; set; }
    [JsonPropertyName("jsonWorldComponentContentPaths")]
    public Dictionary<string, Dictionary<string, string>> JsonWorldComponentContentPaths { get; set; }
    [JsonPropertyName("mobileClanBannerDatabasePath")]
    public string MobileClanBannerDatabasePath { get; set; }
    [JsonPropertyName("mobileGearCDN")]
    public Dictionary<string, string> MobileGearCDN { get; set; }
    [JsonPropertyName("iconImagePyramidInfo")]
    public List<object> IconImagePyramidInfo { get; set; }
}