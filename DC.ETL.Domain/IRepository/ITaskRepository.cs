using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DC.ETL.Domain.Model;

namespace DC.ETL.Domain
{
    /// <summary>
    /// 任务 仓储接口
    /// </summary>
    /// <remarks>
    /// 任务 仓储接口
    /// </remarks>
    public interface ITaskRepository
    {
        /// <summary>
        /// 获取满足条件: Task.IsEnabled==True 并且 
        /// 任意 Task下包含的 ExtractUnit 至少包含一条 ExtractUnit.IsEnabled==True
        /// 的所有 Task 数据
        /// </summary>
        /// <returns></returns>
        IEnumerable<Task> GetAllEnable();
    }
}
