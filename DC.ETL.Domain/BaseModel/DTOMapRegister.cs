using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DC.ETL.Infrastructure.Utils;
using DC.ETL.Models.DTO;
using AutoMapper;

namespace DC.ETL.Domain
{
    /// <summary>
    /// 注册DTO对象 在启动时运行
    /// </summary>
    public class MappingProfile : Profile 
    {
        /// <summary>
        /// 注册DTO对象
        /// </summary>
        public MappingProfile()
        {
            CreateMap<ExtractUnit, ExtractUnitDTO>();// 抽取单元 映射
            CreateMap<DataSource, DataSourceDTO>();// 数据源 映射
            CreateMap<Structure, StructureDTO>();// 抽取数据结构 映射
            CreateMap<Schema, SchemaDTO>();// 数据模式 映射
            CreateMap<TaskItem, TaskDTO>();// 任务 映射
            CreateMap<Strategy, StrategyDTO>();// 抽取策略 映射
        }
    }
}
