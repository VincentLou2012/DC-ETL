using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Models.DTO
{
    /// <summary>
    /// 数据结构
    /// </summary>
    public class StructureDTO
    {
        public Guid ID { get; set; }
        //数据模式id
        public Guid SchemaID { get; set; }
        //字段名称
        public string FieldName { get; set; }
        //字段显示名称
        public string DisplayName { get; set; }
        //字段类型
        public string FieldType { get; set; }
        //是否主键
        public Nullable<int> IsPrimary { get; set; }
        //是否索引
        public Nullable<int> IsIndex { get; set; }
        //字段描述
        public string Describe { get; set; }
        //相关备注
        public string Comments { get; set; }
        //所属模式
        public virtual SchemaDTO _Schema { get; set; }

    }
}
