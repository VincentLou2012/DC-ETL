using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
namespace DC.ETL.Domain.Specifications
{
    /// <summary>
    /// 规约接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T candidate);
        Expression<Func<T, bool>> Expression { get; }
    }
}
