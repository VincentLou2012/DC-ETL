using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Models.DTO
{
    /// <summary>
    /// 抽取单元
    /// </summary>
    public class ExtractUnitDTO
    {
        //单元序列
        public System.Guid ID { get; set; }
        //模式id
        public Guid SchemaID { get; set; }
        //任务id
        public Guid TaskID { get; set; }
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
        //所属模式
        public virtual SchemaDTO Schema { get; set; }
        //所属任务
        public virtual TaskDTO _Task { get; set; }
        //策略集合
        public virtual ICollection<StrategyDTO> Strategies { get; set; }

    }
}
