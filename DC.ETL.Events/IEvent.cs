using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Events
{
    public interface IEvent
    {
        Guid ID { get; }

        DateTime Timestamp { get;  }
    }
}
