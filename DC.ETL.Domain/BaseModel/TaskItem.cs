using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using DC.ETL.Infrastructure.Container;
using DC.ETL.Domain.Specifications;
using System.Linq.Expressions;
using DC.ETL.Infrastructure.Utils;
using DC.ETL.Models.DTO;

namespace DC.ETL.Domain
{
    /// <summary>
    /// 任务
    /// </summary>
    public partial class TaskItem : AggregateRoot
    {
        #region 任务
        [Dependency]
        private ITaskItemRepository iTaskRepository
        {
            get { return Container.Resolve<ITaskItemRepository>("TaskRepository"); }
        }
        #endregion 任务

        /// <summary>
        /// 获取单个数据源
        /// </summary>
        /// <returns></returns>
        public TaskDTO Get(Guid SN)
        {
            return AutoMapperUtils.MapTo<TaskDTO>(iTaskRepository.GetByKey(SN));
        }

        /// <summary>
        /// 获取满足条件: Task.IsEnabled==True 并且 
        /// 任意 Task下包含的 ExtractUnit 至少包含一条 ExtractUnit.IsEnabled==True
        /// 的所有 Task 数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TaskDTO> GetAllEnable()
        {
            iTaskRepository.EnableTrack = false;

            Expression<Func<TaskItem, bool>> exTask = t => t.IsEnabled == (int)EIsEnabled.True;
            IEnumerable<TaskItem> taskList = iTaskRepository.GetAll(new ExpressionSpecification<TaskItem>(exTask));

            List<TaskItem> list = new List<TaskItem>();
            foreach (TaskItem item in taskList)
            {
                if (item.IsExtractUnitEnabled())
                    list.Add(item);
            }
            
            return AutoMapperUtils.MapToList<TaskDTO>(list);
        }
        /// <summary>
        /// 判断抽取单元是否包含启动项。
        /// 至少包含一条 ExtractUnit.IsEnabled==True
        /// </summary>
        /// <returns></returns>
        private bool IsExtractUnitEnabled()
        {
            bool b = false;
            if (Units == null || Units.Count == 0) return b;
            foreach (ExtractUnit unit in Units)
            {
                if (unit.IsEnabled == (int)EIsEnabled.True)
                {
                    b = true;
                    break;
                }
            }
            return b;
        }
        

        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="o"></param>
        public void SetBaseInfo(TaskItem o)
        {
            //this.TaskID = o.TaskID;// 	任务ID
            this.ID = o.ID;// 	任务序列
            this.Name = o.Name;// 	任务名称
            this.Describe = o.Describe;// 	任务描述
            this.Comment = o.Comment;// 	备注
        }
    }
}
