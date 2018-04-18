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
            throw new NotImplementedException();
        }

        public object Get(string key, string valueKey)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string key)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string key, string valueKey)
        {
            throw new NotImplementedException();
        }
    }
}
