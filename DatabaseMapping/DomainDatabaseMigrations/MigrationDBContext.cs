using DomainDatabaseMapping.Mappings;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DomainDatabaseMapping
{
    public class MigrationDBContext: RiverdaleDBContext
    {
        public MigrationDBContext(DbContextOptions options) : base(options)
        {
        }

        public MigrationDBContext(): base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(local)\\SQLEXPRESS;Initial Catalog=riverdale;Integrated Security=SSPI;Persist Security Info=False;MultipleActiveResultSets=True;Application Name=Riverdale2.0");
        }
    }
}
