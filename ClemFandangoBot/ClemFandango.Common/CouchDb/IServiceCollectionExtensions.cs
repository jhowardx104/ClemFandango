using ClemFandango.Common.CouchDb.Repositories;
using ClemFandangoBot.Options;
using Microsoft.Extensions.DependencyInjection;
using CouchDB.Driver.DependencyInjection;

namespace ClemFandango.Common.CouchDb;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddCouchDbContext(this IServiceCollection services, CouchDbOptions couchDbOptions)
    {
        services.AddCouchContext<ClemFandangoCouchDbContext>(builder =>
        {
            builder
                .UseEndpoint(couchDbOptions.Url)
                .EnsureDatabaseExists()
                .UseBasicAuthentication(couchDbOptions.Username, couchDbOptions.Password);
        });

        services.AddScoped<IInsultDictionaryRepository, InsultDictionaryRepository>();
        return services;
    }
}