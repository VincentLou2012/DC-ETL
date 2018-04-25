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
    public class ExtractUnitDomainService : IExtractUnitDomainService
    {

        #region 抽取单元
        [Dependency]
        private IExtractUnitRepository iExtractUnitRepository
        {
            get { return Container.Resolve<IExtractUnitRepository>("ExtractUnitRepository"); }
        }
        #endregion 抽取单元

        #region 数据模式
        [Dependency]
        private ISchemaRepository iSchemaRepository
        {
            get { return Container.Resolve<ISchemaRepository>("SchemaRepository"); }
        }
        #endregion 数据模式

        #region 抽取策略
        [Dependency]
        private IStrategyRepository iStrategyRepository
        {
            get { return Container.Resolve<IStrategyRepository>("StrategyRepository"); }
        }
        #endregion 抽取策略
        /// <summary>
        /// 保存选取的策略
        /// </summary>
        /// <returns>Schema模式集合</returns>
        public int SaveStrategy(Guid SNextractUnit, ICollection<Guid> SNStrategies)
        {
            if (SNextractUnit == null || SNStrategies == null) return -1;// TODO: 替换标准错误代码
            ExtractUnit extractUnit = iExtractUnitRepository.GetByKey(SNextractUnit);

            IEnumerable<Strategy> Strategies = iStrategyRepository.GetAll(SNStrategies);
            List<ExtractUnit> extractUnits = new List<ExtractUnit>();
            extractUnits.Add(extractUnit);
            foreach (Strategy item in Strategies)
            {
                if(item.Units == null)
                {
                    item.Units = extractUnits;
                }
                else
                {
                    if (!item.Units.Contains(extractUnit))
                        item.Units.Add(extractUnit);
                }
            }
            iStrategyRepository.Update(Strategies.ToArray());
            return iStrategyRepository.SaveChanges();
        }

        /// <summary>
        /// 保存匹配抽取模式
        /// </summary>
        /// <returns>Schema模式集合</returns>
        public int SaveSchema(Guid SNextractUnit, Guid SNschema)
        {
            if (SNextractUnit == null || SNschema == null) return -1;// TODO: 替换标准错误代码
            ExtractUnit extractUnit = iExtractUnitRepository.GetByKey(SNextractUnit);

            extractUnit.Schema = iSchemaRepository.GetByKey(SNschema);
            extractUnit.SchemaID = extractUnit.Schema.SchemaID; // 手动同步?
            iExtractUnitRepository.Update(extractUnit);
            return iExtractUnitRepository.SaveChanges();
        }

    }
}
