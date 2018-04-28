using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain
{
    /// <summary>
    /// 任务
    /// </summary>
    public partial class Task
    {
        //任务名称
        public string Name { get; set; }
        //任务描述
        public string Describe { get; set; }
        //备注
        public string Comment { get; set; }
        //方向,主题
        public string Aspect { get; set; }
        //关键词
        public string Keywords { get; set; }
        //单元集合
        public virtual ICollection<ExtractUnit> Units { get; set; }
        //操作记录
        public virtual ICollection<TaskRcd> Records { get; set; } 

        public virtual ICollection<BusinessLib> Subjects { get; set; }
    }
}
