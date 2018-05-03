using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Events;

namespace DC.ETL.Domain.Events
{
    public interface IDomainEventHandler<in TDomainEvent> : IEventHandler<TDomainEvent>
      where TDomainEvent : class, IDomainEvent
    {
        // TODO 在handler中发布事件到事件总线进行下一步处理
    }
}
