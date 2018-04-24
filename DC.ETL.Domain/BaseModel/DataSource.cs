using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain.Model
{
    /// <summary>
    /// 数据源
    /// </summary>
    public partial class DataSource : AggregateRoot
    {

        /// <summary>
        /// 管理平台 获取指定数据源所有Schema模式
        /// </summary>
        /// <returns>Schema模式集合</returns>
        public IEnumerable<Schema> GetSchema(DataSource ds)
        {
            Guid SN = ds.SN;
            // TODO: 这里从Unity获取实例?
            ISchemaRepository isr = null;// Container.Resolve<ISchemaRepository>("SchemaRepository");
            // 从数据源读取模式
            IEnumerable<Schema> schema = ConnectDB(ds);
            if (schema != null)
            {
                isr.Save(schema, ds);
            }
            return schema;
        }
        /// <summary>
        /// 获取单个数据源
        /// </summary>
        /// <returns></returns>
        public DataSource Get(Guid SN)
        {
            // TODO: 这里从Unity获取实例?
            IRepository<DataSource> itr = null;// Container.Resolve<IRepository<DataSource>>("DataSourceRepository");
            return itr.GetByKey(SN);
        }
        /// <summary>
        /// 管理平台 修改数据源基本信息
        /// </summary>
        /// <returns>Schema模式集合</returns>
        public int SaveBaseInfo(DataSource ds)
        {
            Guid SN = ds.SN;
            // TODO: 这里从Unity获取实例?
            IDataSourceRepository isr = null;// Container.Resolve<IDataSourceRepository>("DataSourceRepository");
            return isr.SaveBaseInfo(ds);
        }

        public void SetBaseInfo(DataSource ds)
        {
            this.DSID = ds.DSID;// 数据源主键
            this.DSName = ds.DSName;// 数据源名称
            this.DSType = ds.DSType;// 数据源类型
            this.Address = ds.Address;// 源地址
            this.InstanceName = ds.InstanceName;// 实例名
            this.Port = ds.Port;// 端口
            this.SystemNum = ds.SystemNum;// 系统号
            this.ClientNum = ds.ClientNum;// 客户端号
            this.SysLanguage = ds.SysLanguage;// 系统语言
            this.ConnectionParams = ds.ConnectionParams;// 连接参数
            this.UserName = ds.UserName;// 账户用户名
            this.IsTarget = ds.IsTarget;// 是否是输出目标数据源
            this.UserPassword = ds.UserPassword;// 账户密码
            this.Keyword = ds.Keyword;// 数据源关键词(预留)
            this.Aspect = ds.Aspect;// 数据源方面(预留)
            this.Describe = ds.Describe;// 数据源描述
        }

        // TODO: 数据源验证
        private bool Validate()
        {
            return false;
        }

        // TODO: 数据源模式获取
        private IEnumerable<Schema> ConnectDB(DataSource ds)
        {
            return null;
        }
    }
}
