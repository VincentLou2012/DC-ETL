using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain.Model
{
    public class StructureRcd : OPRecord
    {
        public int StructureID { get; set; }
        public virtual ExtractStructure _theStructure { get; set; }
    }
}
