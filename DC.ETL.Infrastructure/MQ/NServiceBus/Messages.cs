using System;
using NServiceBus;

namespace DC.ETL.Infrastructure.MQ.NServiceBus
{
    /// <summary>
    /// 管理系统发送到抽取引擎命令
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

    public enum JobStatus
    {
        Online = 1,
        Disabled = 2,
        Failed = 3,
        CreateFailed = 4
    }
    /// <summary>
    /// 抽取引擎建立新作业
    /// </summary>
    public class JobMessage : ICommand
    {
        public Guid MsqSN { get; set; }
        public Guid TaskSN { get; set; }
        
        public DateTime SendDate { get; set; }
    }
}
