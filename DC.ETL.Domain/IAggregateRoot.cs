using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain
{
    /// <summary>
    /// 聚合根接口,定义聚合根必须继承该接口,该接口用于泛型约束
    /// </summary>
    public interface IAggregateRoot : IEntity
    {
    }
}
