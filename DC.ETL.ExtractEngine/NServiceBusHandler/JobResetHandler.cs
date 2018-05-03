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
    /// 任务重置消息队列处理
    /// </summary>
    public class JobResetHandler :
        IHandleMessages<JobReset>
    {
        public async Task Handle(JobReset message, IMessageHandlerContext context)
        {
            switch (message.OperateFlag)
            {
                case JobOperation.ADD:// 增加新任务
                    // TaskDTO task = Task.Get(message.TaskSN);
                    // RESETJobs(task.Units); // 对每个抽取单元重置任务到quartz
                    break;
                case JobOperation.Execute:// 执行任务 从quartz发送消息开始执行指定任务
                    // TaskDTO task = Task.Get(message.TaskSN);
                    // ExcuteJobs(task.Units); // 对每个抽取单元重置任务到quartz
                    break;
                case JobOperation.GET:// 获取任务状态等数据??
                    // TaskDTO task = Task.Get(message.TaskSN);
                    // 发送消息返回任务数据
                    break;
                case JobOperation.RESET:// 重置任务状态
                    // TaskDTO task = Task.Get(message.TaskSN);
                    // ResetJobs(task.Units); // 对每个抽取单元quartz任务重置状态
                    break;
                case JobOperation.STOP:// 停止任务执行
                    // TaskDTO task = Task.Get(message.TaskSN);
                    // StopJobs(task.Units); // 对每个抽取单元quartz任务重置状态
                    break;
                default:
                    break;
            }

        }
    }
}
