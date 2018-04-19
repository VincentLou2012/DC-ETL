using System;
using System.Linq.Expressions;

namespace DC.ETL.Domain.Specifications
{
    /// <summary>
    /// 表达式规约
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExpressionSpecification<T> : Specification<T>
    {
        private readonly Expression<Func<T, bool>> _expression;
        public ExpressionSpecification(Expression<Func<T, bool>> expression)
        {
            this._expression = expression;
        }

        public override Expression<Func<T, bool>> Expression
        {
            get { return _expression; }
        }
    }
}
