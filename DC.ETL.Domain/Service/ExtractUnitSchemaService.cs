using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Domain.Specifications;
using System.Linq.Expressions;
using DC.ETL.Domain.Model;
using Microsoft.Practices.Unity;
using DC.ETL.Infrastructure.Container;

namespace DC.ETL.Domain.Service
{
    public class ExtractUnitSchemaService
    {
        /// <summary>
        /// 保存匹配抽取模式
        /// </summary>
        /// <returns>Schema模式集合</returns>
        public int SaveSchema(Guid SNextractUnit, Guid SNschema)
        {
            if (SNextractUnit == null || SNschema == null) return -1;// TODO: 替换标准错误代码
            ExtractUnit extractUnit = new ExtractUnit();
            ExtractUnit extractUnit1 = extractUnit.Get(SNextractUnit);

            Schema schema = new Schema();
            extractUnit1.Schema = schema.Get(SNschema);
            extractUnit1.SchemaID = schema.SchemaID; // 手动同步?
            return extractUnit.Update(extractUnit1);
            //return iExtractUnitRepository.SaveChanges();
        }
    }
}
