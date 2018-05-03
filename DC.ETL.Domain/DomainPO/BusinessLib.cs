using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DC.ETL.Domain
{
    public partial class BusinessLib
    {
        public string Name { get; set; }

        public string Aspect { get; set; }

        public string Keywords { get; set; }

        public virtual ICollection<Task> BUnits { get; set; }
    }
}
