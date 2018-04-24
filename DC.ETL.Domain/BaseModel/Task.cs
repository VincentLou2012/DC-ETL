using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using DC.ETL.Infrastructure.Container;

namespace DC.ETL.Domain.Model
{
    /// <summary>
    /// 任务
    /// </summary>
    public partial class Task : AggregateRoot
    {
        [Dependency]
        private readonly ITaskRepository iTaskRepository
        {
            get { return Container.Resolve<ITaskRepository>("TaskRepository"); }
        }

        /// <summary>
        /// 获取所有启用任务
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Task> GetAllEnable()
        {
            return iTaskRepository.GetAllEnable();
        }
        /// <summary>
        /// 获取所有启用任务
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Task> GetAll()
        {
            return iTaskRepository.GetAll();
        }
        /// <summary>
        /// 判断抽取单元是否包含启动项。
        /// 至少包含一条 ExtractUnit.IsEnabled==True
        /// </summary>
        /// <returns></returns>
        public bool IsExtractUnitEnabled()
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
        /// TODO: 创建任务基本信息
        /// </summary>
        /// <param name="task"></param>


        public int SaveBaseInfo(Task eu)
        {
            if (eu == null) return -1;
            Task euInDB = iTaskRepository.GetByKey(eu.SN);

            if (euInDB == null)
            {
                iTaskRepository.Add(eu);
            }
            else
            {
                euInDB.SetBaseInfo(eu);
                iTaskRepository.Update(eu);
            }
            return iTaskRepository.SaveChanges();
        }

        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="o"></param>
        private void SetBaseInfo(Task o)
        {
            //this.TaskID = o.TaskID;// 	任务ID
            this.SN = o.SN;// 	任务序列
            this.Name = o.Name;// 	任务名称
            this.Describe = o.Describe;// 	任务描述
            this.Comment = o.Comment;// 	备注
        }
    }
}
