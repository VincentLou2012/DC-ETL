using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Infrastructure.Utils;
namespace DC.ETL.Domain.Events.EventHandlers
{
    public class DataSourceCreateEventHandler : IDomainEventHandler<DataSourceCreateEvent>
    {
        public void Handle(DataSourceCreateEvent @event)
        {
            // 获得事件源对象
            var ds = @event.Source as DataSource;
            // 更新事件源对象的属性
            if (ds == null) return;
            ds.Create(@event.NewDS);
        }
    }
}
