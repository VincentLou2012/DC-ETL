using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain.Model
{
    /// <summary>
    /// 任务
    /// </summary>
    public partial class Task : AggregateRoot
    {
        /// <summary>
        /// 获取所有启用任务
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Task> GetAllEnable()
        {
            // TODO: 这里从Unity获取实例?
            ITaskRepository itr = null;// Container.Resolve<ITaskRepository>("TaskRepository");
            return itr.GetAllEnable();
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
    }
}
