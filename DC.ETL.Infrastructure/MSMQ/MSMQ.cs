using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;
using System.Threading;
using System.Configuration;

namespace DC.ETL.Infrastructure.MSMQ
{
    /// <summary>
    /// 消息通道
    /// </summary>
    public sealed class MSMQ
    {
        public MSMQ() { }

        #region 配置字段
        // 侦听最大线程数
        private readonly int MAX_THREADS_COUNT = Convert.ToInt32(ConfigurationManager.AppSettings["MSMQTHREADSNUM"]);
        // 发送通道
        private readonly string TOENGINE_PATH = @".\private$\DM2Engine";
        // 接收通道
        private readonly string TOMANAGE_PATH = @".\private$\Engine2DM";
        #endregion

        #region 处理事件
        public delegate void MessageHandler(Message message);
        public MessageHandler MessageEvent;
        #endregion

        /// <summary>
        /// 侦听线程
        /// </summary>
        private WaitHandle[] HandleArr
        {
            get
            {
                return new WaitHandle[MAX_THREADS_COUNT];
            }
        }

        #region 初始化消息队列
        private MessageQueue _2engineMsg = null;
        private MessageQueue _2manageMsg = null;

        // 指令消息队列
        public MessageQueue ToEngineMsg
        {
            get
            {
                return GetQueue(_2engineMsg, TOENGINE_PATH);
            }
        }
        // 反馈消息队列
        public MessageQueue ToManageMsg
        {
            get
            {
                return GetQueue(_2manageMsg, TOMANAGE_PATH);
            }
        }
        #endregion

        /// <summary>
        /// 获取消息队列实例
        /// </summary>
        /// <param name="msgq">消息队列变量</param>
        /// <param name="path">消息队列路径</param>
        /// <returns></returns>
        private MessageQueue GetQueue(MessageQueue msgq,string path)
        {
            if (msgq is null)
            {
                if (MessageQueue.Exists(path))
                {
                    msgq = new MessageQueue(path);
                }
                else
                {
                    msgq = MessageQueue.Create(path);
                }
            }
            return msgq;
        }

        /// <summary>
        /// 接收完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mq_ReceiveCompleted(object sender, System.Messaging.ReceiveCompletedEventArgs e)
        {
            try
            {
                MessageQueue msmq = (MessageQueue)sender;
                Message m = msmq.EndReceive(e.AsyncResult);

                MessageEvent(m);
            }
            catch (Exception ex)
            {
                //TODO：log队列事件报错
                return;
            }
        }

        /// <summary>
        /// 发送消息到抽取引擎
        /// </summary>
        /// <param name="message"></param>
        public void SendToEngine(JobMessage message)
        {
            Guid MsqSN = new Guid();
            message.MsqSN = MsqSN;
            string Label = MsqSN.ToString();
            ToEngineMsg.Send(message,Label);
        }

        /// <summary>
        /// 发送消息到管理平台
        /// </summary>
        /// <param name="message"></param>
        public void SendToManage(JobMessage message)
        {
            Guid MsqSN = new Guid();
            message.MsqSN = MsqSN;
            string Label = MsqSN.ToString();
            ToManageMsg.Send(message,Label);
        }

        /// <summary>
        /// 开始异步侦听配置端
        /// </summary>
        public void StartManageRcvListener()
        {
            ToManageMsg.ReceiveCompleted += new ReceiveCompletedEventHandler(mq_ReceiveCompleted);
            //异步方式，并发
            for (int i = 0; i < MAX_THREADS_COUNT; i++)
            {
                HandleArr[i] = ToManageMsg.BeginReceive().AsyncWaitHandle;
            }
            return;
        }

        /// <summary>
        /// 开始异步侦听引擎端
        /// </summary>
        public void StartEngineRcvListener()
        {
            ToEngineMsg.ReceiveCompleted += new ReceiveCompletedEventHandler(mq_ReceiveCompleted);
            //异步方式，并发
            for (int i = 0; i < MAX_THREADS_COUNT; i++)
            {
                HandleArr[i] = ToEngineMsg.BeginReceive().AsyncWaitHandle;
            }
            return;
        }
    }
}
