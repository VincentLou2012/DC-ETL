using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain.Model
{
    /// <summary>
    /// 任务
    /// </summary>
    public partial class Task
    {
        [Key]
        public int TaskID { get; set; }
        //任务序列
        public System.Guid SN { get; set; }
        //任务名称
        public string Name { get; set; }
        //任务描述
        public string Describe { get; set; }
        //备注
        public string Comment { get; set; }
        //单元集合
        public virtual ICollection<ExtractUnit> Units { get; set; }
        //操作记录
        public virtual ICollection<TaskRcd> Records { get; set; } 
    }
}
