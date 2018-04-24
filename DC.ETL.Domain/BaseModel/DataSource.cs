﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using DC.ETL.Infrastructure.Container;

namespace DC.ETL.Domain.Model
{
    /// <summary>
    /// 数据源
    /// </summary>
    public partial class DataSource : AggregateRoot
    {
        [Dependency]
        private readonly ISchemaRepository iSchemaRepository
        {
            get { return Container.Resolve<ISchemaRepository>("SchemaRepository"); }
        }
        [Dependency]
        private readonly IDataSourceRepository iDataSourceRepository
        {
            get { return Container.Resolve<IDataSourceRepository>("DataSourceRepository"); }
        }
        /// <summary>
        /// 管理平台 从业务平台获取指定数据源所有Schema模式
        /// </summary>
        /// <returns>Schema模式集合</returns>
        public IEnumerable<Schema> GetSchema(Guid SN)
        {
            DataSource ds = Get(SN);
            // 从数据源读取模式
            IEnumerable<Schema> schema = ConnectDB(ds);
            if (schema != null)
            {
                iSchemaRepository.Save(schema, ds);
            }
            return schema;
        }
        /// <summary>
        /// 获取单个数据源
        /// </summary>
        /// <returns></returns>
        public DataSource Get(Guid SN)
        {
            return iDataSourceRepository.GetByKey(SN);
        }
        /// <summary>
        /// 管理平台 保存数据源基本信息
        /// </summary>
        /// <returns>Schema模式集合</returns>

        public int SaveBaseInfo(DataSource eu)
        {
            if (eu == null) return -1;
            DataSource euInDB = iDataSourceRepository.GetByKey(eu.SN);

            if (euInDB == null)
            {
                iDataSourceRepository.Add(eu);
            }
            else
            {
                euInDB.SetBaseInfo(eu);
                iDataSourceRepository.Update(eu);
            }
            return iDataSourceRepository.SaveChanges();
        }

        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="o"></param>
        private void SetBaseInfo(DataSource o)
        {
            //this.DSID = ds.DSID;// 数据源主键
            this.DSName = o.DSName;// 数据源名称
            this.DSType = o.DSType;// 数据源类型
            this.Address = o.Address;// 源地址
            this.InstanceName = o.InstanceName;// 实例名
            this.Port = o.Port;// 端口
            this.SystemNum = o.SystemNum;// 系统号
            this.ClientNum = o.ClientNum;// 客户端号
            this.SysLanguage = o.SysLanguage;// 系统语言
            this.ConnectionParams = o.ConnectionParams;// 连接参数
            this.UserName = o.UserName;// 账户用户名
            this.IsTarget = o.IsTarget;// 是否是输出目标数据源
            this.UserPassword = o.UserPassword;// 账户密码
            this.Keyword = o.Keyword;// 数据源关键词(预留)
            this.Aspect = o.Aspect;// 数据源方面(预留)
            this.Describe = o.Describe;// 数据源描述
        }

        // TODO: 数据源验证
        private bool Validate()
        {
            return false;
        }

        // TODO: 数据源模式获取
        private IEnumerable<Schema> ConnectDB(DataSource ds)
        {
            if (Validate())
                return null;

            return null;
        }
    }
}
