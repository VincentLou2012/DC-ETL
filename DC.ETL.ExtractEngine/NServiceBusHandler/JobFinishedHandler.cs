﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
//using NServiceBus.Logging;
using DC.ETL.Infrastructure.MQ.NServiceBus;

namespace DC.ETL.ExtractEngine.NServiceBus
{
    /// <summary>
    /// 任务完成消息处理
    /// </summary>
    public class JobFinishedHandler :
        IHandleMessages<JobFinished>
    {
        public async Task Handle(JobFinished message, IMessageHandlerContext context)
        {
            

        }
    }
}
