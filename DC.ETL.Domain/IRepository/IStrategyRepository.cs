using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Domain;

namespace DC.ETL.Domain
{
    /// <summary>
    /// 抽取策略 仓储接口
    /// </summary>
    /// <remarks>
    /// 抽取策略 仓储接口
    /// </remarks>
    public interface IStrategyRepository : IRepository<Strategy>
    {
        /// <summary>
        /// 获取抽取策略列表
        /// </summary>
        /// <param name="SNStrategies"></param>
        /// <returns></returns>
        IEnumerable<Strategy> GetAll(ICollection<Guid> SNStrategies);
    }
}
