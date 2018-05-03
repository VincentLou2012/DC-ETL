using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain
{
    /// <summary>
    /// 抽取单元
    /// </summary>
    public partial class ExtractUnit
    {
        //主键ID
        [Key]
        public Guid ID { get; set; }
        //TODO EF映射配置模式id
        public Guid SchemaID{ get; set; }
        //TODO EF映射配置任务id
        public Guid TaskID{ get; set; }
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
        //是否可用
        public int IsEnabled { get; set; }
        //所属模式
        public virtual Schema Schema { get; set; }
        //是否加载数据源信息作为元数据
        public int EnabledDSMetadata { get; set; }
        //是否加载数据模式信息作为元数据
        public int EnabledSchemaMetadata { get; set; }
        //所属任务
        public virtual TaskItem _Task { get; set; }
        //策略集合
        public virtual ICollection<Strategy> Strategies { get; set; }
        //抽取行为
        public virtual ICollection<UnitBehavior> Behaviors { get; set; }
        //加工集合
        public virtual ICollection<Addition> Additions { get; set; }
    }
}
