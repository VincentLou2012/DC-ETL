using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using DC.ETL.Infrastructure.Container;

namespace DC.ETL.Domain.Model
{
    /// <summary>
    /// 操作记录
    /// </summary>
    public partial class OPRecord : AggregateRoot
    {
        [Dependency]
        private readonly IOPRecordRepository iOPRecordRepository
        {
            get { return Container.Resolve<IOPRecordRepository>("OPRecordRepository"); }
        }
        /// <summary>
        /// 获取单个操作记录
        /// </summary>
        /// <returns></returns>
        public OPRecord Get(Guid SN)
        {
            return iOPRecordRepository.GetByKey(SN);
        }
    }
}
