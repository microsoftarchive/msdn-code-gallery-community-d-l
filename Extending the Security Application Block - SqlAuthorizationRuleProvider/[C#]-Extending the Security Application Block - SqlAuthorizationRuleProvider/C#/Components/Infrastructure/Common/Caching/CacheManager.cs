using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CacheBlock = Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace Volvo.VehicleMaster.Infrastructure.Common.Utilities.Caching
{
    class CacheManager
    {
        private CacheBlock.ICacheManager m_cacheManager;
        public CacheManager()
        {
            //this.m_cacheManager = CacheBlock.CacheFactory.GetCacheManager();
            this.m_cacheManager = CacheBlock.CacheFactory.GetCacheManager("CacheManager");
        }

        public void Add(string key, object value)
        {
            this.m_cacheManager.Add(key, value);
        }

        public void Add(string key, object value, double minutesToExpire)
        {
            this.m_cacheManager.Add(key, value, CacheBlock.CacheItemPriority.Normal, null, new CacheBlock.Expirations.AbsoluteTime(TimeSpan.FromMinutes(minutesToExpire)));
        }

        public object Get(string key)
        {
            return this.m_cacheManager.GetData(key);
        }

        public void Flush()
        {
            this.m_cacheManager.Flush();
        }

        public bool ContainsKey(string key)
        {
            return this.m_cacheManager.Contains(key);
        }

        public void Remove(string key)
        {
            this.m_cacheManager.Remove(key);
        }
    }
}
