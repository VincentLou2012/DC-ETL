using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Models.DTO;
namespace DC.ETL.Domain.Events
{
    public class DataSourceChangeEvent : DomainEvent
    {
        public override string Title
        {
            get { return "数据源更改"; }
        }
        public DataSourceChangeEvent() { }
        public DataSourceChangeEvent(IEntity source) : base(source) { }
        public DataSourceDTO TheDS { get; set; }
    }
}
