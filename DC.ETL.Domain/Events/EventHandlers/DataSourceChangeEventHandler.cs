using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain.Events.EventHandlers
{
    public class DataSourceChangeEventHandler : IDomainEventHandler<DataSourceChangeEvent>
    {
        public void Handle(DataSourceChangeEvent @event)
        {
            // 获得事件源对象
            var ds = @event.Source as DataSource;
            // 更新事件源对象的属性
            if (ds == null) return;
            ds.Update(@event.TheDS);
        }
    }
}
