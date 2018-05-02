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
    /// 任务添加消息队列处理
    /// </summary>
    public class JobAddHandler :
        IHandleMessages<JobAdd>
    {
        public async Task Handle(JobAdd message, IMessageHandlerContext context)
        {
            // 增加新任务
            // TaskDTO task = Task.Get(message.TaskSN);
            // AddJobs(task.Units); // 对每个抽取单元添加任务到quartz


        }
    }
}
