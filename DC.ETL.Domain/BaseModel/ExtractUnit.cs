using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using DC.ETL.Infrastructure.Container;
using DC.ETL.Domain.Specifications;
using System.Linq.Expressions;

namespace DC.ETL.Domain.Model
{
    /// <summary>
    /// 抽取单元
    /// </summary>
    public partial class ExtractUnit : AggregateRoot
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
        /// 获取单个抽取单元
        /// </summary>
        /// <returns></returns>
        public ExtractUnit Get(Guid SN)
        {
            return iExtractUnitRepository.GetByKey(SN);
        }

        /// <summary>
        /// 新增或保存抽取单元基本信息 不包含Schema模式和策略??
        /// </summary>
        /// <param name="eu">设置抽取单元新值</param>
        public int SaveBaseInfo(ExtractUnit eu)
        {
            if (eu == null) return -1;// TODO: 替换标准错误代码
            ExtractUnit euInDB = iExtractUnitRepository.GetByKey(eu.SN);

            if (euInDB == null)
            {
                iExtractUnitRepository.Add(eu);
            }
            else
            {
                euInDB.SetBaseInfo(eu);
                iExtractUnitRepository.Update(euInDB);
            }
            return iExtractUnitRepository.SaveChanges();
        }
        /// <summary>
        /// 更新抽取单元 Schema模式和策略 等
        /// </summary>
        /// <param name="extractUnit"></param>
        /// <returns></returns>
        public int Update(ExtractUnit extractUnit)
        {
            iExtractUnitRepository.Update(extractUnit);
            return iStrategyRepository.SaveChanges();
        }
        ///// <summary>
        ///// 保存匹配抽取模式
        ///// </summary>
        ///// <returns>Schema模式集合</returns>
        //public int SaveSchema(Guid SNextractUnit, Guid SNschema)
        //{
        //    if (SNextractUnit == null || SNschema == null) return -1;
        //    ExtractUnit extractUnit = iExtractUnitRepository.GetByKey(SNextractUnit);
        //    extractUnit.Schema = iSchemaRepository.GetByKey(SNschema);
        //    iExtractUnitRepository.Update(extractUnit);
        //    return iExtractUnitRepository.SaveChanges();
        //}
        ///// <summary>
        ///// 保存选取的策略
        ///// </summary>
        ///// <returns>Schema模式集合</returns>
        //public int SaveStrategy(Guid SNextractUnit, ICollection<Guid> SNStrategies)
        //{
        //    if (SNextractUnit == null || SNStrategies == null) return -1;
        //    ExtractUnit extractUnit = iExtractUnitRepository.GetByKey(SNextractUnit);
            
        //    Expression<Func<Strategy, bool>> ex = t => SNStrategies.Contains(t.SN);
        //    IEnumerable<Strategy> Strategies = iStrategyRepository.GetAll(new ExpressionSpecification<Strategy>(ex));
        //    extractUnit.Strategies = Strategies.ToArray();
        //    iExtractUnitRepository.Update(extractUnit);
        //    return iExtractUnitRepository.SaveChanges();
        //}

        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="o"></param>
        private void SetBaseInfo(ExtractUnit o)
        {
            //this.UnintID = o.UnintID;// 主键ID
            this.SN = o.SN;// 单元序列
            this.SchemaID = o.SchemaID;// 模式id
            this.TaskID = o.TaskID;// 任务id
            this.DataRows = o.DataRows;// 行数
            this.TargetName = o.TargetName;// 目标名称
            this.MethodName = o.MethodName;// 定义方法名称
            this.BuildType = o.BuildType;// 构建类型
            this.Condition = o.Condition;// 条件字符
            this.Params = o.Params;// 参数字符
        }

    }
}
