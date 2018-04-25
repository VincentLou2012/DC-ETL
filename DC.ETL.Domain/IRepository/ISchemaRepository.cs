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
    public interface ISchemaRepository : IRepository<Schema>
    {
        /// <summary>
        /// 保存数据源 ds 所有模式
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        void UpdateSchema(ICollection<Schema> schemas, DataSource ds);
        /// <summary>
        /// 更新模式对应全表结构
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="wholeStructures"></param>
        void UpdateWholeStructure(Schema schema, ICollection<WholeStructure> wholeStructures);
        /// <summary>
        /// 获取抽取模式结构
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        ExtractStructure GetExtractStructure(Guid SN);
        /// <summary>
        /// 插入或更新抽取模式结构
        /// </summary>
        /// <param name="extractStructure"></param>
        /// <returns></returns>
        void UpdateExtractStructure(ExtractStructure extractStructure);
    }
}
