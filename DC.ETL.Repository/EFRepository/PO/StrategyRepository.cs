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

    }
}
