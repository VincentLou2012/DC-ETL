using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain
{
    public class BusinessLibRcd : OPRecord
    {
        //TODO EF映射配置业务库ID
        public Guid BLID { get; set; }
        public virtual BusinessLib _theBL { get; set; }
    }
}
