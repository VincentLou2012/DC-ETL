using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain
{
    /// <summary>
    /// 数据模式
    /// </summary>
    public partial class Schema
    {
        [Key]
        public Guid ID{ get; set; }
        //TODO EF映射数据源SN
        public Guid DSID { get; set; }
        //模式名
        public string SchemaName { get; set; }
        //显示名
        public string DisplayName { get; set; }
        //方面,主题标识
        public string Aspect { get; set; }
        //关键词
        public string Keywords { get; set; } 
        //备注
        public string Comments { get; set; }
        //所属数据源
        public virtual DataSource Source { get; set; }
        //抽取表结构
        public virtual ICollection<Structure> Fields { get; set; }
        //对应抽取单元集合，原则上一个结构对应一个抽取单元
        public virtual ICollection<ExtractUnit> Units { get; set; }
    }
}
