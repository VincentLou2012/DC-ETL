using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain
{
    public class DataSourceRcd : OPRecord
    {
        //TODO EF映射配置数据源ID
        public Guid DSID{ get; set; }
        public virtual DataSource _theDS { get; set; }
    }
}
