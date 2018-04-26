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
    public abstract class MSMQ
    {
        public MSMQ() { }

        #region 配置字段
        // 侦听最大线程数
        protected readonly int MAX_LISTEN_THREADS_COUNT = Convert.ToInt32(ConfigurationManager.AppSettings["MSMQTHREADSNUM"]);
        
        #endregion

        #region 处理事件
        public delegate void MessageHandler(Message message);
        public MessageHandler MessageEvent;
        #endregion

        /// <summary>
        /// 侦听线程
        /// </summary>
        protected virtual WaitHandle[] HandleArr
        {
            get
            {
                return new WaitHandle[MAX_LISTEN_THREADS_COUNT];
            }
        }

        /// <summary>
        /// 接收完成事件Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Mq_ReceiveCompleted(object sender, System.Messaging.ReceiveCompletedEventArgs e)
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
        /// 获取消息队列实例
        /// </summary>
        /// <param name="msgq">消息队列变量</param>
        /// <param name="path">消息队列路径</param>
        /// <returns></returns>
        protected MessageQueue GetQueue(MessageQueue msgq, string path)
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
        /// 发送消息到队列
        /// </summary>
        /// <param name="message">作业消息</param>
        /// <param name="msg">指定消息队列</param>
        protected virtual void Send(JobMessage message, MessageQueue msg)
        {
            Guid MsqSN = new Guid();
            message.MsqSN = MsqSN;
            string Label = MsqSN.ToString();
            msg.Send(message, Label);
        }

        /// <summary>
        /// 开始异步侦听队列
        /// </summary>
        public virtual void StartListener(MessageQueue msg)
        {
            msg.ReceiveCompleted += new ReceiveCompletedEventHandler(Mq_ReceiveCompleted);
            //异步方式，并发
            for (int i = 0; i < MAX_LISTEN_THREADS_COUNT; i++)
            {
                HandleArr[i] = msg.BeginReceive().AsyncWaitHandle;
            }
            return;
        }






    }
}
