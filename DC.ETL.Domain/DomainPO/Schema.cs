using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain.Model
{
    /// <summary>
    /// 数据模式
    /// </summary>
    public partial class Schema
    {
        [Key]
        public int SchemaID { get; set; }
        //模式序列
        public System.Guid SN{ get; set; }
        //数据源id
        public int DSID { get; set; }
        //模式名
        public string SchemaName { get; set; }
        //方面,主题标识
        public string Aspect { get; set; }
        //关键词
        public string Keywords { get; set; } 
        //备注
        public string Comments { get; set; }
        //所属数据源
        public virtual DataSource Source { get; set; }
        //操作记录
        public virtual ICollection<SchemaRcd> Records { get; set; }
        //全表结构
        public virtual ICollection<WholeStructure> AStructure { get; set; }
        //抽取表结构
        public virtual ICollection<ExtractStructure> EStructure { get; set; }
        //对应抽取单元集合，原则上一个结构对应一个抽取单元
        public virtual ICollection<ExtractUnit> Units { get; set; }
    }
}
