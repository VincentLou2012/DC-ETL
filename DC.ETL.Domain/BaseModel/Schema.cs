using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using DC.ETL.Infrastructure.Container;

namespace DC.ETL.Domain.Model
{
    /// <summary>
    /// 数据模式
    /// </summary>
    public partial class Schema : AggregateRoot
    {
        [Dependency]
        private readonly ISchemaRepository iSchemaRepository
        {
            get { return Container.Resolve<ISchemaRepository>("SchemaRepository"); }
        }

        /// <summary>
        /// 获取单个数据模式
        /// </summary>
        /// <returns></returns>
        public Schema Get(Guid SN)
        {
            return iSchemaRepository.GetByKey(SN);
        }

        /// <summary>
        /// 存储模式信息和完整结构
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        public int Save(Schema schema, ICollection<WholeStructure> wholeStructures)
        {
            return iSchemaRepository.Save(schema, wholeStructures);
        }

        /// <summary>
        /// 检查抽取结构GUID值
        /// </summary>
        /// <returns></returns>
        public bool IsExtractStructureGuidEqual(Guid SN)
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
    }
}
