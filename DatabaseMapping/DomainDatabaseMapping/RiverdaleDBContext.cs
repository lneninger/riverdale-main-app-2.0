using DomainDatabaseMapping.Mappings;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Hosting;
using System.IO;
using DomainModel.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DomainModel.File;
using DomainDatabaseMapping.Mappings.File;
using DomainDatabaseMapping.Mappings.Type;
using DomainDatabaseMapping.Mappings.Product;
using Framework.EF.Logging;
using DomainModel.SaleOpportunity;
using DomainDatabaseMapping.Mappings.SaleOpportunity;
using DomainModel.Product;

namespace DomainDatabaseMapping
{
    public class RiverdaleDBContext : IdentityDBContext
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
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseLoggerFactory(CustomLoggerFactory.LoggerFactoryImpl);
        }

        /********************************SECURITY*********************************/
        // Security


        /*********************************CRM  Master Tables**********************/
        // Config
        public DbSet<ThirdPartyAppType> ThirdPartyAppTypes { get; set; }
        public DbSet<ProductColorType> ProductColorTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Country> Countries { get; set; }

        // CRM
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerThirdPartyAppSetting> CustomerThirdPartyAppSettings { get; set; }
        public DbSet<GrowerType> GrowerTypes { get; set; }
        public DbSet<Grower> Growers { get; set; }
        public DbSet<GrowerFreight> GrowerFreights { get; set; }

        // Business
        public DbSet<CustomerOpportunity> CustomerOpportunities { get; set; }

        // Commons
        public DbSet<DomainModel.File.File> FileRepositories { get; set; }
        public DbSet<FileSystemType> FileSystemTypes { get; set; }

        // Products
        public DbSet<AbstractProduct> Products { get; set; }
        public DbSet<ProductAllowedColorType> ProductAllowedColorTypes { get; set; }


        //Opportunity
        public DbSet<SaleOpportunity> SaleOpportunities { get; set; }
        public DbSet<SaleOpportunitySettings> SaleOpportunitySettings { get; set; }
        public DbSet<SaleOpportunityProduct> SaleOpportunityProducts { get; set; }
        public DbSet<SaleSeasonType> SaleSeasonTypes { get; set; }
        public DbSet<SaleSeasonCategoryType> SaleSeasonCategoryTypes { get; set; }


        // Funza
        public DbSet<DomainModel.Funza.ProductReference> FunzaProductReferences { get; set; }
        public DbSet<DomainModel.Funza.ColorReference> FunzaPColorReferences { get; set; }
        public DbSet<DomainModel.Funza.CategoryReference> FunzaCategoryReferences { get; set; }
        public DbSet<DomainModel.Funza.PackingReference> FunzaPackingReferences { get; set; }


        // Quote
        public DbSet<CustomerFreightoutRateType> CustomerFreightoutRateTypes { get; set; }
        public DbSet<CustomerFreightout> CustomerFreightouts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Base Entity Class
            new AbstractBaseEntityMap(modelBuilder).Configure();

            // Config
            modelBuilder.ApplyConfiguration(new ThirdPartyAppTypeMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new ProductColorMap(modelBuilder));

            modelBuilder.ApplyConfiguration(new LocationMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new CountryMap(modelBuilder));


            // CRM
            modelBuilder.ApplyConfiguration(new CustomerMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new CustomerThirdPartyAppSettingMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new GrowerTypeMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new GrowerMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new GrowerFreightMap(modelBuilder));

            // Business
            modelBuilder.ApplyConfiguration(new CustomerOpportunityMap(modelBuilder));

            // Commons
            modelBuilder.ApplyConfiguration(new FileRepositoryMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new FileSystemTypeMap(modelBuilder));

            // Opportunity
            modelBuilder.ApplyConfiguration(new SaleOpportunityMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new SaleOpportunitySettingsMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new SaleOpportunityProductMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new SaleSeasonTypeMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new SaleSeasonCategoryTypeMap(modelBuilder));

            // Funza
            modelBuilder.ApplyConfiguration(new DomainDatabaseMapping.Mappings.Funza.ProductReferenceMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new DomainDatabaseMapping.Mappings.Funza.ColorReferenceMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new DomainDatabaseMapping.Mappings.Funza.CategoryReferenceMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new DomainDatabaseMapping.Mappings.Funza.PackingReferenceMap(modelBuilder));


            // Quote
            modelBuilder.ApplyConfiguration(new CustomerFreightoutRateTypeMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new CustomerFreightoutMap(modelBuilder));

            // Product
            modelBuilder.ApplyConfiguration(new AbstractProductMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new ProductMediaMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new ProductAllowedColorTypeMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new FlowerProductMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new ProductTypeMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new CompositionProductBridgeProductMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new FlowerProductMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new HardgoodProductMap(modelBuilder));
        }


    }
}
