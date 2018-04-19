using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DC.ETL.Infrastructure.Utils;

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
        /// <summary>
        /// 自动删除多余日志逻辑 获取配置文件参数并根据配置 删除一定数量的日志或一定时间前日志
        /// </summary>
        private static void CheckLog()
        {
            
        }
        private static string Format(params object[] msgs)
        {
            return StrUtils.ToString(msgs);
        }
        private static string FormatTitle(string title, string message)
        {
            return title + " " + message;
        }
        #endregion Init


        #region LibLog

        public static bool IsDebugEnabled()
        {
            CheckLog();
            return Logger.IsDebugEnabled();
        }

        public static bool IsErrorEnabled()
        {
            CheckLog();
            return Logger.IsErrorEnabled();
        }

        public static bool IsFatalEnabled()
        {
            CheckLog();
            return Logger.IsFatalEnabled();
        }

        public static bool IsInfoEnabled()
        {
            CheckLog();
            return Logger.IsInfoEnabled();
        }

        public static bool IsTraceEnabled()
        {
            CheckLog();
            return Logger.IsTraceEnabled();
        }

        public static bool IsWarnEnabled()
        {
            CheckLog();
            return Logger.IsWarnEnabled();
        }

        public static void Debug(Func<string> messageFunc)
        {
            CheckLog();
            Logger.Debug(messageFunc);
        }

        public static void Debug(params object[] msgs)
        {
            CheckLog();
            string message = Format(msgs);
            Logger.Debug(message);
        }

        public static void DebugFormat(string message, params object[] args)
        {
            CheckLog();
            Logger.DebugFormat(message, args);
        }

        public static void DebugException(string message, Exception exception)
        {
            CheckLog();
            Logger.DebugException(message, exception);
        }

        public static void DebugException(string message, Exception exception, params object[] formatParams)
        {
            CheckLog();
            Logger.DebugException(message, exception, formatParams);
        }

        public static void Error(Func<string> messageFunc)
        {
            CheckLog();
            Logger.Error(messageFunc);
        }

        public static void Error(params object[] msgs)
        {
            CheckLog();
            string message = Format(msgs);
            Logger.Error(message);
        }

        public static void ErrorFormat(string message, params object[] args)
        {
            CheckLog();
            Logger.ErrorFormat(message, args);
        }

        public static void ErrorException(string message, Exception exception, params object[] formatParams)
        {
            CheckLog();
            Logger.ErrorException( message, exception, formatParams);
        }

        public static void Fatal(Func<string> messageFunc)
        {
            CheckLog();
            Logger.Fatal(messageFunc);
        }

        public static void Fatal(params object[] msgs)
        {
            CheckLog();
            string message = Format(msgs);
            Logger.Fatal(message);
        }

        public static void FatalFormat(string message, params object[] args)
        {
            CheckLog();
            Logger.FatalFormat(message, args);
        }

        public static void FatalException(string message, Exception exception, params object[] formatParams)
        {
            CheckLog();
            Logger.FatalException(message, exception, formatParams);
        }

        public static void Info(Func<string> messageFunc)
        {
            CheckLog();
            Logger.Info(messageFunc);
        }
        /// <summary>
        /// 输入实体 LogContent
        /// </summary>
        /// <param name="obj"></param>
        public static void InfoModel(object obj)
        {
            CheckLog();
            Logger.Info(obj);
        }

        public static void Info(string title, params object[] msgs)
        {
            CheckLog();
            string message = Format(msgs);
            message = FormatTitle(title, message);
            Logger.Info(message);
        }

        public static void InfoFormat(string title, string message, params object[] args)
        {
            CheckLog();
            message = FormatTitle(title, message);
            Logger.InfoFormat(message, args);
        }

        public static void InfoException(string title, string message, Exception exception, params object[] formatParams)
        {
            CheckLog();
            message = FormatTitle(title, message);
            Logger.InfoException(message, exception, formatParams);
        }

        public static void Trace(Func<string> messageFunc)
        {
            CheckLog();
            Logger.Trace(messageFunc);
        }

        public static void Trace(params object[] msgs)
        {
            CheckLog();
            string message = Format(msgs);
            Logger.Trace(message);
        }

        public static void TraceFormat(string message, params object[] args)
        {
            CheckLog();
            Logger.TraceFormat(message, args);
        }

        public static void TraceException(string message, Exception exception, params object[] formatParams)
        {
            CheckLog();
            Logger.TraceException(message, exception, formatParams);
        }

        public static void Warn(Func<string> messageFunc)
        {
            CheckLog();
            Logger.Warn(messageFunc);
        }

        public static void Warn(params object[] msgs)
        {
            CheckLog();
            string message = Format(msgs);
            Logger.Warn(message);
        }

        public static void WarnFormat(string message, params object[] args)
        {
            CheckLog();
            Logger.WarnFormat(message, args);
        }

        public static void WarnException(string message, Exception exception, params object[] formatParams)
        {
            CheckLog();
            Logger.WarnException(message, exception, formatParams);
        }

        #endregion LibLog
    }
}
