using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DC.ETL.Domain.Specifications;
using DC.ETL.Infrastructure;
namespace DC.ETL.Domain
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : class ,IAggregateRoot
    {
        #region 属性
        /// <summary>
        /// 是否跟踪，不需要跟踪更新的实体对象该属性设为false，提高查询效率
        /// </summary>
        bool EnableTrack { get; set; }
        #endregion

        #region Command
        /// <summary>
        /// 保存修改
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="aggregateRoot">聚合根对象</param>
        void Add(TAggregateRoot aggregateRoot);
        
        /// <summary>
        /// 移除聚合根,实现中不删除实际数据,设定删除状态
        /// </summary>
        /// <param name="aggregateRoot"></param>
        void Remove(TAggregateRoot aggregateRoot);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="aggregateRoot"></param>
        void Update(TAggregateRoot aggregateRoot);

        #endregion

        #region Query
        /// <summary>
        /// 根据聚合根的ID值，从仓储中读取聚合根
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TAggregateRoot GetByKey(Guid SN);

        /// <summary>
        /// 根据规约条件，从仓储读取聚合根
        /// </summary>
        /// <param name="spec"></param>
        /// <returns></returns>
        TAggregateRoot GetBySpecification(ISpecification<TAggregateRoot> spec);

        /// <summary>
        /// 根据表达式从仓储读取聚合根
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        TAggregateRoot GetByExpression(Expression<Func<TAggregateRoot, bool>> expression);

        /// <summary>
        /// 读取所有聚合根
        /// </summary>
        /// <returns></returns>
        IEnumerable<TAggregateRoot> GetAll();

        /// <summary>
        /// 以指定的排序字段和排序方式，从仓储中读取所有聚合根。
        /// </summary>
        /// <param name="sortPredicate">排序字段表达式</param>
        /// <param name="sortOrder">排序顺序</param>
        /// <returns></returns>
        IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder);

        /// <summary>
        /// 根据指定的规约获取聚合根
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification);

        /// <summary>
        /// 根据指定的规约,以指定的排序字段和排序方式，从仓储中读取聚合根
        /// </summary>
        /// <param name="specification">规约条件</param>
        /// <param name="sortPredicate">排序字段表达式</param>
        /// <param name="sortOrder">排序顺序</param>
        /// <returns></returns>
        IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder);

        /// <summary>
        /// 返回一个值，该值表示符合指定规约条件的聚合根是否存在。
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        bool Exists(ISpecification<TAggregateRoot> specification);

        #region 分页支持
        /// <summary>
        /// 根据指定字段排序表达式分页获取排序聚合根实例
        /// </summary>
        /// <param name="sortPredicate"></param>
        /// <param name="sortOrder"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        PagedResult<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate,
            SortOrder sortOrder, int pageNumber, int pageSize);

        /// <summary>
        /// 根据指定的规约,以指定的排序字段和排序方式，从仓储中分页读取聚合根
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="sortPredicate"></param>
        /// <param name="sortOrder"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        PagedResult<TAggregateRoot> GetAll(
            ISpecification<TAggregateRoot> specification,
            Expression<Func<TAggregateRoot, dynamic>> sortPredicate,
            SortOrder sortOrder, int pageNumber, int pageSize);

        /// <summary>
        /// 根据排序条件分页饥饿获取聚合根
        /// </summary>
        /// <param name="sortPredicate"></param>
        /// <param name="sortOrder"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="eagerLoadingProperties">饥饿加载属性</param>
        /// <returns></returns>
        PagedResult<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate,
            SortOrder sortOrder, int pageNumber, int pageSize,
            params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

        /// <summary>
        /// 根据条件规约排序分页饥饿加载聚合根
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="sortPredicate"></param>
        /// <param name="sortOrder"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="eagerLoadingProperties"></param>
        /// <returns></returns>
        PagedResult<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification,
            Expression<Func<TAggregateRoot, dynamic>> sortPredicate,
            SortOrder sortOrder, int pageNumber, int pageSize,
            params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

        #endregion

        #region 饥饿加载方式 立即执行查询,取消延迟加载,性能低一些,特别场景使用

        TAggregateRoot GetBySpecification(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        IEnumerable<TAggregateRoot> GetAll(params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

        IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

        IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

        IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        #endregion

        #endregion
    }
}
