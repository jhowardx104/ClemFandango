using Microsoft.Extensions.DependencyInjection;

namespace ClemFandango.Common.OAuth.DependencyInjection;

public static class IHttpClientBuilderExtensions
{
    public static IHttpClientBuilder AddOAuthDelegatingHandler(this IHttpClientBuilder builder, string baseUrl, string clientId, string clientSecret)
    {
        builder.AddHttpMessageHandler(provider =>
        {
            var client = provider.GetRequiredService<HttpClient>();
            client.BaseAddress = new Uri(baseUrl);
            return new OAuthDelegatingHandler(client, clientId, clientSecret);
        });
        return builder;
    }
}