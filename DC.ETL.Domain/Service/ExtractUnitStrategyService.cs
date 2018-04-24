using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Domain.Specifications;
using System.Linq.Expressions;
using DC.ETL.Domain.Model;

namespace DC.ETL.Domain.Service
{
    public class ExtractUnitStrategyService
    {
        /// <summary>
        /// 保存选取的策略
        /// </summary>
        /// <returns>Schema模式集合</returns>
        public int SaveStrategy(Guid SNextractUnit, ICollection<Guid> SNStrategies)
        {
            if (SNextractUnit == null || SNStrategies == null) return -1;// TODO: 替换标准错误代码
            //ExtractUnit extractUnit = iExtractUnitRepository.GetByKey(SNextractUnit);

            //Expression<Func<Strategy, bool>> ex = t => SNStrategies.Contains(t.SN);
            //IEnumerable<Strategy> Strategies = iStrategyRepository.GetAll(new ExpressionSpecification<Strategy>(ex));
            //extractUnit.Strategies = Strategies.ToArray();
            //iExtractUnitRepository.Update(extractUnit);
            //return iExtractUnitRepository.SaveChanges();
            throw new NotImplementedException();
        }
    }
}
