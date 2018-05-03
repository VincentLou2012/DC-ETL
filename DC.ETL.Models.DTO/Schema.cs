using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Models.DTO
{
    /// <summary>
    /// 数据模式
    /// </summary>
    public class SchemaDTO
    {
        //模式序列
        public System.Guid ID{ get; set; }
        //数据源id
        public Guid DSID { get; set; }
        //模式名
        public string SchemaName { get; set; }
        //方面,主题标识
        public string Aspect { get; set; }
        //关键词
        public string Keywords { get; set; } 
        //备注
        public string Comments { get; set; }
        //所属数据源
        public virtual DataSourceDTO Source { get; set; }
        //抽取表结构
        public virtual ICollection<StructureDTO> EStructure { get; set; }
        //对应抽取单元集合，原则上一个结构对应一个抽取单元
        public virtual ICollection<ExtractUnitDTO> Units { get; set; }
    }
}
