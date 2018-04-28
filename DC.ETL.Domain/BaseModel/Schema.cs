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
    /// 数据模式
    /// </summary>
    public partial class Schema : IEntity
    {
        #region 数据模式
        [Dependency]
        private ISchemaRepository iSchemaRepository
        {
            get { return Container.Resolve<ISchemaRepository>("SchemaRepository"); }
        }
        #endregion 数据模式
        /// <summary>
        /// 获取单个数据模式
        /// </summary>
        /// <returns></returns>
        public SchemaDTO Get(Guid SN)
        {
            return AutoMapperUtils.MapTo<SchemaDTO>(iSchemaRepository.GetByKey(SN));
        }

        /// <summary>
        /// 获取抽取模式结构
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public ExtractStructureDTO GetExtractStructure(Guid SN)
        {
            return AutoMapperUtils.MapTo<ExtractStructureDTO>(iSchemaRepository.GetExtractStructure(SN));
        }


        ///// <summary>
        ///// 检查抽取结构GUID值
        ///// </summary>
        ///// <returns></returns>
        //private bool IsExtractStructureGuidEqual(Guid SN)
        //{
        //    bool b = false;
        //    if (EStructure == null || EStructure.Count == 0) return b;
        //    foreach (ExtractStructure eStructure in EStructure)
        //    {
        //        if (eStructure.SN == SN)
        //        {
        //            b = true;
        //            break;
        //        }
        //    }
        //    return b;
        //}


        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="o"></param>
        public void SetBaseInfo(Schema o)
        {
            //this.SchemaID = o.SchemaID;// 	模式ID
            this.SN = o.SN;// 	模式序列
            this.DSID = o.DSID;// 	数据源id
            this.SchemaName = o.SchemaName;// 	模式名
            this.Aspect = o.Aspect;// 	方面,主题标识
            this.Keywords = o.Keywords;// 	关键词
            this.Comments = o.Comments;// 	备注
        }
    }
}
