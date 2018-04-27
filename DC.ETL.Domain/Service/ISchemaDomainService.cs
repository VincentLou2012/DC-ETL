using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Models.DTO;

namespace DC.ETL.Domain.Service
{
    /// <summary>
    /// 模式领域服务接口
    /// </summary>
    public interface ISchemaDomainService
    {
        /// <summary>
        /// 新增和更新存储模式信息和完整结构
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        int Save(SchemaDTO schemaDTO, ICollection<WholeStructureDTO> wholeStructuresDTO);
        /// <summary>
        /// 保存抽取模式结构
        /// </summary>
        /// <param name="exDTO"></param>
        /// <returns></returns>
        int SaveExtractStructure(ExtractStructureDTO exDTO);
    }
}
