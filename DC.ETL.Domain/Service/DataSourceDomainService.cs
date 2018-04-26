using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Domain.Specifications;
using System.Linq.Expressions;
using DC.ETL.Domain.Model;
using Microsoft.Practices.Unity;
using DC.ETL.Infrastructure.Container;
using DC.ETL.Infrastructure.Utils;
using DC.ETL.Models.DTO;

namespace DC.ETL.Domain.Service
{
    public class DataSourceDomainService : IDataSourceDomainService
    {
        #region 数据源
        [Dependency]
        private IDataSourceRepository iDataSourceRepository
        {
            get { return Container.Resolve<IDataSourceRepository>("DataSourceRepository"); }
        }
        #endregion 数据源

        #region 数据模式
        [Dependency]
        private ISchemaRepository iSchemaRepository
        {
            get { return Container.Resolve<ISchemaRepository>("SchemaRepository"); }
        }
        #endregion 数据模式

        #region 操作记录
        [Dependency]
        private IOPRecordRepository iOPRecordRepository
        {
            get { return Container.Resolve<IOPRecordRepository>("OPRecordRepository"); }
        }
        #endregion 操作记录
        /// <summary>
        /// 从业务平台获取指定数据源所有Schema模式 并存储获取的模式
        /// </summary>
        /// <returns>Schema模式集合</returns>
        public IEnumerable<SchemaDTO> GetSchema(Guid SN)
        {
            DataSource ds = iDataSourceRepository.GetByKey(SN);
            // 从数据源读取模式
            ICollection<Schema> schema = ConnectDB(ds);
            if (schema == null)
                return null;
            iSchemaRepository.UpdateSchema(schema, ds);
            iSchemaRepository.SaveChanges();
            return AutoMapperUtils.MapToList<SchemaDTO>(schema);
        }

        /// <summary>
        /// 保存数据源基本信息
        /// </summary>
        /// <returns>Schema模式集合</returns>
        public int SaveBaseInfo(DataSource eu)
        {
            if (eu == null) return -1;// TODO: 替换标准错误代码
            DataSource euInDB = iDataSourceRepository.GetByKey(eu.SN);

            EOptype eop = EOptype.Update;
            if (euInDB == null)
            {
                eop = EOptype.Add;
                iDataSourceRepository.Add(eu);
            }
            else
            {
                euInDB.SetBaseInfo(eu);
                iDataSourceRepository.Update(euInDB);
            }
            int nRet = iDataSourceRepository.SaveChanges();

            // 新增操作记录
            DataSourceRcd dsRcd = new DataSourceRcd(nRet, euInDB, eop);
            iOPRecordRepository.Add(dsRcd);
            int nOpRet = iOPRecordRepository.SaveChanges();
            return nRet;
        }

        // TODO: 数据源验证
        private bool Validate()
        {
            return false;
        }

        // TODO: 数据源模式获取
        private ICollection<Schema> ConnectDB(DataSource ds)
        {
            if (Validate())
                return null;

            return null;
        }
    }
}
