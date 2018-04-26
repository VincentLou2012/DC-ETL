using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace DC.ETL.Infrastructure.MSMQ
{
    public class ManageMQ : MSMQ
    {
        #region 消息队列配置

        // 消息队列路径
        private readonly string TOMANAGE_PATH = @".\private$\Engine2DM";
        //管理端队列实例
        private MessageQueue _2manageMsg = null;

        public MessageQueue ToManageMsg
        {
            get
            {
                return GetQueue(_2manageMsg, TOMANAGE_PATH);
            }
        }

        #endregion

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message">作业消息</param>
        public void Send(JobMessage message)
        {
            base.Send(message, ToManageMsg);
        }

        /// <summary>
        /// 开始侦听队列
        /// </summary>
        public void StartListener()
        {
            base.StartListener(ToManageMsg);
        }
    }
}
