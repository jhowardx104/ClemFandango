using System.Net.Http.Headers;
using System.Text.Json;
using ClemFandango.Common.OAuth.Models;

namespace ClemFandango.Common.OAuth;

public class OAuthDelegatingHandler(HttpClient client, string clientId, string clientSecret): DelegatingHandler
{
    private readonly HttpClient _client = client ?? throw new ArgumentNullException(nameof(client));
    private readonly string _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
    private readonly string _clientSecret = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));
    
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var tokenRequest = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            {"grant_type", "client_credentials"},
            {"client_id", _clientId},
            {"client_secret", _clientSecret}
        });

        var token = await _client.PostAsync("token", tokenRequest, cancellationToken);
        var resultString = await token.Content.ReadAsStringAsync(cancellationToken);
        var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(resultString);
        
        if (tokenResponse?.AccessToken == null)
        {
            throw new Exception("Failed to get token");
        }
        
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);
        return await base.SendAsync(request, cancellationToken);
    }
}