using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DC.ETL.Domain.Model;

namespace DC.ETL.Repository.UnitOfWork
{
    public class EFDbContext : DbContext
    {
        public EFDbContext()
           : base("name=ETLDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<DataSource> DataSources { get; set; }
        public DbSet<DataSourceRcd> DataSourceRcds { get; set; }
    }
}
