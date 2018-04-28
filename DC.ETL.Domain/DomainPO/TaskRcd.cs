using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain
{
    public partial class TaskRcd : OPRecord
    {
        public int TaskID { get; set; }
        public virtual Task _theTask { get; set; }
    }
}
