using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain.Model
{
    /// <summary>
    /// 操作记录
    /// </summary>
    public class OPRecord
    {
        //记录ID
        [Key]
        public int ID { get; set; }
        //操作者ID
        public string UID { get; set; }
        //操作类型
        public string Optype { get; set; }
        //操作描述
        public string Describe { get; set; }
        //修改时间
        public Nullable<System.DateTime> ModifyDate { get; set; }
    }
}
