using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using DC.ETL.Infrastructure.Container;
using DC.ETL.Domain.Specifications;
using System.Linq.Expressions;
using DC.ETL.Domain.Model;
using DC.ETL.Infrastructure.Utils;
using DC.ETL.Models.DTO;

namespace DC.ETL.Domain.Service
{
    /// <summary>
    /// 任务领域服务
    /// </summary>
    public class TaskDomainService : ITaskDomainService
    {
        #region 任务
        [Dependency]
        private ITaskRepository iTaskRepository
        {
            get { return Container.Resolve<ITaskRepository>("TaskRepository"); }
        }
        #endregion 任务


    }
}
