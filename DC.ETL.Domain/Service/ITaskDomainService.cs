using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Models.DTO;

namespace DC.ETL.Domain.Service
{
    /// <summary>
    /// 任务领域服务接口
    /// </summary>
    public interface ITaskDomainService
    {
        /// <summary>
        /// 创建任务基本信息
        /// </summary>
        /// <param name="task"></param>
        int SaveBaseInfo(TaskDTO eu);
    }
}
