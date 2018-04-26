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
using DC.ETL.Infrastructure.Utils;
using DC.ETL.Models.DTO;

namespace DC.ETL.Domain.Service
{
    public class SchemaDomainService : ISchemaDomainService
    {
        #region 数据模式
        [Dependency]
        private ISchemaRepository iSchemaRepository
        {
            get { return Container.Resolve<ISchemaRepository>("SchemaRepository"); }
        }
        #endregion 数据模式

        #region 操作记录
        [Dependency]
        private IOPRecordRepository iOPRecordRepository
        {
            get { return Container.Resolve<IOPRecordRepository>("OPRecordRepository"); }
        }
        #endregion 操作记录


        /// <summary>
        /// 新增和更新存储模式信息和完整结构
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        public int Save(SchemaDTO schemaDTO, ICollection<WholeStructureDTO> wholeStructuresDTO)
        {
            if (schemaDTO == null) return -1;// TODO: 替换标准错误代码
            Schema schema = AutoMapperUtils.MapTo<Schema>(schemaDTO);
            List<WholeStructure> wholeStructures = AutoMapperUtils.MapToList<WholeStructure>(wholeStructuresDTO);
            Schema schemaInDB = iSchemaRepository.GetByKey(schema.SN);

            EOptype eop = EOptype.Update;
            if (schemaInDB == null)
            {
                eop = EOptype.Add;
                schema.AStructure = wholeStructures;
                iSchemaRepository.Add(schema);
            }
            else
            {
                schemaInDB.SetBaseInfo(schema);
                iSchemaRepository.Update(schemaInDB);
                iSchemaRepository.UpdateWholeStructure(schemaInDB, wholeStructures);
            }
            int nRet = iSchemaRepository.SaveChanges();

            // 新增操作记录
            SchemaRcd exRcd = new SchemaRcd(nRet, schemaInDB, eop);
            iOPRecordRepository.Add(exRcd);
            int nOpRet = iOPRecordRepository.SaveChanges();
            return nRet;
        }

        /// <summary>
        /// 保存抽取模式结构
        /// </summary>
        /// <param name="exDTO"></param>
        /// <returns></returns>
        public int SaveExtractStructure(ExtractStructureDTO exDTO)
        {
            if (exDTO == null) return -1;// TODO: 替换标准错误代码
            ExtractStructure extractStructure = AutoMapperUtils.MapTo<ExtractStructure>(exDTO);
            iSchemaRepository.UpdateExtractStructure(extractStructure);
            EOptype eop = EOptype.Update;

            int nRet = iSchemaRepository.SaveChanges();

            // 新增操作记录
            StructureRcd exRcd = new StructureRcd(nRet, extractStructure, eop);
            iOPRecordRepository.Add(exRcd);
            int nOpRet = iOPRecordRepository.SaveChanges();
            return nRet;
        }
    }
}
