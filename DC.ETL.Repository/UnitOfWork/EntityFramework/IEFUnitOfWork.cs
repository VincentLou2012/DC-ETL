using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DC.ETL.Domain;

namespace DC.ETL.Repository.UnitOfWork
{
    /// <summary>
    /// 定义EF工作单元接口，表示EF工作单元含有DbContext。
    /// </summary>
    public interface IEFUnitOfWork : IUnitOfWorkRepositoryContext
    {
        DbContext EFContext { get; }
    }
}
