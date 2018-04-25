using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Models.DTO
{
    public class TaskRcdDTO : OPRecordDTO
    {
        public int TaskID { get; set; }
        public virtual TaskDTO _theTask { get; set; }
    }
}
