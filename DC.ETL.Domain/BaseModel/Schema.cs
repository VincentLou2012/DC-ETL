using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using DC.ETL.Infrastructure.Container;
using DC.ETL.Domain.Specifications;
using System.Linq.Expressions;

namespace DC.ETL.Domain.Model
{
    /// <summary>
    /// 数据模式
    /// </summary>
    public partial class Schema : AggregateRoot
    {
        #region 数据模式
        [Dependency]
        private ISchemaRepository iSchemaRepository
        {
            get { return Container.Resolve<ISchemaRepository>("SchemaRepository"); }
        }
        #endregion 数据模式

        /// <summary>
        /// 获取单个数据模式
        /// </summary>
        /// <returns></returns>
        public Schema Get(Guid SN)
        {
            return iSchemaRepository.GetByKey(SN);
        }

        /// <summary>
        /// 新增和更新存储模式信息和完整结构
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        public int Save(Schema schema, ICollection<WholeStructure> wholeStructures)
        {
            if (schema == null) return -1;// TODO: 替换标准错误代码
            Schema schemaInDB = iSchemaRepository.GetByKey(schema.SN);

            schema.AStructure = wholeStructures;
            if (schemaInDB == null)
            {
                iSchemaRepository.Add(schema);
            }
            else
            {
                schemaInDB.SetBaseInfo(schema);
                iSchemaRepository.Update(schemaInDB);
            }
            return iSchemaRepository.SaveChanges();
        }
        /// <summary>
        /// 获取抽取模式结构
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public ExtractStructure GetExtractStructure(Guid SN)
        {
            iSchemaRepository.EnableTrack = false;
            Expression<Func<Schema, bool>> ex = t => t.IsExtractStructureGuidEqual(SN);
            Schema schema = iSchemaRepository.GetBySpecification(new ExpressionSpecification<Schema>(ex));
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
            Schema schema = iSchemaRepository.GetBySpecification(new ExpressionSpecification<Schema>(ex));
            if (schema == null) return -1;// TODO: 替换标准错误代码
            schema.EStructure.Clear();
            schema.EStructure.Add(extractStructure);

            return iSchemaRepository.SaveChanges();
        }

        /// <summary>
        /// 检查抽取结构GUID值
        /// </summary>
        /// <returns></returns>
        private bool IsExtractStructureGuidEqual(Guid SN)
        {
            bool b = false;
            if (EStructure == null || EStructure.Count == 0) return b;
            foreach (ExtractStructure eStructure in EStructure)
            {
                if (eStructure.SN == SN)
                {
                    b = true;
                    break;
                }
            }
            return b;
        }


        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="o"></param>
        private void SetBaseInfo(Schema o)
        {
            //this.SchemaID = o.SchemaID;// 	模式ID
            this.SN = o.SN;// 	模式序列
            this.DSID = o.DSID;// 	数据源id
            this.SchemaName = o.SchemaName;// 	模式名
            this.Aspect = o.Aspect;// 	方面,主题标识
            this.Keywords = o.Keywords;// 	关键词
            this.Comments = o.Comments;// 	备注
        }
    }
}
