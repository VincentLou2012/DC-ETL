using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
//using NServiceBus.Logging;
using DC.ETL.Infrastructure.MQ.NServiceBus;

namespace DC.ETL.ExtractEngine
{
    /// <summary>
    /// 消息队列处理
    /// </summary>
    public class JobEventHandler :
        IHandleMessages<JobCommand>
    {
        public async Task Handle(JobCommand message, IMessageHandlerContext context)
        {
            switch (message.OperateFlag)
            {
                case JobOperation.ADD:// 增加新任务
                    break;
                case JobOperation.Execute:// 执行任务 分解为任务单元
                    break;
                case JobOperation.GET:// 获取任务状态等数据??
                    break;
                case JobOperation.RESET:// 重置任务状态
                    break;
                case JobOperation.STOP:// 停止任务执行
                    break;
            }

        }
    }
}
