using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DC.ETL.Domain.Model;

namespace DC.ETL.Repository.UnitOfWork
{
    public class EFDbContext : DbContext
    {
        public EFDbContext()
           : base("name=ETLDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }


        /// <summary>
        /// 抽取单元
        /// </summary>
        public DbSet<ExtractUnit> ExtractUnits { get; set; }

        /// <summary>
        /// 数据源
        /// </summary>
        public DbSet<DataSource> DataSources { get; set; }

        /// <summary>
        /// 数据源记录
        /// </summary>
        public DbSet<DataSourceRcd> DataSourceRcds { get; set; }

        /// <summary>
        /// 抽取数据结构
        /// </summary>
        public DbSet<ExtractStructure> ExtractStructures { get; set; }

        /// <summary>
        /// 操作记录
        /// </summary>
        public DbSet<OPRecord> OPRecords { get; set; }

        /// <summary>
        /// 数据模式
        /// </summary>
        public DbSet<Schema> Schemas { get; set; }

        /// <summary>
        /// 数据模式记录
        /// </summary>
        public DbSet<SchemaRcd> SchemaRcds { get; set; }

        /// <summary>
        /// 抽取策略
        /// </summary>
        public DbSet<Strategy> Strategys { get; set; }

        /// <summary>
        /// 抽取策略记录
        /// </summary>
        public DbSet<StructureRcd> StructureRcds { get; set; }

        /// <summary>
        /// 任务
        /// </summary>
        public DbSet<DC.ETL.Domain.Model.Task> Tasks { get; set; }

        /// <summary>
        /// 任务记录
        /// </summary>
        public DbSet<TaskRcd> TaskRcds { get; set; }

        /// <summary>
        /// 抽取单元记录
        /// </summary>
        public DbSet<UnitRcd> UnitRcds { get; set; }

        /// <summary>
        /// 全表数据结构
        /// </summary>
        public DbSet<WholeStructure> WholeStructures { get; set; }

        /// <summary>
        /// 全表数据结构记录
        /// </summary>
        public DbSet<WholeStructureRcd> WholeStructureRcds { get; set; }
    }
}
