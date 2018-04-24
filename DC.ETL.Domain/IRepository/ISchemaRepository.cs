using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Domain.Model;

namespace DC.ETL.Domain
{
    /// <summary>
    /// 数据模式 仓储接口
    /// </summary>
    /// <remarks>
    /// 数据模式 仓储接口
    /// </remarks>
    public interface ISchemaRepository
    {
        /// <summary>
        /// 保存数据源 ds 对应的所有模式
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        int Save(IEnumerable<Schema> schema, DataSource ds);
    }
}
