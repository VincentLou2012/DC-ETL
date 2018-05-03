using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DC.ETL.Domain;
using DC.ETL.Domain;
using DC.ETL.Domain.Specifications;
using System.Linq.Expressions;

namespace DC.ETL.Repository.EFRepository
{
    /// <summary>
    /// 任务 仓储实现
    /// </summary>
    public class TaskItemRepository : EFRepository<TaskItem>, ITaskItemRepository
    {
        
    }
}
