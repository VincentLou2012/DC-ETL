using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Models.DTO;
using System.Data;
namespace DC.ETL.Domain.Service
{
    public interface IDomainService
    {
        #region Command

        #region 数据源领域
        DataSource CreateDataSource(DataSourceDTO dto);

        void ChangeDataSource(DataSourceDTO dto);

        void RemoveDataSource(Guid ID);

        void ChangeSchemaInfo(Guid DSID, SchemaDTO Schema);

        void ChangeStructureInfo(Guid DSID, Guid SchemaID, StructureDTO StructureDTO);

        //TODO 数据源迁移适配场景，数据源发生迁移，因而更新连接参数，需验证模式，结构，数据一致。
        #endregion

        #region 任务领域

        #endregion

        #region 策略领域

        #endregion

        #region 业务库领域

        #endregion

        #endregion

        #region Query

        #region 数据源领域

        #endregion

        #region 任务领域

        #endregion

        #region 策略领域

        #endregion

        #region 业务库领域

        #endregion

        #endregion
    }
}
