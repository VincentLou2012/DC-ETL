using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DC.ETL.Infrastructure.Cache.Redis
{
    /// <summary>
    /// redis 缓存 接口方法实现
    /// 目前调用 RedisHelper封装类实现功能
    /// 2018-04-18 14:15:27
    /// </summary>
    public class RedisCacheProvider : ICacheProvider
    {
        private RedisUtils _ru = new RedisUtils();

        public void Add(string key, string valueKey, object value)
        {
            bool b = _ru.HashSet<object>(key, valueKey, value);
        }

        public void Update(string key, string valueKey, object value)
        {
            bool b = _ru.HashSet<object>(key, valueKey, value);
        }

        public object Get(string key, string valueKey)
        {
            return _ru.HashGet<object>(key, valueKey);
        }

        public void Remove(string key)
        {
            bool b = _ru.KeyDelete(key);
        }

        public bool Exists(string key)
        {
            return _ru.KeyExists(key);
        }

        public bool Exists(string key, string valueKey)
        {
            return _ru.HashExists(key, valueKey);
        }
    }
}
