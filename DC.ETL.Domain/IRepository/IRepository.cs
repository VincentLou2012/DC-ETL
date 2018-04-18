using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DC.ETL.Domain.IRepository
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : class ,IAggregateRoot
    {
        #region 属性
        bool EnableTrack { get; set; }
        #endregion
        int SaveChanges();
        IList<TAggregateRoot> Query(string sql, int pageIndex, int pageSize, out int recordCount);
        IList<TAggregateRoot> QueryAll();
        IList<TAggregateRoot> QueryItems(Expression<Func<TAggregateRoot, bool>> predicate);
        //bool Exists(string code);
        //T Read(string code);
        bool Add(TAggregateRoot entity);
        bool Update(TAggregateRoot entity);
        bool Delete(TAggregateRoot entity);
        //bool Delete(string code);
        int DeleteByKeys(IList<string> keys);
    }
}
