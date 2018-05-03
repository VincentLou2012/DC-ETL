using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Infrastructure.MQ
{
    public class JobMQ : MSMQ //, IMessageQueue
    {
        private readonly string JobQueue_PATH = @".\private$\JobQueue";
    }
}
