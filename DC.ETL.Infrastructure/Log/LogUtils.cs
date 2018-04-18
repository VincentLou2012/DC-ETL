using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DC.ETL.Infrastructure.Log
{
    using LibLog.Example.Library.Logging;
    /// <summary>
    /// 结合log4net，在基础设施层实现写日志，包含数据库方式，文件方式，提供静态方法调用。
    /// 使用LibLog对log4net进行隔离。
    /// 调用方式
    /// 1.写入文本文件 在程序启动时调用 InitLog4Net()进行初始化 之后按需要调用其他写日志函数。对应配置文件为 log4net.config
    /// 2.写入数据库 在程序启动时调用 InitLog4NetDB()进行初始化 之后按需要调用其他写日志函数。对应配置文件为 log4net_db.config
    /// 2018-04-17 20:25:27
    /// </summary>
    public class LogUtils
    {
        /// <summary>
        /// liblog日志接口 根据初始化情况调用不同日志组件，目前初始化只实现了log4net
        /// 2018-04-17 20:25:27
        /// </summary>
        private static readonly ILog _Logger = LogProvider.GetCurrentClassLogger();

        private static object _lockLog = new object();
        /// <summary>
        /// 日志属性字段
        /// </summary>
        internal static ILog Logger
        {
            get { lock (_lockLog) { return LogUtils._Logger; } }
        } 


        #region Init

        /// <summary>
        /// 初始化 log4net
        /// </summary>
        public static void InitLog4Net()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + @"\Log\Log4net\log4net.config"));
        }
        /// <summary>
        /// 初始化 log4net 写入数据库
        /// </summary>
        public static void InitLog4NetDB()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + @"\Log\Log4net\log4net_db.config"));
        }
        #endregion Init


        #region LibLog

        public static bool IsDebugEnabled()
        {
            return Logger.IsDebugEnabled();
        }

        public static bool IsErrorEnabled()
        {
            return Logger.IsErrorEnabled();
        }

        public static bool IsFatalEnabled()
        {
            return Logger.IsFatalEnabled();
        }

        public static bool IsInfoEnabled()
        {
            return Logger.IsInfoEnabled();
        }

        public static bool IsTraceEnabled()
        {
            return Logger.IsTraceEnabled();
        }

        public static bool IsWarnEnabled()
        {
            return Logger.IsWarnEnabled();
        }

        public static void Debug(Func<string> messageFunc)
        {
            Logger.Debug(messageFunc);
        }

        public static void Debug(string message)
        {
            Logger.Debug(message);
        }

        public static void DebugFormat(string message, params object[] args)
        {
            Logger.DebugFormat(message, args);
        }

        public static void DebugException(string message, Exception exception)
        {
            Logger.DebugException(message, exception);
        }

        public static void DebugException(string message, Exception exception, params object[] formatParams)
        {

                Logger.DebugException(message, exception, formatParams);
        }

        public static void Error(Func<string> messageFunc)
        {
            Logger.Error(messageFunc);
        }

        public static void Error(string message)
        {
            Logger.Error(message);
        }

        public static void ErrorFormat(string message, params object[] args)
        {
            Logger.ErrorFormat(message, args);
        }

        public static void ErrorException(string message, Exception exception, params object[] formatParams)
        {
            Logger.ErrorException( message, exception, formatParams);
        }

        public static void Fatal(Func<string> messageFunc)
        {
            Logger.Fatal(messageFunc);
        }

        public static void Fatal(string message)
        {
            Logger.Fatal(message);
        }

        public static void FatalFormat(string message, params object[] args)
        {
            Logger.FatalFormat(message, args);
        }

        public static void FatalException(string message, Exception exception, params object[] formatParams)
        {
            Logger.FatalException(message, exception, formatParams);
        }

        public static void Info(Func<string> messageFunc)
        {

            Logger.Info(messageFunc);
        }

        public static void Info(object obj)
        {
            Logger.Info(obj);
        }

        public static void Info(string message)
        {
            Logger.Info(message);
        }

        public static void InfoFormat(string message, params object[] args)
        {
            Logger.InfoFormat(message, args);
        }

        public static void InfoException(string message, Exception exception, params object[] formatParams)
        {
            Logger.InfoException(message, exception, formatParams);
        }

        public static void Trace(Func<string> messageFunc)
        {

            Logger.Trace(messageFunc);
        }

        public static void Trace(string message)
        {
            Logger.Trace(message);
        }

        public static void TraceFormat(string message, params object[] args)
        {
            Logger.TraceFormat(message, args);
        }

        public static void TraceException(string message, Exception exception, params object[] formatParams)
        {
            Logger.TraceException(message, exception, formatParams);
        }

        public static void Warn(Func<string> messageFunc)
        {

            Logger.Warn(messageFunc);
        }

        public static void Warn(string message)
        {
            Logger.Warn(message);
        }

        public static void WarnFormat(string message, params object[] args)
        {
            Logger.WarnFormat(message, args);
        }

        public static void WarnException(string message, Exception exception, params object[] formatParams)
        {
            Logger.WarnException(message, exception, formatParams);
        }

        #endregion LibLog
    }
}
