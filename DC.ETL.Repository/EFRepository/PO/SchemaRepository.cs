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
    /// 数据模式 仓储实现
    /// </summary>
    public class SchemaRepository : EFRepository<Schema>, ISchemaRepository
    {
        /// <summary>
        /// 保存数据源 ds 对应的所有模式
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int Save(IEnumerable<Schema> schema, DataSource ds)
        {
            throw new NotImplementedException();
        }
    }
}
