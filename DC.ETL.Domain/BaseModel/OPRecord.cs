using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain.Model
{
    /// <summary>
    /// 操作记录
    /// </summary>
    public partial class OPRecord : AggregateRoot
    {
        /// <summary>
        /// 获取单个操作记录
        /// </summary>
        /// <returns></returns>
        public OPRecord Get(Guid SN)
        {
            // TODO: 这里从Unity获取实例?
            IRepository<OPRecord> itr = null;// Container.Resolve<IRepository<OPRecord>>("OPRecordRepository");
            return itr.GetByKey(SN);
        }
    }
}
