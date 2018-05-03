using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Models.DTO;
using DC.ETL.Domain.Events;

namespace DC.ETL.Domain.Service
{
    public class DomainService 
    {
        public DataSource CreateDataSource(DataSourceDTO dto)
        {
            var NewDS = new DataSource();
            DomainEvent.Handle<DataSourceCreateEvent>(new DataSourceCreateEvent(NewDS) { NewDS=dto});
            return NewDS;
        }


    }
}
