using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain.Model
{
    /// <summary>
    /// 抽取单元
    /// </summary>
    public partial class ExtractUnit
    {
        //主键ID
        [Key]
        public int UnintID { get; set; }
        //单元序列
        public System.Guid SN { get; set; }
        //模式id
        public int SchemaID { get; set; }
        //任务id
        public int TaskID { get; set; }
        //行数
        public Nullable<int> DataRows { get; set; }
        //目标名称
        public string TargetName { get; set; }
        //定义方法名称
        public string MethodName { get; set; }
        //构建类型
        public string BuildType { get; set; }
        //条件字符
        public string Condition { get; set; }
        //参数字符
        public string Params { get; set; }
        //是否激活
        public int IsEnabled { get; set; }
        //所属模式
        public virtual Schema Schema { get; set; }
        //所属任务
        public virtual Task _Task { get; set; }
        //策略集合
        public virtual ICollection<Strategy> Strategies { get; set; }
        //操作记录
        public virtual ICollection<UnitRcd> Records { get; set; }

    }
}
