using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain
{
    public class TaskRcd : OPRecord
    {
        //TODO EF映射配置任务ID
        public Guid TaskID { get; set; }
        public virtual TaskItem _theTask { get; set; }
    }
}
