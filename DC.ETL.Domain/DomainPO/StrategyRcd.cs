using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain
{
    public class StrategyRcd : OPRecord
    {
        //TODO EF映射配置策略ID
        public Guid StrategyID { get; set; }
        public virtual Strategy _theStrategy { get; set; }
    }
}
