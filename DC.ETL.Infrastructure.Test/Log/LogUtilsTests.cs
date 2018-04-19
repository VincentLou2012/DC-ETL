using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Infrastructure.Log;
using DC.ETL.Infrastructure.Log.Models;
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
            string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Log\Log4net\log4net.config");
            XmlHelper xh = new XmlHelper(xmlPath);
            return xh.GetAttributeValue(XPath, "value");
        }
        private string ReadLastLog()
        {
            string RelPath = GetLog4NetConfigValue(@"//configuration/log4net/appender/file");
            DateTime dt = DateTime.Now;
            string logFile = dt.ToString("yyyy") + "/" + dt.ToString("MM") + "/" + dt.ToString("dd") + "/" + dt.ToString("HH") + ".log";
            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, RelPath, logFile);
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
            LogUtils.Info("title1", "abc");
            string s = ReadLastLog();
            int n = s.IndexOf("abc");
            Assert.IsTrue(73<= n, "写入错误:"+n);
            n = s.IndexOf("INFO");
            Assert.IsTrue(0 <= n, "写入INFO错误:" + n);
        }

        [TestMethod()]
        public void InitLog4NetDBTest()
        {
            LogUtils.InitLog4NetDB();
            LogUtils.InfoModel(new LogContent("127.0.0.1", "111111", "登陆系统", "登陆成功"));
            throw new NotImplementedException("需要手动在数据库检查数据 检查逻辑未做");
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
            LogUtils.InitLog4Net();
            LogUtils.Debug("param1", "abc", "abc");
            string s = ReadLastLog();
            int n = s.IndexOf("abc");
            Assert.IsTrue(73 <= n, "写入错误:" + n);
            n = s.IndexOf("DEBUG");
            Assert.IsTrue(0 <= n, "写入DEBUG错误:" + n);
        }

        [TestMethod()]
        public void ErrorTest()
        {
            LogUtils.InitLog4Net();
            LogUtils.Error("param1", "abc", "abc");
            string s = ReadLastLog();
            int n = s.IndexOf("abc");
            Assert.IsTrue(73 <= n, "写入错误:" + n);
            n = s.IndexOf("ERROR");
            Assert.IsTrue(0 <= n, "写入ERROR错误:" + n);
        }

        [TestMethod()]
        public void FatalTest()
        {
            LogUtils.InitLog4Net();
            LogUtils.Fatal("param1", "abc", "abc");
            string s = ReadLastLog();
            int n = s.IndexOf("abc");
            Assert.IsTrue(73 <= n, "写入错误:" + n);
            n = s.IndexOf("FATAL");
            Assert.IsTrue(0 <= n, "写入FATAL错误:" + n);
        }

        [TestMethod()]
        public void TraceTest()
        {
            LogUtils.InitLog4Net();
            LogUtils.Trace("param1", "abc", "abc");
            string s = ReadLastLog();
            int n = s.IndexOf("abc");
            Assert.IsTrue(73 <= n, "写入错误:" + n);
            n = s.IndexOf("TRACE");
            Assert.IsTrue(0 <= n, "写入TRACE错误:" + n);
        }

        [TestMethod()]
        public void WarnTest()
        {
            LogUtils.InitLog4Net();
            LogUtils.Warn("param1", "abc", "abc");
            string s = ReadLastLog();
            int n = s.IndexOf("abc");
            Assert.IsTrue(73 <= n, "写入错误:" + n);
            n = s.IndexOf("WARN");
            Assert.IsTrue(0 <= n, "写入WARN错误:" + n);
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
