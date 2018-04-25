using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Domain.Model;

namespace DC.ETL.Domain
{
    /// <summary>
    /// 操作记录 仓储接口
    /// </summary>
    /// <remarks>
    /// 操作记录 仓储接口
    /// </remarks>
    public interface IOPRecordRepository : IRepository<OPRecord>
    {
    }
}
