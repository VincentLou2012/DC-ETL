using System;
using DC.ETL.Models.DTO;

namespace DC.ETL.Domain.Events
{
    public class DataSourceCreateEvent : DomainEvent
    {
        public override string Title
        {
            get { return "数据源创建"; }
        }
        public DataSourceCreateEvent() { }
        public DataSourceCreateEvent(IEntity source) : base(source) { }
        public DataSourceDTO NewDS { get; set; }
    }
}
