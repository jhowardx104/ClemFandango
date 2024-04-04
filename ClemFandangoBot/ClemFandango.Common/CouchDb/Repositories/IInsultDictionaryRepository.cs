using ClemFandango.Common.CouchDb.Documents;

namespace ClemFandango.Common.CouchDb.Repositories;

public interface IInsultDictionaryRepository
{
    Task<List<InsultDictionary>> GetInsultDictionaries();
    Task<InsultDictionary?> GetLatestInsultDictionary();
    Task<InsultDictionary> AddInsultAsync(string user, string insult);
    Task<InsultDictionary> DeleteInsultAsync(string user, string insult);
}