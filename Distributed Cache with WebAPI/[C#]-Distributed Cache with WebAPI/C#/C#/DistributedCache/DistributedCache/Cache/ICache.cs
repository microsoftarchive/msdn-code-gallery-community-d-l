using System;

namespace DistributedCache.Cache
{
    public interface ICache
    {
        bool Exists(string key);
        bool Delete(string key);
        bool Add(string key, object value, bool forceOverWrite = false);
        bool Add(string key, object value, TimeSpan slidingExpiration, bool forceOverWrite);
        T Get<T>(string key);
        object Get(string key, Type type);
    }
}
