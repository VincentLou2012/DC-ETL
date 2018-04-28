using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain
{
    public partial class StructureRcd : OPRecord
    {
        public int StructureID { get; set; }
        public virtual Structure _theStructure { get; set; }
    }
}
