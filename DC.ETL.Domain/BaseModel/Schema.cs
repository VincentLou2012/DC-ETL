using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain.Model
{
    /// <summary>
    /// 数据模式
    /// </summary>
    public partial class Schema : AggregateRoot
    {
        /// <summary>
        /// 获取单个数据模式
        /// </summary>
        /// <returns></returns>
        public Schema Get(Guid SN)
        {
            // TODO: 这里从Unity获取实例?
            IRepository<Schema> itr = null;// Container.Resolve<IRepository<Schema>>("SchemaRepository");
            return itr.GetByKey(SN);
        }
    }
}
