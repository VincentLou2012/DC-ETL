using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Models.DTO
{
    public class StructureRcdDTO : OPRecordDTO
    {
        public int StructureID { get; set; }
        public virtual ExtractStructureDTO _theStructure { get; set; }
    }
}
