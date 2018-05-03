using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain
{
    public partial class DataSourceRcd : OPRecord
    {
        public Guid DSSN{ get; set; }
        public virtual DataSource _theDS { get; set; }
    }
}
