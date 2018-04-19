using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Infrastructure;
using DC.ETL.Infrastructure.Container;
using DC.ETL.Domain;
using DC.ETL.Domain.Specifications;
using DC.ETL.Repository.UnitOfWork;
namespace DC.ETL.Repository.EFRepository
{
    public abstract class EFRepository<TAggregateRoot> : IRepository<TAggregateRoot> where TAggregateRoot : class , IAggregateRoot
    {
        #region 私有只读字段
        private readonly  IEFUnitOfWork _efContext;
        #endregion

        #region 属性
        /// <summary>
        /// 抛出EF工作单元对象供派生类访问
        /// </summary>
        protected IEFUnitOfWork EfContext
        {
            get { return this._efContext; }
        }

        /// <summary>
        /// 查询是否可追踪,在派生类中定义
        /// </summary>
        public bool EnableTrack
        {
            get;
            set;
        }

        #endregion


        protected EFRepository()
        {
            //EF仓储与EF工作单元耦合,从IOC容器获取IEFUnitOfWork对象
            this._efContext=Container.Resolve<IEFUnitOfWork>("EFUnitOfWork");
        }

        #region 处理方法
        private MemberExpression GetMemberInfo(LambdaExpression lambda)
        {
            if (lambda == null)
                throw new ArgumentNullException("lambda");

            MemberExpression memberExpr = null;

            switch (lambda.Body.NodeType)
            {
                case ExpressionType.Convert:
                    memberExpr =
                        ((UnaryExpression)lambda.Body).Operand as MemberExpression;
                    break;
                case ExpressionType.MemberAccess:
                    memberExpr = lambda.Body as MemberExpression;
                    break;
            }

            if (memberExpr == null)
                throw new ArgumentException("method");

            return memberExpr;
        }

        private string GetEagerLoadingPath(Expression<Func<TAggregateRoot, dynamic>> eagerLoadingProperty)
        {
            var memberExpression = this.GetMemberInfo(eagerLoadingProperty);
            var parameterName = eagerLoadingProperty.Parameters.First().Name;
            var memberExpressionStr = memberExpression.ToString();
            var path = memberExpressionStr.Replace(parameterName + ".", "");
            return path;
        }

        #endregion

        #region Command
        public int SaveChanges()
        {
            return this._efContext.Commit();
        }




        public void Add(TAggregateRoot aggregateRoot)
        {
            // 调用IEntityFrameworkRepositoryContext的RegisterNew方法将实体添加进EFContextt.DbSet对象中
            _efContext.RegisterNew(aggregateRoot);
        }

        public void Remove(TAggregateRoot aggregateRoot)
        {
            _efContext.RegisterDeleted(aggregateRoot);
        }

        public void Update(TAggregateRoot aggregateRoot)
        {
            _efContext.RegisterModified(aggregateRoot);
        }
        #endregion

        #region Query

        public TAggregateRoot GetByKey(Guid key)
        {
            return _efContext.EFContext.Set<TAggregateRoot>().First(a => a.SN == key);
        }

        public TAggregateRoot GetBySpecification(ISpecification<TAggregateRoot> spec)
        {
            return _efContext.EFContext.Set<TAggregateRoot>().FirstOrDefault(spec.Expression);
        }

        public TAggregateRoot GetByExpression(Expression<Func<TAggregateRoot, bool>> expression)
        {
            return _efContext.EFContext.Set<TAggregateRoot>().FirstOrDefault(expression);
        }

        public IEnumerable<TAggregateRoot> GetAll()
        {
            return GetAll(new AnySpecification<TAggregateRoot>(), null, SortOrder.UnSpecified);
        }

        public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification)
        {
            return GetAll(specification, null, SortOrder.UnSpecified);
        }


        public IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            return GetAll(new AnySpecification<TAggregateRoot>(), sortPredicate, sortOrder);
        }

        public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            var query = _efContext.EFContext.Set<TAggregateRoot>().Where(specification.Expression);
            if (sortPredicate != null)
            {
                switch (sortOrder)
                {
                    case SortOrder.Ascending:
                        return query.SortBy(sortPredicate).ToList();
                        
                    case SortOrder.Descending:
                        return query.SortByDescending(sortPredicate).ToList();

                    default:
                        break;
                }
            }

            return query.ToList();
        }

        public bool Exists(ISpecification<TAggregateRoot> specification)
        {
            var count = _efContext.EFContext.Set<TAggregateRoot>().Count(specification.IsSatisfiedBy);
            return count != 0;
        }

        #endregion
        
        #region 分页支持
        public PagedResult<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize)
        {
            return GetAll(new AnySpecification<TAggregateRoot>(), sortPredicate, sortOrder, pageNumber, pageSize);
        }

        // 分页也就是每次只取出每页展示的数据大小
        public PagedResult<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize)
        {
            if (pageNumber <= 0)
                throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "页码必须大于等于1");
            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException("pageSize", pageSize, "每页大小必须大于或等于1");

            var query = _efContext.EFContext.Set<TAggregateRoot>()
                .Where(specification.Expression);
            var skip = (pageNumber - 1) * pageSize;
            var take = pageSize;
            if (sortPredicate == null)
                throw new InvalidOperationException("基于分页功能的查询必须指定排序字段和排序顺序。");

            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    var pagedGroupAscending = query.SortBy(sortPredicate).Skip(skip).Take(take).GroupBy(p => new { Total = query.Count() }).FirstOrDefault();

                    if (pagedGroupAscending == null)
                        return null;
                    return new PagedResult<TAggregateRoot>(pagedGroupAscending.Key.Total, (pagedGroupAscending.Key.Total + pageSize - 1) / pageSize, pageSize, pageNumber, pagedGroupAscending.Select(p => p).ToList());
                case SortOrder.Descending:
                    var pagedGroupDescending = query.SortByDescending(sortPredicate).Skip(skip).Take(take).GroupBy(p => new { Total = query.Count() }).FirstOrDefault();
                    if (pagedGroupDescending == null)
                        return null;
                    return new PagedResult<TAggregateRoot>(pagedGroupDescending.Key.Total, (pagedGroupDescending.Key.Total + pageSize - 1) / pageSize, pageSize, pageNumber, pagedGroupDescending.Select(p => p).ToList());
                default:
                    break;
            }

            throw new InvalidOperationException("基于分页功能的查询必须指定排序字段和排序顺序。");
        }

        public PagedResult<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            return GetAll(new AnySpecification<TAggregateRoot>(), sortPredicate, sortOrder, pageNumber, pageSize, eagerLoadingProperties);
        }

        public PagedResult<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            if (pageNumber <= 0)
                throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "页码必须大于等于1");
            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException("pageSize", pageSize, "每页大小必须大于或等于1");

            // 将需要饥饿加载的内容添加到Include方法参数中
            var dbset = _efContext.EFContext.Set<TAggregateRoot>();

            IQueryable<TAggregateRoot> query = null;
            if (eagerLoadingProperties != null &&
                eagerLoadingProperties.Length > 0)
            {
                var eagerLoadingProperty = eagerLoadingProperties[0];
                var eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                var dbquery = dbset.Include(eagerLoadingPath);
                for (var i = 1; i < eagerLoadingProperties.Length; i++)
                {
                    eagerLoadingProperty = eagerLoadingProperties[i];
                    eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                    dbquery = dbquery.Include(eagerLoadingPath);
                }

                query = dbquery.Where(specification.Expression);
            }
            else
                query = dbset.Where(specification.Expression);

            var skip = (pageNumber - 1) * pageSize;
            var take = pageSize;

            if (sortPredicate == null)
                throw new InvalidOperationException("基于分页功能的查询必须指定排序字段和排序顺序。");

            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    var pagedGroupAscending = query.SortBy(sortPredicate).Skip(skip).Take(take).GroupBy(p => new { Total = query.Count() }).FirstOrDefault();

                    if (pagedGroupAscending == null)
                        return null;
                    return new PagedResult<TAggregateRoot>(pagedGroupAscending.Key.Total, (pagedGroupAscending.Key.Total + pageSize - 1) / pageSize, pageSize, pageNumber, pagedGroupAscending.Select(p => p).ToList());
                case SortOrder.Descending:
                    var pagedGroupDescending = query.SortByDescending(sortPredicate).Skip(skip).Take(take).GroupBy(p => new { Total = query.Count() }).FirstOrDefault();
                    if (pagedGroupDescending == null)
                        return null;
                    return new PagedResult<TAggregateRoot>(pagedGroupDescending.Key.Total, (pagedGroupDescending.Key.Total + pageSize - 1) / pageSize, pageSize, pageNumber, pagedGroupDescending.Select(p => p).ToList());
                default:
                    break;
            }

            throw new InvalidOperationException("基于分页功能的查询必须指定排序字段和排序顺序。");
        }

        #endregion

        #region 饥饿加载方式实现
        public TAggregateRoot GetBySpecification(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            var dbset = _efContext.EFContext.Set<TAggregateRoot>();
            if (eagerLoadingProperties != null &&
                eagerLoadingProperties.Length > 0)
            {
                var eagerLoadingProperty = eagerLoadingProperties[0];
                var eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                var dbquery = dbset.Include(eagerLoadingPath);
                for (var i = 1; i < eagerLoadingProperties.Length; i++)
                {
                    eagerLoadingProperty = eagerLoadingProperties[i];
                    eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                    dbquery = dbquery.Include(eagerLoadingPath);
                }
                return dbquery.Where(specification.Expression).FirstOrDefault();
            }
            else
                return dbset.Where(specification.Expression).FirstOrDefault();
        }

        public IEnumerable<TAggregateRoot> GetAll(params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            return GetAll(new AnySpecification<TAggregateRoot>(), null, SortOrder.UnSpecified, eagerLoadingProperties);
        }

        public IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            return GetAll(new AnySpecification<TAggregateRoot>(), sortPredicate, sortOrder, eagerLoadingProperties);
        }

        public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            return GetAll(specification, null, SortOrder.UnSpecified, eagerLoadingProperties);
        }

        public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            var dbset = _efContext.EFContext.Set<TAggregateRoot>();
            IQueryable<TAggregateRoot> queryable = null;
            if (eagerLoadingProperties != null &&
                eagerLoadingProperties.Length > 0)
            {
                var eagerLoadingProperty = eagerLoadingProperties[0];
                var eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                var dbquery = dbset.Include(eagerLoadingPath);
                for (var i = 1; i < eagerLoadingProperties.Length; i++)
                {
                    eagerLoadingProperty = eagerLoadingProperties[i];
                    eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                    dbquery = dbquery.Include(eagerLoadingPath);
                }
                queryable = dbquery.Where(specification.Expression);
            }
            else
                queryable = dbset.Where(specification.Expression);

            if (sortPredicate != null)
            {
                switch (sortOrder)
                {
                    case SortOrder.Ascending:
                        return queryable.SortBy(sortPredicate).ToList();
                    case SortOrder.Descending:
                        return queryable.SortByDescending(sortPredicate).ToList();
                    default:
                        break;
                }
            }
            return queryable.ToList();
        }
        #endregion
    }
}
