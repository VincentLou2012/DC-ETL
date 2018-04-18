using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain.IRepository
{
    public interface IUnitOfWorkRepositoryContext : IUnitOfWork , IDisposable
    {
        /// <summary>
        /// 将聚合根的状态标记为新建，但EF上下文此时并未提交
        /// </summary>
        /// <typeparam name="TAggregateRoot"></typeparam>
        /// <param name="obj"></param>
        void RegisterNew<TAggregateRoot>(TAggregateRoot obj)
            where TAggregateRoot : IAggregateRoot;

        /// <summary>
        /// 将聚合根的状态标记为修改，但EF上下文此时并未提交
        /// </summary>
        /// <typeparam name="TAggregateRoot"></typeparam>
        /// <param name="obj"></param>
        void RegisterModified<TAggregateRoot>(TAggregateRoot obj)
            where TAggregateRoot : IAggregateRoot;

        /// <summary>
        /// 将聚合根的状态标记为删除，但EF上下文此时并未提交
        /// </summary>
        /// <typeparam name="TAggregateRoot"></typeparam>
        /// <param name="obj"></param>
        void RegisterDeleted<TAggregateRoot>(TAggregateRoot obj)
            where TAggregateRoot : IAggregateRoot;
    }
}
