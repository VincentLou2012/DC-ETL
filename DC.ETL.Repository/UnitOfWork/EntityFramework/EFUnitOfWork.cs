using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DC.ETL.Domain;
using Microsoft.Practices.Unity;

namespace DC.ETL.Repository.UnitOfWork
{
    public class EFUnitOfWork : IEFUnitOfWork
    {
        #region 属性
        //线程本地存储EF上下文对象
        private readonly ThreadLocal<EFDbContext> _context;

        //通过工作单元向外暴露的EF上下文对象
        public DbContext EFContext { get { return _context.Value; } }
        #endregion

        #region 构造函数
        public EFUnitOfWork()
        {
            //ThreadLocal变量，使得每个线程都会一个拷贝，从而避免了线程同步带来的性能开销
            _context = new ThreadLocal<EFDbContext>(() => new EFDbContext());
        }
        #endregion

        #region IUnitOfWorkRepositoryContext接口实现
        public void RegisterNew<TAggregateRoot>(TAggregateRoot obj) where TAggregateRoot :class , IAggregateRoot
        {
            var state = EFContext.Entry(obj).State;
            if (state == EntityState.Detached)
            {
                EFContext.Entry(obj).State = EntityState.Added;
            }
            IsCommitted = false;
        }

        public void RegisterModified<TAggregateRoot>(TAggregateRoot obj) where TAggregateRoot :class,IAggregateRoot
        {
            if (EFContext.Entry(obj).State == EntityState.Detached)
            {
                EFContext.Set<TAggregateRoot>().Attach(obj);
            }
            EFContext.Entry(obj).State = EntityState.Modified;
            IsCommitted = false;
        }

        public void RegisterDeleted<TAggregateRoot>(TAggregateRoot obj) where TAggregateRoot : class, IAggregateRoot
        {
            //聚合根暂不支持删除，换做启用和未启用
            //EFContext.Entry(obj).State = EntityState.Deleted;
            EFContext.Entry(obj).Entity.IsEnabled = 0;
            EFContext.Entry(obj).State = EntityState.Modified;
            IsCommitted = false;
        }
        #endregion

        #region IUnitOfWork接口实现

        public bool IsCommitted { get; set; }
        public bool IsRollback { get; set; }
        public int Commit()
        {
            if (IsCommitted)
            {
                return 0;
            }
            var validationError = EFContext.GetValidationErrors();
            if (validationError.Count() > 0)
            {
                Rollback();
                return 0;
            }
            try
            {
                int result = EFContext.SaveChanges();
                IsCommitted = true;
                return result;
            }
            catch (DbUpdateException e)
            {

                throw e;
            }
        }

        public void Rollback()
        {
            IsRollback = IsCommitted = true;
        }
        #endregion

        #region IDisposable接口实现
        public void Dispose()
        {
            if (!IsCommitted)
            {
                Commit();
            }
            EFContext.Dispose();
        }
        #endregion
    }
}
