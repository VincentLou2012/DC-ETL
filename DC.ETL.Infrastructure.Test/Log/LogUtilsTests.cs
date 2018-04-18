using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Infrastructure.Log;
using DC.ETL.Infrastructure.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DC.ETL.Infrastructure.Test.Utils;
using System.IO;
namespace DC.ETL.Infrastructure.Log.Tests
{
    [TestClass()]
    public class LogUtilsTests
    {
        #region Modules
        private string GetLog4NetConfigValue(string XPath)
        {
            string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"log4net.config");
            XmlHelper xh = new XmlHelper(xmlPath);
            return xh.GetAttributeValue(XPath, "value");
        }
        private string ReadLastLog()
        {
            string RelPath = GetLog4NetConfigValue(@"//configuration/log4net/appender/file");
            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory , RelPath);
            return FileUtils.ReadLast(logPath, Encoding.UTF8);
        }

        #region Check

        private bool GetIsDebugEnabled()
        {
            return true;
        }

        private bool GetIsErrorEnabled()
        {
            return true;
        }

        private bool GetIsFatalEnabled()
        {
            return true;
        }

        private bool GetIsInfoEnabled()
        {
            return true;
        }

        private bool GetIsTraceEnabled()
        {
            return true;
        }

        private bool GetIsWarnEnabled()
        {
            return true;
        }
        #endregion Check
        #endregion Modules
        [TestMethod()]
        public void InitLog4NetTest()
        {
            LogUtils.InitLog4Net();
            LogUtils.Info("abc");
            string s = ReadLastLog();
            int n = s.IndexOf("| abc");
            Assert.AreEqual(74, n, "写入错误");
        }

        [TestMethod()]
        public void InitLog4NetDBTest()
        {
            LogUtils.InitLog4NetDB();
            LogUtils.Info(new LogContent("127.0.0.1", "111111", "登陆系统", "登陆成功"));
            throw new NotImplementedException();
        }


        [TestMethod()]
        public void IsDebugEnabledTest()
        {
            LogUtils.InitLog4Net();
            bool b = LogUtils.IsDebugEnabled();
            //string s = ReadLastLog();
            Assert.AreEqual(GetIsDebugEnabled(), b);
        }

        [TestMethod()]
        public void IsErrorEnabledTest()
        {
            LogUtils.InitLog4Net();
            bool b = LogUtils.IsErrorEnabled();
            //string s = ReadLastLog();
            Assert.AreEqual(GetIsErrorEnabled(), b);
        }

        [TestMethod()]
        public void IsFatalEnabledTest()
        {
            LogUtils.InitLog4Net();
            bool b = LogUtils.IsFatalEnabled();
            //string s = ReadLastLog();
            Assert.AreEqual(GetIsFatalEnabled(), b);
        }

        [TestMethod()]
        public void IsInfoEnabledTest()
        {
            LogUtils.InitLog4Net();
            bool b = LogUtils.IsInfoEnabled();
            //string s = ReadLastLog();
            Assert.AreEqual(GetIsInfoEnabled(), b);
        }

        [TestMethod()]
        public void IsTraceEnabledTest()
        {
            LogUtils.InitLog4Net();
            bool b = LogUtils.IsTraceEnabled();
            //string s = ReadLastLog();
            Assert.AreEqual(GetIsTraceEnabled(), b);
        }

        [TestMethod()]
        public void IsWarnEnabledTest()
        {
            LogUtils.InitLog4Net();
            bool b = LogUtils.IsWarnEnabled();
            //string s = ReadLastLog();
            Assert.AreEqual(GetIsWarnEnabled(), b);
        }



        [TestMethod()]
        public void DebugTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DebugTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DebugFormatTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DebugExceptionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DebugExceptionTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ErrorTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ErrorTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ErrorFormatTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ErrorExceptionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FatalTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FatalTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FatalFormatTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FatalExceptionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InfoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InfoTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InfoTest2()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InfoFormatTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InfoExceptionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TraceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TraceTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TraceFormatTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TraceExceptionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void WarnTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void WarnTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void WarnFormatTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void WarnExceptionTest()
        {
            Assert.Fail();
        }
    }
}
