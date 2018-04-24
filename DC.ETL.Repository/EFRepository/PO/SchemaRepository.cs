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
        /// 保存数据源 ds 所有模式
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        public int Save(ICollection<Schema> schemas, DataSource ds)
        {
            foreach (Schema schema in schemas)
            {
                schema.Source = ds;
            }
            return SaveChanges();
        }
        /// <summary>
        /// 存储模式信息和完整结构
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="wholeStructures"></param>
        /// <returns></returns>
        public int Save(Schema schema, ICollection<WholeStructure> wholeStructures)
        {
            schema.AStructure = wholeStructures;
            Update(schema);
            return SaveChanges();
        }
        /// <summary>
        /// 获取抽取模式结构
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public ExtractStructure GetExtractStructure(Guid SN)
        {
            EnableTrack = false;
            Expression<Func<Schema, bool>> ex = t => t.IsExtractStructureGuidEqual(SN);
            Schema schema = GetBySpecification(new ExpressionSpecification<Schema>(ex));
            ICollection<ExtractStructure> extractStructures = schema.EStructure;
            if (extractStructures == null) return null;
            if (extractStructures.Count == 1) return extractStructures.ToArray()[0];
            throw new Exception("one SN map more than one record.");
        }
        /// <summary>
        /// 保存抽取模式结构
        /// </summary>
        /// <param name="extractStructure"></param>
        /// <returns></returns>
        public int SaveExtractStructure(ExtractStructure extractStructure)
        {
            Guid SN = extractStructure.SN;
            Expression<Func<Schema, bool>> ex = t => t.IsExtractStructureGuidEqual(SN);
            Schema schema = GetBySpecification(new ExpressionSpecification<Schema>(ex));

            schema.EStructure.Clear();
            schema.EStructure.Add(extractStructure);

            return SaveChanges();
        }
    }
}
