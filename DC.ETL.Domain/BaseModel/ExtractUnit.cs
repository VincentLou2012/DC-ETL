using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain.Model
{
    /// <summary>
    /// 抽取单元
    /// </summary>
    public partial class ExtractUnit : AggregateRoot
    {
        /// <summary>
        /// 获取单个抽取单元
        /// </summary>
        /// <returns></returns>
        public ExtractUnit Get(Guid SN)
        {
            // TODO: 这里从Unity获取实例?
            IRepository<ExtractUnit> itr = null;// Container.Resolve<IRepository<ExtractUnit>>("ExtractUnitRepository");
            return itr.GetByKey(SN);
        }
    }
}
