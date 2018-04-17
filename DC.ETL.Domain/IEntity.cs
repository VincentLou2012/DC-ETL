using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain
{
    /// <summary>
    /// 领域实体接口
    /// </summary>
    public interface IEntity
    {
        //实体唯一标识序列
        System.Guid SN { get; }
    }
}
