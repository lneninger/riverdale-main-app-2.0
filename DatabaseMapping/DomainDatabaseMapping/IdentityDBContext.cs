using DomainDatabaseMapping.Mappings;
using DomainModel.Identity;
using Framework.EF.DbContextImpl;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DomainDatabaseMapping
{
    public class IdentityDBContext : BaseIdentityDbContext<AppUser>
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;

        public IdentityDBContext(DbContextOptions options) : base(options)
        {
            System.Diagnostics.Debug.WriteLine("DbContext: Instanciating IdentityDBContext");
        }

        public IdentityDBContext() : base()
        {
            System.Diagnostics.Debug.WriteLine("DbContext: Instanciating IdentityDBContext");
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



        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            base.Dispose();
            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
            System.Diagnostics.Debug.WriteLine("DbContext: Disposing IdentityDBContext");
        }

        ~IdentityDBContext()
        {
            Dispose(false);
        }
    }
}
