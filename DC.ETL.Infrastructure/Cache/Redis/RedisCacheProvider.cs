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
    public class RedisCacheProvider : ICacheProvider, IDisposable
    {
        private RedisUtils _ru = null;
        public RedisCacheProvider()
        {
            _ru = new RedisUtils();
        }
        /// <summary>
        /// 显式释放资源 避免程序退出出现线程中止问题
        /// 2018-04-19 10:40:01
        /// </summary>
        ~RedisCacheProvider()
        {
            _ru.Dispose();
        }
        public void Dispose()
        {
            _ru.Dispose();
        }

        public void Add(string key, string valueKey, object value)
        {
            //using(_ru = new RedisUtils())
            {
                bool b = _ru.HashSet<object>(key, valueKey, value);
            }
        }

        public void Update(string key, string valueKey, object value)
        {
            //using (_ru = new RedisUtils())
            {
                bool b = _ru.HashSet<object>(key, valueKey, value);
            }
        }

        public object Get(string key, string valueKey)
        {
            //using (_ru = new RedisUtils())
            {
                return _ru.HashGet<object>(key, valueKey);
            }
            //return _ru.HashGet<object>(key, valueKey);
        }

        public void Remove(string key)
        {
            //using (_ru = new RedisUtils())
            {
                bool b = _ru.KeyDelete(key);
            }
        }

        public bool Exists(string key)
        {
            //using (_ru = new RedisUtils())
            {
                return _ru.KeyExists(key);
            }
        }

        public bool Exists(string key, string valueKey)
        {
            //using (_ru = new RedisUtils())
            {
                return _ru.HashExists(key, valueKey);
            }
        }
    }
}
