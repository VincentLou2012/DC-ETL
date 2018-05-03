using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Infrastructure.MQ
{
    /// <summary>
    /// 消息格式
    /// </summary>
    [Serializable]
    public class JobMessage
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
}
