using DomainDatabaseMapping.Mappings;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace DomainDatabaseMapping
{
    public class MigrationDBContext_QA: RiverdaleDBContext
    {
        public MigrationDBContext_QA(DbContextOptions options) : base(options)
        {
        }

        public MigrationDBContext_QA(): base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //string connStr = ConfigurationManager.ConnectionStrings["DomainModel"].ConnectionString;

            ////base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(connStr);
            optionsBuilder.UseSqlServer("Data Source=198.38.92.253;Initial Catalog=riverdale_qa;User Id=riverdale_user;Password=riverdale_user1;MultipleActiveResultSets=True;Application Name=Riverdale2.0");
        }
    }
}
