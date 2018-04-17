using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain.Model
{
    public class DataSourceRcd : OPRecord
    {
        public int DSID { get; set; }
        public virtual DataSource _theDS { get; set; }
    }
}
