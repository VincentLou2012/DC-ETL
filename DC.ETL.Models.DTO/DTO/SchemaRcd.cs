using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Models.DTO
{
    public class SchemaRcdDTO : OPRecordDTO
    {
        public int SchemaID { get; set; }
        public virtual SchemaDTO _theSchema { get; set; }
    }
}
