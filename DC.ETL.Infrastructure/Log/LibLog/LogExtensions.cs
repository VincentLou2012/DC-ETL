using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibLog.Example.Library.Logging
{
    /// <summary>
    /// Liblog 日志接口功能扩展封装
    /// </summary>
    static partial class LogExtensions
    {
        /// <summary>
        /// log4net 日志 实体写入数据库封装。
        /// 注意：因为LibLog目前没有相应的函数封装，测试后不能达到实体写入日志的要求，因此
        /// 此函数未使用LibLog接口ILog 无法适用于其他日志类库
        /// 2018-04-17 21:19:48
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message">数据库日志表实体 修改时注意相应配置中反射类型对应关系</param>
        public static void Info(this ILog logger, object message)
        {
            log4net.ILog myLogger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            myLogger.Info(message);
        }
    }
}
