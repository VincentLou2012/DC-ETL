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
            object[] objArr = new object[] { 1,"2" };
            return objArr;
        }
        #endregion Modules

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
            ((RedisCacheProvider)icp).Close();

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
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest()
        {
            ICacheProvider icp = GetTestInterface();
            object[] objArr = GetTestArr();

            foreach (var obj in objArr)
            {
                icp.Get(obj.ToString(), obj.ToString());
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveTest()
        {
            ICacheProvider icp = GetTestInterface();
            object[] objArr = GetTestArr();

            foreach (var obj in objArr)
            {
                icp.Remove(obj.ToString());
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void ExistsTest()
        {
            ICacheProvider icp = GetTestInterface();
            object[] objArr = GetTestArr();

            foreach (var obj in objArr)
            {
                icp.Exists(obj.ToString());
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void ExistsTest2()
        {
            ICacheProvider icp = GetTestInterface();
            object[] objArr = GetTestArr();

            foreach (var obj in objArr)
            {
                icp.Exists(obj.ToString(), obj.ToString());
            }
            Assert.Fail();
        }
    }
}
