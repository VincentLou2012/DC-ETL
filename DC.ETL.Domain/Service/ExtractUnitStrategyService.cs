using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Domain.Specifications;
using System.Linq.Expressions;
using DC.ETL.Domain.Model;
using Microsoft.Practices.Unity;
using DC.ETL.Infrastructure.Container;

namespace DC.ETL.Domain.Service
{
    public class ExtractUnitStrategyService
    {
        #region 聚合根实例也用Unity??
        [Dependency]
        private ISchemaRepository iSchemaRepository
        {
            get { return Container.Resolve<ISchemaRepository>("ExtractUnit"); }
        }
        #endregion 聚合根实例也用Unity??
        /// <summary>
        /// 保存选取的策略
        /// </summary>
        /// <returns>Schema模式集合</returns>
        public int SaveStrategy(Guid SNextractUnit, ICollection<Guid> SNStrategies)
        {
            if (SNextractUnit == null || SNStrategies == null) return -1;// TODO: 替换标准错误代码
            ExtractUnit extractUnit = new ExtractUnit();
            extractUnit.Get(SNextractUnit);
            //Expression<Func<Strategy, bool>> ex = t => SNStrategies.Contains(t.SN);
            //IEnumerable<Strategy> Strategies = iStrategyRepository.GetAll(new ExpressionSpecification<Strategy>(ex));
            //extractUnit.Strategies = Strategies.ToArray();
            //iExtractUnitRepository.Update(extractUnit);
            //return iExtractUnitRepository.SaveChanges();
            throw new NotImplementedException();
        }
    }
}
