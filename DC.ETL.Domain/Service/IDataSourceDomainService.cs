using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Models.DTO;

namespace DC.ETL.Domain.Service
{
    /// <summary>
    /// 数据源领域服务
    /// </summary>
    public interface IDataSourceDomainService
    {
        /// <summary>
        /// 从业务平台获取指定数据源所有Schema模式 并存储获取的模式
        /// </summary>
        /// <returns>Schema模式集合</returns>
        IEnumerable<SchemaDTO> GetSchema(Guid SN);

        /// <summary>
        /// 保存数据源基本信息
        /// </summary>
        /// <returns>Schema模式集合</returns>
        int SaveBaseInfo(DataSourceDTO euDTO);

    }
}
