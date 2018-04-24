using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Models.DTO
{
    public class WholeStructureRcd : OPRecordDTO
    {
        public System.Guid StructureSN { get; set; }

        public virtual WholeStructureDTO _theStructure { get; set; }
    }
}
