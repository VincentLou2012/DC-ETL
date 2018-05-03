using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Domain;
using DC.ETL.Domain;
using DC.ETL.Domain.Specifications;
using System.Linq.Expressions;

namespace DC.ETL.Repository.EFRepository
{
    /// <summary>
    /// 数据源 仓储实现
    /// </summary>
    public class DataSourceRepository : EFRepository<DataSource>, IDataSourceRepository
    {

    }
}
