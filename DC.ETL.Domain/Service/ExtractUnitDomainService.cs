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
using DC.ETL.Models.DTO;

namespace DC.ETL.Domain.Service
{
    /// <summary>
    /// 抽取单元领域服务
    /// </summary>
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
        /// <returns>保存操作结果</returns>
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
        /// <returns>保存操作结果</returns>
        public int SaveSchema(Guid SNextractUnit, Guid SNschema)
        {
            if (SNextractUnit == null || SNschema == null) return -1;// TODO: 替换标准错误代码
            ExtractUnit extractUnit = iExtractUnitRepository.GetByKey(SNextractUnit);

            extractUnit.Schema = iSchemaRepository.GetByKey(SNschema);
            extractUnit.SchemaID = extractUnit.Schema.SchemaID; // 手动同步?
            iExtractUnitRepository.Update(extractUnit);
            return iExtractUnitRepository.SaveChanges();
        }
        /// <summary>
        /// 根据抽取模式的一些特征自动选取可能需要的模式并返回
        /// TODO: 抽取模式的特征具体怎么计算还不清楚
        /// </summary>
        /// <returns>Schema模式</returns>
        public SchemaDTO AutoGetSchema(ExtractUnit extractUnit)
        {
            Expression<Func<Schema, bool>> ex = t => t.Units. == extractUnit.TargetName;//TODO: lambda表达式有问题

            Schema extractUnitInDB = iSchemaRepository.GetBySpecification(new ExpressionSpecification<Schema>(ex));

        }
    }
}
