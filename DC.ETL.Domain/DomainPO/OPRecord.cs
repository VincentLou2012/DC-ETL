using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain
{
    /// <summary>
    /// 操作记录
    /// </summary>
    public partial class OPRecord
    {
        /// <summary>
        /// 记录ID
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// 操作者ID
        /// </summary>
        public string UID { get; set; }
        /// <summary>
        /// 操作类型<see cref="Optype"/>
        /// </summary>
        public int Optype { get; set; }
        /// <summary>
        /// 操作描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public Nullable<System.DateTime> ModifyDate { get; set; }
    }
}
