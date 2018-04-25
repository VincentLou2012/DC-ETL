using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using DC.ETL.Infrastructure.Container;
using DC.ETL.Domain.Specifications;
using System.Linq.Expressions;
using DC.ETL.Infrastructure.Utils;
using DC.ETL.Models.DTO;

namespace DC.ETL.Domain.Model
{
    /// <summary>
    /// 数据源
    /// </summary>
    public partial class DataSource : AggregateRoot
    {

        #region 数据源
        [Dependency]
        private IDataSourceRepository iDataSourceRepository
        {
            get { return Container.Resolve<IDataSourceRepository>("DataSourceRepository"); }
        }
        #endregion 数据源

        /// <summary>
        /// 获取数据源分页列表
        /// 目前只编写了根据数据库名称进行模糊搜索逻辑
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataSourceDTO> GetAll(string DSName, SortOrder sortOrder, int pageNumber, int pageSize)
        {
            Expression<Func<DataSource, bool>> ex = t => t.DSName.Contains(DSName);
            return AutoMapperUtils.MapToList<DataSourceDTO>(iDataSourceRepository.GetAll(new ExpressionSpecification<DataSource>(ex),
                d=>d.SN, sortOrder, pageNumber, pageSize));
        }
        /// <summary>
        /// 获取单个数据源
        /// </summary>
        /// <returns></returns>
        public DataSourceDTO Get(Guid SN)
        {
            return AutoMapperUtils.MapTo<DataSourceDTO>(iDataSourceRepository.GetByKey(SN));
        }
        /// <summary>
        /// 保存数据源基本信息
        /// </summary>
        /// <returns>Schema模式集合</returns>

        public int SaveBaseInfo(DataSource eu)
        {
            if (eu == null) return -1;// TODO: 替换标准错误代码
            DataSource euInDB = iDataSourceRepository.GetByKey(eu.SN);

            if (euInDB == null)
            {
                iDataSourceRepository.Add(eu);
            }
            else
            {
                euInDB.SetBaseInfo(eu);
                iDataSourceRepository.Update(euInDB);
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

    }
}
