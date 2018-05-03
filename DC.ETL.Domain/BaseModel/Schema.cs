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
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="o"></param>
        public void SetSchemaInfo(Schema o)
        {
            //this.SchemaID = o.SchemaID;// 	模式ID
            this.ID = o.ID;// 	模式序列
            this.DSID = o.DSID;// 	数据源id
            this.SchemaName = o.SchemaName;// 	模式名
            this.Aspect = o.Aspect;// 	方面,主题标识
            this.Keywords = o.Keywords;// 	关键词
            this.Comments = o.Comments;// 	备注
        }
    }
}
