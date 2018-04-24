using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DC.ETL.Domain.Model;
using DC.ETL.Domain;
using DC.ETL.Domain.Specifications;
using System.Linq.Expressions;

namespace DC.ETL.Repository.EFRepository
{
    /// <summary>
    /// 任务 仓储实现
    /// </summary>
    public class TaskRepository : EFRepository<Task>, ITaskRepository
    {
        /// <summary>
        /// 获取满足条件: Task.IsEnabled==True 并且 
        /// 任意 Task下包含的 ExtractUnit 至少包含一条 ExtractUnit.IsEnabled==True
        /// 的所有 Task 数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Task> GetAllEnable()
        {
            EnableTrack = false;
            Expression<Func<Task,bool>> ex = t => t.IsEnabled == (int)EIsEnabled.True;
            ex.And<Task>(t => t.IsExtractUnitEnabled());
            return GetAll(new ExpressionSpecification<Task>(ex));
        }
    }
}
