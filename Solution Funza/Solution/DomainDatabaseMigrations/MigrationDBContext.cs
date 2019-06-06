using DomainDatabaseMapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDatabaseMigrations
{
    public class MigrationDBContext : FunzaDBContext
    {
        public MigrationDBContext(DbContextOptions options) : base(options)
        {
        }

        public MigrationDBContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(local)\\SQLEXPRESS;Initial Catalog=riverdale_funza;Integrated Security=SSPI;Persist Security Info=False;MultipleActiveResultSets=True;Application Name=Riverdale2.0");
        }
    }
}
