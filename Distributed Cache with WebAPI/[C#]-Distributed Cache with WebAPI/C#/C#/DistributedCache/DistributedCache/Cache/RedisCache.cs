using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using StackExchange.Redis;

namespace DistributedCache.Cache
{
    public class RedisCache : ICache
    {
        #region Static properties

        private static volatile ConnectionMultiplexer _redis = null;
        private static readonly object _initLock = new object();

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="RedisCache" /> class.
        /// </summary>
        /// <param name="ipAdrress">The ip adrress.</param>
        public RedisCache(string ipAdrress)
        {
            Contract.Requires(!String.IsNullOrWhiteSpace(ipAdrress));

            if (_redis == null)
            {
                lock (_initLock)
                {
                    if (_redis == null) _redis = ConnectionMultiplexer.Connect(ipAdrress);
                }
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Existses the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            Contract.Requires(!String.IsNullOrWhiteSpace(key));

            return _redis.GetDatabase().KeyExists(key);
        }

        /// <summary>
        ///     Deletes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">key</exception>
        public bool Delete(string key)
        {
            Contract.Requires(!String.IsNullOrWhiteSpace(key));

            return _redis.GetDatabase().KeyDelete(key);
        }

        /// <summary>
        ///     Add the specified object to the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="forceOverWrite">if set to <c>true</c> [force over write].</param>
        /// <returns></returns>
        public bool Add(string key, object value, bool forceOverWrite = false)
        {
            Contract.Requires(!String.IsNullOrWhiteSpace(key));

            return Add(key, value, TimeSpan.Zero, forceOverWrite);
        }

        /// <summary>
        ///     Add the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="slidingExpiration">The sliding expiration.</param>
        /// <param name="forceOverWrite">if set to <c>true</c> [force over write].</param>
        /// <returns></returns>
        public bool Add(string key, object value, TimeSpan slidingExpiration, bool forceOverWrite)
        {
            Contract.Requires(!String.IsNullOrWhiteSpace(key));

            bool itemExists = Exists(key);
            if (!forceOverWrite && itemExists) return false;

            if (itemExists) Delete(key);

            IDatabase db = _redis.GetDatabase();
            RedisValue redisValue = TrasformToRedisValue(value);
            return db.HashSet(key, key, redisValue) && db.KeyExpire(key, slidingExpiration);
        }

        /// <summary>
        ///     Gets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            Contract.Requires(!String.IsNullOrWhiteSpace(key));

            IDatabase db = _redis.GetDatabase();
            RedisValue redisValue = db.HashGet(key, key);
            return TrasformFromRedisValue<T>(redisValue);
        }

        /// <summary>
        ///     Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public object Get(string key, Type type)
        {
            Contract.Requires(!String.IsNullOrWhiteSpace(key));

            IDatabase db = _redis.GetDatabase();
            RedisValue redisValue = db.HashGet(key, key);
            return TrasformFromRedisValue<object>(redisValue);
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Trasforms to redis value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private RedisValue TrasformToRedisValue(object value)
        {
            return Serialize(value);
        }

        /// <summary>
        ///     Trasforms from redis value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisValue">The redis value.</param>
        /// <returns></returns>
        private T TrasformFromRedisValue<T>(RedisValue redisValue)
        {
            if (redisValue.IsNull) return default(T);

            return (T)ConvertRedisValueToObject(redisValue);
        }

        /// <summary>
        ///     Check and convert native type supported from Redis.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private object ConvertRedisValueToObject(RedisValue value)
        {
            return DeSerialize((Byte[])value);
        }

        /// <summary>
        ///     Serializes the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Parameter is invalid.;obj;null</exception>
        private byte[] Serialize(object obj)
        {
            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                byte[] result = ms.ToArray();
                ms.Flush();
                return result;
            }
        }

        /// <summary>
        ///     Des the serialize.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        private object DeSerialize(byte[] obj)
        {
            using (var ms = new MemoryStream(obj))
            {
                var bf = new BinaryFormatter();
                ms.Seek(0, SeekOrigin.Begin);
                object result = bf.Deserialize(ms);
                ms.Flush();
                return result;
            }
        }

        #endregion
    }
}