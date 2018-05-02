using System;
using NServiceBus;

namespace DC.ETL.Infrastructure.MQ.NServiceBus
{
    /// <summary>
    /// 管理系统或抽取引擎自身发送任务处理命令
    /// </summary>
    public class JobCommand : ICommand
    {
        public Guid MsqSN { get; set; }
        public Guid TaskSN { get; set; }
        public JobOperation OperateFlag { get; set; }
        public JobStatus Status { get; set; }
        public string Flag { get; set; }
        public string JMessage { get; set; }
        public DateTime SendDate { get; set; }
    }

    public enum JobOperation
    {
        ADD = 1,
        STOP = 2,
        RESET = 3,
        GET = 4,
        Execute = 5
    }
    /// <summary>
    /// 任务状态
    /// </summary>
    public enum JobStatus
    {
        Online = 1,
        Disabled = 2,
        Failed = 3,
        CreateFailed = 4
    }
    /// <summary>
    /// 抽取引擎Job处理完成事件
    /// 回传处理结果
    /// </summary>
    public class JobFinished : IEvent
    {
        public JobFinished(JobCommand je)
        {
            MsqSN = je.MsqSN;
            TaskSN = je.TaskSN;
            OperateFlag = je.OperateFlag;
            Status = je.Status;
            Flag = je.Flag;
            JMessage = je.JMessage;
            SendDate = je.SendDate;
        }

        public Guid MsqSN { get; set; }
        public Guid TaskSN { get; set; }

        public Guid ExtractUnitSN { get; set; }
        public JobOperation OperateFlag { get; set; }
        public JobStatus Status { get; set; }
        public string Flag { get; set; }
        public string JMessage { get; set; }
        public DateTime SendDate { get; set; }
    }
}
