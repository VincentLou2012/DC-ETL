using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Domain.Model;
using DC.ETL.Domain;
using DC.ETL.Domain.Specifications;
using System.Linq.Expressions;
using DC.ETL.Repository.UnitOfWork;
using System.Data.Entity;

namespace DC.ETL.Repository.EFRepository
{
    /// <summary>
    /// 数据模式 仓储实现
    /// </summary>
    public class SchemaRepository : EFRepository<Schema>, ISchemaRepository
    {
        /// <summary>
        /// 保存数据源 ds 所有模式
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        public void UpdateSchema(ICollection<Schema> schemas, DataSource ds)
        {
            foreach (Schema schema in schemas)
            {
                schema.Source = ds;
            }
        }
        /// <summary>
        /// 更新模式对应全表结构
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="wholeStructures"></param>
        public void UpdateWholeStructure(Schema schema, ICollection<WholeStructure> wholeStructures)
        {
            DbSet<WholeStructure> dsWholeStructure = ((EFDbContext)EfContext.EFContext).WholeStructures;
            IQueryable<WholeStructure> delwholeStructures = dsWholeStructure.Where(p => p._Schema.SN == schema.SN);
            foreach (WholeStructure wholeStructure in delwholeStructures)
            {
                dsWholeStructure.Remove(wholeStructure);
            }
            foreach (WholeStructure wholeStructure in wholeStructures)
            {
                wholeStructure._Schema = schema;
                dsWholeStructure.Add(wholeStructure);
            }
        }

        /// <summary>
        /// 获取抽取模式结构
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public Structure GetExtractStructure(Guid SN)
        {
            DbSet<Structure> dsExtractStructure = ((EFDbContext)EfContext.EFContext).ExtractStructures;
            return dsExtractStructure.FirstOrDefault(p=>p.SN == SN);
        }
        /// <summary>
        /// 插入或更新抽取模式结构
        /// </summary>
        /// <param name="extractStructure"></param>
        /// <returns></returns>
        public void UpdateExtractStructure(Structure extractStructure)
        {
            Guid SN = extractStructure.SN;
            EFDbContext context = (EFDbContext)EfContext.EFContext;
            DbSet<Structure> dsExtractStructure = context.ExtractStructures;
            Structure extractStructureInDB = dsExtractStructure.FirstOrDefault(p => p.SN == SN);
            if (extractStructureInDB != null)
                context.Entry(extractStructure).State = EntityState.Modified;
            else
                dsExtractStructure.Add(extractStructure);
        }
    }
}
