using System;
using System.Linq.Expressions;

namespace DC.ETL.Domain.Specifications
{
    public sealed class AnySpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> Expression
        {
            get { return o => true; }
        }
    }
}
