namespace ClemFandango.Common.Caching.Services;

public interface ICacheService
{
    Task<bool> AddOrUpdateAsync<T>(string key, T item, TimeSpan? expiry = null);
    Task<T?> GetAsync<T>(string key);
    Task<bool> RemoveAsync(string key);
    Task<bool> ExistsAsync(string key);
}