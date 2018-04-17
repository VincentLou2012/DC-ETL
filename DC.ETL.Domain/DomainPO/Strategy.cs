using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain.Model
{
    /// <summary>
    /// 抽取策略
    /// </summary>
    public partial class Strategy
    {
        [Key]
        public int StrategyID { get; set; }
        //策略序列
        public System.Guid SN { get; set; }
        //策略类型,逻辑中枚举
        public Nullable<int> StrategyType { get; set; }
        //是否重复
        public int IsRepeet { get; set; }
        //重复次数,0为无限,-1为不重复
        public Nullable<int> RepeatCount { get; set; }
        //重复间隔
        public Nullable<int> Interval { get; set; }
        //周天
        public string Days { get; set; }
        //定时小时
        public Nullable<int> TimeHour { get; set; }
        //定时分钟
        public Nullable<int> TimeMinute { get; set; }
        //开始时间
        public Nullable<System.DateTime> StartDate { get; set; }
        //备注
        public string Comment { get; set; }
        //预留一个整型
        public Nullable<int> ReservedInt { get; set; }
        //预留一个字符型
        public string ReservedStr { get; set; }
        //相关单元
        public virtual ICollection<ExtractUnit> Units { get; set; }
    }
}
