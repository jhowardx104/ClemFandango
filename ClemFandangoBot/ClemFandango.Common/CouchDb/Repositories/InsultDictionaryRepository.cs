using ClemFandango.Common.CouchDb.Documents;
using CouchDB.Driver.Extensions;

namespace ClemFandango.Common.CouchDb.Repositories;

public class InsultDictionaryRepository(ClemFandangoCouchDbContext dbContext) : IInsultDictionaryRepository
{
    private readonly ClemFandangoCouchDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    
    public async Task<List<InsultDictionary>> GetInsultDictionaries()
    {
        return await _dbContext.Insults.ToListAsync();
    }
    
    public async Task<InsultDictionary?> GetLatestInsultDictionary()
    {
        var insultDictionary = await _dbContext.Insults.ToListAsync();
        return insultDictionary.LastOrDefault();
    }

    public async Task<InsultDictionary> AddInsultAsync(string user, string insult)
    {
        var insultDictionary = await GetLatestInsultDictionary() ?? new InsultDictionary
        {
            Data = new Dictionary<string, List<string>>()
        };

        if (insultDictionary.Data.TryGetValue(user, out var insults))
        {
            if (!insults.Contains(insult))
            {
                insults.Add(insult);
            }
        }
        else
        {
            insultDictionary.Data.Add(user, new List<string> { insult });
        }
        
        insultDictionary.Id = Guid.NewGuid().ToString();
        insultDictionary.UpdatedAt = DateTimeOffset.UtcNow;
        insultDictionary.Revision++;
        return await _dbContext.Insults.AddOrUpdateAsync(insultDictionary);
    }
    
    public async Task<InsultDictionary> DeleteInsultAsync(string user, string insult)
    {
        var insultDictionary = await GetLatestInsultDictionary();
        if (!insultDictionary.Data.TryGetValue(user, out var insults))
        {
            return insultDictionary;
        }

        insults.Remove(insult);
        insultDictionary.Id = Guid.NewGuid().ToString();
        insultDictionary.UpdatedAt = DateTimeOffset.UtcNow;
        insultDictionary.Revision++;
        return await _dbContext.Insults.AddOrUpdateAsync(insultDictionary);
    }
}