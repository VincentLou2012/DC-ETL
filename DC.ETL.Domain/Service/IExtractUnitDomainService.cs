using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Models.DTO;

namespace DC.ETL.Domain.Service
{
    /// <summary>
    /// 抽取单元领域服务
    /// </summary>
    public interface IExtractUnitDomainService
    {
        /// <summary>
        /// 保存选取的策略
        /// </summary>
        /// <returns>Schema模式集合</returns>
        int SaveStrategy(Guid SNextractUnit, ICollection<Guid> SNStrategies);

        /// <summary>
        /// 保存匹配抽取模式
        /// </summary>
        /// <returns>Schema模式集合</returns>
        int SaveSchema(Guid SNextractUnit, Guid SNschema);
        /// <summary>
        /// 新增或保存抽取单元基本信息 不包含Schema模式和策略??
        /// </summary>
        /// <param name="eu">设置抽取单元新值</param>
        int SaveBaseInfo(ExtractUnitDTO euDTO);
    }
}
