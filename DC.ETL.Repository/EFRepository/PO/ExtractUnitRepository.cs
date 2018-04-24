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
    /// 抽取单元 仓储实现
    /// </summary>
    public class ExtractUnitRepository : EFRepository<ExtractUnit>, IExtractUnitRepository
    {
        /// <summary>
        /// 获取满足条件: ExtractUnit.IsEnabled==True
        /// 的所有 ExtractUnit 数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ExtractUnit> GetAllEnable()
        {
            EnableTrack = false;
            Expression<Func<ExtractUnit, bool>> ex = t => t.IsEnabled == (int)EIsEnabled.True;
            return GetAll(new ExpressionSpecification<ExtractUnit>(ex));
        }
    }
}
