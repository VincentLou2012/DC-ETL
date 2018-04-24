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
    /// 抽取单元
    /// </summary>
    public partial class ExtractUnit : AggregateRoot
    {
        [Dependency]
        private readonly IExtractUnitRepository iExtractUnitRepository
        {
            get { return Container.Resolve<IExtractUnitRepository>("ExtractUnitRepository"); }
        }
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
            if (eu == null) return -1;
            ExtractUnit euInDB = iExtractUnitRepository.GetByKey(eu.SN);

            if (euInDB == null)
            {
                iExtractUnitRepository.Add(eu);
            }
            else
            {
                euInDB.SetBaseInfo(eu);
                iExtractUnitRepository.Update(eu);
            }
            return iExtractUnitRepository.SaveChanges();
        }

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
        /// <summary>
        /// TODO: 匹配抽取模式
        /// </summary>
        /// <returns>Schema模式集合</returns>
        public int Schema(ExtractUnit extractUnit)
        {
            return iExtractUnitRepository.SaveBaseInfo(extractUnit);
        }
        /// <summary>
        /// TODO: 选取策略
        /// </summary>
        /// <returns>Schema模式集合</returns>
        public int Strategy(ExtractUnit extractUnit)
        {
            return iExtractUnitRepository.SaveBaseInfo(extractUnit);
        }
    }
}
