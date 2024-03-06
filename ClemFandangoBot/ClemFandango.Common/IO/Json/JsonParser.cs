using System.Text.Json;

namespace ClemFandango.Common.IO.Json;

public static class JsonParser
{
    public static T Parse<T>(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var objResult = JsonSerializer.Deserialize<T>(json);
        return objResult;
    }
}