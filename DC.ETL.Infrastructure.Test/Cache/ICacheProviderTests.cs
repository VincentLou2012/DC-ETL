using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Infrastructure.Cache;
using DC.ETL.Infrastructure.Cache.Redis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace DC.ETL.Infrastructure.Cache.Redis.Tests
{
    [TestClass()]
    public class ICacheProviderTests
    {
        #region Modules
        public ICacheProviderTests()
        {
            //ConfigurationManager.ConnectionStrings["RedisConnectionString"].ConnectionString = "192.168.222.159:6379";
            //ConfigurationManager.AppSettings["Redis.DefaultKey"] = "";
        }
        /// <summary>
        /// 测试目标接口类型。目前为Redis实现
        /// 2018-04-18 14:49:53
        /// </summary>
        /// <returns></returns>
        private ICacheProvider GetTestInterface()
        {
            return new RedisCacheProvider();
        }
        private object[] GetTestArr()
        {
            //object[] objArr = new object[] { 1,"2" };
            object[] objArr = GetRandomUnrepeatArray(0, 10000, 1000);
            return objArr;
        }
        /// <summary>
        /// 生成随机数组
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private object[] GetRandomUnrepeatArray(int minValue, int maxValue, int count)
        {
            Random rnd = new Random();
            int length = count + 1;
            byte[] keys = new byte[length];
            rnd.NextBytes(keys);
            object[] items = new object[length];
            for (int i = 0; i < length; i++)
            {
                items[i] = i + minValue;
            }
            Array.Sort(keys, items);
            object[] result = new object[count];
            Array.Copy(items, result, count);
            return result;
        }
        #endregion Modules

        [TestMethod()]
        public void DisponseTest()
        {
            using (RedisCacheProvider icp = new RedisCacheProvider())
            {
                object[] objArr = GetTestArr();

                foreach (var obj in objArr)
                {
                    icp.Add(obj.ToString(), obj.ToString(), obj);
                }

                foreach (var obj in objArr)
                {
                    object o = icp.Get(obj.ToString(), obj.ToString());
                    Assert.AreEqual(obj, o);
                }

            }
        }
        [TestMethod()]
        public void AddTest()
        {
            ICacheProvider icp = GetTestInterface();
            object[] objArr = GetTestArr();

            foreach (var obj in objArr)
            {
                icp.Add(obj.ToString(), obj.ToString(), obj);
            }

            foreach (var obj in objArr)
            {
                object o = icp.Get(obj.ToString(), obj.ToString());
                Assert.AreEqual(obj, o);
            }

        }

        [TestMethod()]
        public void UpdateTest()
        {
            ICacheProvider icp = GetTestInterface();
            object[] objArr = GetTestArr();

            foreach (var obj in objArr)
            {
                icp.Update(obj.ToString(), obj.ToString(), obj);
            }

            foreach (var obj in objArr)
            {
                object o = icp.Get(obj.ToString(), obj.ToString());
                Assert.AreEqual(obj, o);
            }
            //((RedisCacheProvider)icp).Close();
        }

        [TestMethod()]
        public void GetTest()
        {
            ICacheProvider icp = GetTestInterface();
            object[] objArr = GetTestArr();

            foreach (var obj in objArr)
            {
                object o = icp.Get(obj.ToString(), obj.ToString());
                Assert.AreEqual(obj, o);
            }
            //((RedisCacheProvider)icp).Close();
        }

        [TestMethod()]
        public void RemoveTest()
        {
            ICacheProvider icp = GetTestInterface();
            object[] objArr = GetTestArr();

            foreach (var obj in objArr)
            {
                icp.Add(obj.ToString(), obj.ToString(), obj);
            }

            foreach (var obj in objArr)
            {
                icp.Remove(obj.ToString());
            }

            foreach (var obj in objArr)
            {
                object o = icp.Get(obj.ToString(), obj.ToString());
                Assert.AreEqual(null, o);
            }
            //((RedisCacheProvider)icp).Close();
        }

        [TestMethod()]
        public void ExistsTest()
        {
            ICacheProvider icp = GetTestInterface();
            object[] objArr = GetTestArr();

            foreach (var obj in objArr)
            {
                icp.Add(obj.ToString(), obj.ToString(), obj);
            }

            foreach (var obj in objArr)
            {
                bool b = icp.Exists(obj.ToString());
                Assert.AreEqual(true, b);
            }
            //((RedisCacheProvider)icp).Close();
        }

        [TestMethod()]
        public void ExistsTest2()
        {
            ICacheProvider icp = GetTestInterface();
            object[] objArr = GetTestArr();

            foreach (var obj in objArr)
            {
                icp.Add(obj.ToString(), obj.ToString(), obj);
            }

            foreach (var obj in objArr)
            {
                bool b = icp.Exists(obj.ToString(), obj.ToString());
                Assert.AreEqual(true, b);
            }
            //((RedisCacheProvider)icp).Close();
        }
    }
}
