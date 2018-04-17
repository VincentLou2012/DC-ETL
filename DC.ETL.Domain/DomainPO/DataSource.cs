using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain.Model
{
    /// <summary>
    /// 数据源
    /// </summary>
    public partial class DataSource
    {
        [Key]
        public int DSID { get; set; }
        //数据源名称
        public string DSName { get; set; }
        //数据源类型
        public string DSType { get; set; }
        //源地址
        public string Address { get; set; }
        //实例名
        public string InstanceName { get; set; }
        //端口
        public Nullable<int> Port { get; set; }
        //系统号
        public string SystemNum { get; set; }
        //客户端号
        public string ClientNum { get; set; }
        //系统语言
        public string SysLanguage { get; set; }
        //连接参数
        public string ConnectionParams { get; set; }
        //账户用户名
        public string UserName { get; set; }
        //是否是输出目标数据源
        public int IsTarget { get; set; }
        //账户密码
        public string UserPassword { get; set; }
        //数据源关键词(预留)
        public string Keyword { get; set; }
        //数据源方面(预留)
        public string Aspect { get; set; }
        //数据源描述
        public string Describe { get; set; }
        //操作记录
        public virtual ICollection<DataSourceRcd> Records { get; set; }
        //模式集合
        public virtual ICollection<Schema> Schemas { get; set; }
    }
}
