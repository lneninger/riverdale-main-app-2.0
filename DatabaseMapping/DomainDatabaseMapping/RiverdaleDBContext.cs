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

namespace DomainDatabaseMapping
{
    public class RiverdaleDBContext: DbContext
    {
        public RiverdaleDBContext(DbContextOptions options) : base(options)
        {
        }

        public RiverdaleDBContext() : base()
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


        /*********************************CRM  Master Tables**********************/
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerOpportunity> CustomerOpportunities { get; set; }
        public DbSet<FileRepository> FileRepositories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new AbstractBaseEntityMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new CustomerOpportunityMap());
            modelBuilder.ApplyConfiguration(new FileRepositoryMap());
        }

        public override int SaveChanges()
        {
            var changed = this.ChangeTracker.Entries<AbstractBaseEntity>();

            foreach (var changedEntity in changed.Where(o => o.State == EntityState.Added))
            {
                ((AbstractBaseEntity)changedEntity.Entity).CreatedAt = DateTime.UtcNow;
            }

            foreach (var changedEntity in changed.Where(o => o.State == EntityState.Modified))
            {
                ((AbstractBaseEntity)changedEntity.Entity).UpdatedAt = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }
    }
}
