using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain.Model
{
    public class UnitRcd : OPRecord
    {
        public int UnintID { get; set; }

        public virtual ExtractUnit _theunit { get; set; }
    }
}
