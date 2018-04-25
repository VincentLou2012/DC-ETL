using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Models.DTO
{
    public class DataSourceRcdDTO : OPRecordDTO
    {
        public int DSID { get; set; }
        public virtual DataSourceDTO _theDS { get; set; }
    }
}
