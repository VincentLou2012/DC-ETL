using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Models.DTO
{
    public class UnitRcdDTO : OPRecordDTO
    {
        public int UnintID { get; set; }

        public virtual ExtractUnitDTO _theunit { get; set; }
    }
}
