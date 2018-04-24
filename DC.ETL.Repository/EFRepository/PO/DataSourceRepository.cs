using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Domain.Model;
using DC.ETL.Domain;
using DC.ETL.Domain.Specifications;
using System.Linq.Expressions;

namespace DC.ETL.Repository.EFRepository
{
    /// <summary>
    /// 数据源 仓储实现
    /// </summary>
    public class DataSourceRepository : EFRepository<DataSource>, IDataSourceRepository
    {
        /// <summary>
        /// 获取指定数据源所有Schema模式
        /// </summary>
        /// <returns>Schema模式集合</returns>
        public IEnumerable<Schema> GetSchema(Guid SN)
        {
            EnableTrack = false;
            DataSource ds = GetByKey(SN);
            if (ds == null) return null;
            return ds.Schemas;
        }
        /// <summary>
        /// 新增或保存数据源基本信息 不包含Schema模式??
        /// </summary>
        /// <param name="ds">设置ds新值</param>
        public int SaveBaseInfo(DataSource ds)
        {
            if (ds == null) return -1;
            DataSource dsInDB = GetByKey(ds.SN);

            // 源地址

            if(dsInDB == null)
            {
                
                Add(ds);
            }
            else
            {
                dsInDB.SetBaseInfo(ds);
                Update(ds);
            }
            return SaveChanges();
        }

        private void UpdateFields(DataSource dsInDB, DataSource ds)
        {

        }
    }
}
