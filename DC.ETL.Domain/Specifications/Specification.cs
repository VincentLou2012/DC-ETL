using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain.Specifications
{
    /// <summary>
    /// 规约实现基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Specification<T> : ISpecification<T>
    {
        public static Specification<T> Eval(Expression<Func<T, bool>> expression)
        {
            return new ExpressionSpecification<T>(expression);
        }

        #region ISpecification<T>接口实现
        public bool IsSatisfiedBy(T candidate)
        {
            return this.Expression.Compile()(candidate);
        }

        /// <summary>
        /// 在派生类里具体实现
        /// </summary>
        public abstract Expression<Func<T, bool>> Expression { get; }
        #endregion 
    }
}
