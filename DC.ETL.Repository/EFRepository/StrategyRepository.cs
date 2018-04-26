using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Domain.Model;
using DC.ETL.Domain;
using DC.ETL.Domain.Specifications;
using System.Linq.Expressions;

namespace DC.ETL.Repository.EFRepository
{
    /// <summary>
    /// 抽取策略 仓储实现
    /// </summary>
    public class StrategyRepository : EFRepository<Strategy>, IStrategyRepository
    {
        /// <summary>
        /// 获取抽取策略列表
        /// </summary>
        /// <param name="SNStrategies"></param>
        /// <returns></returns>
        public IEnumerable<Strategy> GetAll(ICollection<Guid> SNStrategies)
        {
            Expression<Func<Strategy, bool>> ex = t => SNStrategies.Contains(t.SN);
            return GetAll(new ExpressionSpecification<Strategy>(ex));
        }
    }
}
