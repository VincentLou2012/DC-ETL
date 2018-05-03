using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using DC.ETL.Infrastructure.Container;
using DC.ETL.Domain.Specifications;
using System.Linq.Expressions;
using DC.ETL.Infrastructure.Utils;
using DC.ETL.Models.DTO;

namespace DC.ETL.Domain
{
    /// <summary>
    /// 抽取单元
    /// </summary>
    public partial class ExtractUnit : IEntity
    {

        #region 抽取单元
        
        private IExtractUnitRepository iExtractUnitRepository
        {
            get { return Container.Resolve<IExtractUnitRepository>("ExtractUnitRepository"); }
        }
        #endregion 抽取单元

        /// <summary>
        /// 获取单个抽取单元
        /// </summary>
        /// <returns></returns>
        public ExtractUnitDTO Get(Guid SN)
        {
            return AutoMapperUtils.MapTo<ExtractUnitDTO>(iExtractUnitRepository.GetByKey(SN));
        }


        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="o"></param>
        public void SetBaseInfo(ExtractUnitDTO o)
        {
            //this.UnintID = o.UnintID;// 主键ID
            this.SN = o.SN;// 单元序列
            this.SchemaSN = o.SchemaSN;// 模式id
            this.TaskSN= o.TaskSN;// 任务id
            this.DataRows = o.DataRows;// 行数
            this.TargetName = o.TargetName;// 目标名称
            this.MethodName = o.MethodName;// 定义方法名称
            this.BuildType = o.BuildType;// 构建类型
            this.Condition = o.Condition;// 条件字符
            this.Params = o.Params;// 参数字符
        }

    }
}
