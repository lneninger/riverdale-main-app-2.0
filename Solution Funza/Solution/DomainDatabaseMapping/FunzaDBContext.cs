using DomainDatabaseMapping.Mappings;
using DomainModel;
using Framework.EF.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDatabaseMapping
{
    public class FunzaDBContext: DbContext
    {
        public DbSet<Quote> Quotes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseLoggerFactory(CustomLoggerFactory.LoggerFactoryImpl);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Base Entity Class
            new AbstractBaseEntityMap(modelBuilder).Configure();

            // Config
            modelBuilder.ApplyConfiguration(new QuoteMap(modelBuilder));
        }
        }
}
