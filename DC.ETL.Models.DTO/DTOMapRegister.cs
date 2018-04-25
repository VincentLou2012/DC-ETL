using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DC.ETL.Infrastructure.Utils;
using DC.ETL.Domain.Model;

namespace DC.ETL.Models.DTO
{
    /// <summary>
    /// 注册DTO对象
    /// </summary>
    public class DTOMapRegister
    {
        /// <summary>
        /// 注册DTO对象
        /// </summary>
        static DTOMapRegister()
        {
            AutoMapperUtils.Register<ExtractUnit, ExtractUnitDTO>();// 抽取单元 映射
            AutoMapperUtils.Register<OPRecord, OPRecordDTO>();// 操作记录 映射
            AutoMapperUtils.Register<UnitRcd, UnitRcdDTO>();// 抽取单元记录 映射
            AutoMapperUtils.Register<StructureRcd, StructureRcdDTO>();// 抽取策略记录 映射
            AutoMapperUtils.Register<WholeStructureRcd, WholeStructureRcdDTO>();// 全表数据结构记录 映射
            AutoMapperUtils.Register<DataSourceRcd, DataSourceRcdDTO>();// 数据源记录 映射
            AutoMapperUtils.Register<SchemaRcd, SchemaRcdDTO>();// 数据模式记录 映射
            AutoMapperUtils.Register<TaskRcd, TaskRcdDTO>();// 任务记录 映射
            AutoMapperUtils.Register<WholeStructure, WholeStructureDTO>();// 全表数据结构 映射
            AutoMapperUtils.Register<DataSource, DataSourceDTO>();// 数据源 映射
            AutoMapperUtils.Register<ExtractStructure, ExtractStructureDTO>();// 抽取数据结构 映射
            AutoMapperUtils.Register<Schema, SchemaDTO>();// 数据模式 映射
            AutoMapperUtils.Register<Task, TaskDTO>();// 任务 映射
            AutoMapperUtils.Register<Strategy, StrategyDTO>();// 抽取策略 映射
        }
    }
}
