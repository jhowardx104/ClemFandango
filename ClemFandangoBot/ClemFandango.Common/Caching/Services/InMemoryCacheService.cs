using Microsoft.Extensions.Caching.Memory;

namespace ClemFandango.Common.Caching.Services;

public class InMemoryCacheService(IMemoryCache cache): ICacheService
{
    private readonly IMemoryCache _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    
    public async Task<bool> AddOrUpdateAsync<T>(string key, T item, TimeSpan? expiry = null)
    {
        try
        {
            _cache.Set(key, item, expiry ?? TimeSpan.FromMinutes(5));
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        try
        {
            return _cache.Get<T>(key);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> RemoveAsync(string key)
    {
        try
        {
            _cache.Remove(key);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> ExistsAsync(string key)
    {
        return _cache.TryGetValue(key, out _);
    }
}