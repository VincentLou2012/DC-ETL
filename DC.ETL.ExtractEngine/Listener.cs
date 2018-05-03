using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using DC.ETL.Infrastructure.MQ;
namespace DC.ETL.ExtractEngine
{
    public class Listener
    {
        private static Listener _listener;

        public static Listener Instance
        {
            get
            {
                if (_listener is null)
                {
                    _listener = new Listener();
                }
                return _listener;
            }
        }
        public Listener()
        {
            _listener = null;
        }

        public void Listen()
        {
            EngineMQ Mq = new EngineMQ();
            Mq.MessageEvent += new MSMQ.MessageHandler(Dispatch);
            Mq.StartListener();
        }

        public void Dispatch(Message msg)
        {
            msg.Formatter = new System.Messaging.XmlMessageFormatter(new Type[] { typeof(JobMessage) });
            JobMessage jobmsg = msg.Body as JobMessage;
            //TODO:记录接收到新任务
        }
    }
}
