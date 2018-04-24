using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain.Model
{
    /// <summary>
    /// 抽取策略
    /// </summary>
    public partial class Strategy : AggregateRoot
    {
        /// <summary>
        /// 获取单个抽取策略
        /// </summary>
        /// <returns></returns>
        public Strategy Get(Guid SN)
        {
            // TODO: 这里从Unity获取实例?
            IRepository<Strategy> itr = null;// Container.Resolve<IRepository<Strategy>>("StrategyRepository");
            return itr.GetByKey(SN);
        }
    }
}
