using DomainDatabaseMapping.Mappings;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using DomainModel.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DomainDatabaseMapping
{
    public class IdentityDBContext : IdentityDbContext<AppUser>
    {
        public IdentityDBContext(DbContextOptions options) : base(options)
        {
        }

        public IdentityDBContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string envVariable = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            //IHostingEnvironment env = hostingContext.HostingEnvironment;
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{envVariable}.json", optional: true);

            IConfigurationRoot config = builder.Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("RiverdaleModel"));
        }


        /*********************************Identity Tables**********************/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Base Entity Class
            new AbstractBaseEntityMap(modelBuilder).Configure();

            modelBuilder.ApplyConfiguration(new AppUserMap(modelBuilder));
        }



    }
}
