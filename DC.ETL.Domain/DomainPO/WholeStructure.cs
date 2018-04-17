using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain.Model
{
    public partial class WholeStructure
    {
        [Key]
        public int StructureID { get; set; }
        //全结构序列
        public System.Guid SN { get; set; } 
        //数据模式id
        public int SchemaID { get; set; }
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
        //操作记录
        public virtual ICollection<StructureRcd> Records { get; set; }
        //所属模式
        public virtual Schema _Schema { get; set; }
    }
}
