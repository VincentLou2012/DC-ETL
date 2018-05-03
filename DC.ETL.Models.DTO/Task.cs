using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Models.DTO
{
    /// <summary>
    /// 任务
    /// </summary>
    public class TaskDTO
    {
        //任务序列
        public System.Guid ID { get; set; }
        //任务名称
        public string Name { get; set; }
        //任务描述
        public string Describe { get; set; }
        //备注
        public string Comment { get; set; }
        //单元集合
        public virtual ICollection<ExtractUnitDTO> Units { get; set; }
    }
}
