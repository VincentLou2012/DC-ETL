using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Domain.Model;

namespace DC.ETL.Domain
{
    /// <summary>
    /// 数据源 仓储接口
    /// </summary>
    /// <remarks>
    /// 数据源 仓储接口
    /// </remarks>
    public interface IDataSourceRepository : IRepository<DataSource>
    {
        /// <summary>
        /// 获取指定数据源所有Schema模式
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        IEnumerable<Schema> GetSchema(Guid SN);

    }
}
