using System;
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
    /// 任务执行消息队列处理
    /// </summary>
    public class JobExecuteHandler :
        IHandleMessages<JobExecute>
    {
        public async Task Handle(JobExecute message, IMessageHandlerContext context)
        {
            // 执行任务 从quartz发送消息开始执行指定任务
                    // TaskDTO task = Task.Get(message.TaskSN);
                    // ExcuteJobs(task.Units); // 对每个抽取单元执行任务到quartz

        }
    }
}
