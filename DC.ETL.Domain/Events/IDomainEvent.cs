using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Events;
namespace DC.ETL.Domain.Events
{
    public interface IDomainEvent : IEvent
    {
        IEntity Source { get; }
        string Title { get; }
        //TODO 实现领域事件存储
    }
}
