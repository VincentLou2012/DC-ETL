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
            CreateMap<OPRecord, OPRecordDTO>();// 操作记录 映射
            CreateMap<UnitRcd, UnitRcdDTO>();// 抽取单元记录 映射
            CreateMap<StructureRcd, StructureRcdDTO>();// 抽取策略记录 映射
            CreateMap<DataSourceRcd, DataSourceRcdDTO>();// 数据源记录 映射
            CreateMap<SchemaRcd, SchemaRcdDTO>();// 数据模式记录 映射
            CreateMap<TaskRcd, TaskRcdDTO>();// 任务记录 映射
            CreateMap<DataSource, DataSourceDTO>();// 数据源 映射
            CreateMap<Structure, ExtractStructureDTO>();// 抽取数据结构 映射
            CreateMap<Schema, SchemaDTO>();// 数据模式 映射
            CreateMap<Task, TaskDTO>();// 任务 映射
            CreateMap<Strategy, StrategyDTO>();// 抽取策略 映射
        }
    }
}
