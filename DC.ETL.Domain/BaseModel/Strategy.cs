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
    /// 抽取策略
    /// </summary>
    public partial class Strategy : AggregateRoot
    {

        #region 抽取策略
        [Dependency]
        private IStrategyRepository iStrategyRepository
        {
            get { return Container.Resolve<IStrategyRepository>("StrategyRepository"); }
        }
        #endregion 抽取策略
        /// <summary>
        /// 获取单个抽取策略
        /// </summary>
        /// <returns></returns>
        public Strategy Get(Guid SN)
        {
            return iStrategyRepository.GetByKey(SN);
        }
    }
}
