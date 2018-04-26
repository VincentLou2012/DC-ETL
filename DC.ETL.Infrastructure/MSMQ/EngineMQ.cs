using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace DC.ETL.Infrastructure.MSMQ
{
    public class EngineMQ : MSMQ
    {
        #region 消息队列配置

        // 消息队列路径
        private readonly string TOENGINE_PATH = @".\private$\DM2Engine";

        //引擎端队列实例
        private MessageQueue _2engineMsg = null;
        public MessageQueue ToEngineMsg
        {
            get
            {
                return GetQueue(_2engineMsg, TOENGINE_PATH);
            }
        }

        #endregion

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message">作业消息</param>
        public void Send(JobMessage message)
        {
            base.Send(message, ToEngineMsg);
        }

        /// <summary>
        /// 开始侦听队列
        /// </summary>
        public void StartListener()
        {
            base.StartListener(ToEngineMsg);
        }

    }
}
