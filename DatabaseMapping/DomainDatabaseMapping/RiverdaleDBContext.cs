﻿using DomainDatabaseMapping.Mappings;
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
using DomainModel.File;
using DomainDatabaseMapping.Mappings.File;
using DomainDatabaseMapping.Mappings.Type;
using DomainDatabaseMapping.Mappings.Product;
using Framework.EF.Logging;

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

        // CRM
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerThirdPartyAppSetting> CustomerThirdPartyAppSettings { get; set; }

        // Business
        public DbSet<CustomerOpportunity> CustomerOpportunities { get; set; }

        // Commons
        public DbSet<DomainModel.File.File> FileRepositories { get; set; }
        public DbSet<FileSystemType> FileSystemTypes { get; set; }

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

            // CRM
            modelBuilder.ApplyConfiguration(new CustomerMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new CustomerThirdPartyAppSettingMap(modelBuilder));

            // Business
            modelBuilder.ApplyConfiguration(new CustomerOpportunityMap(modelBuilder));

            // Commons
            modelBuilder.ApplyConfiguration(new FileRepositoryMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new FileSystemTypeMap(modelBuilder));

            // Quote
            modelBuilder.ApplyConfiguration(new CustomerFreightoutRateTypeMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new CustomerFreightoutMap(modelBuilder));

            // Product
            modelBuilder.ApplyConfiguration(new AbstractProductMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new ProductMediaMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new FlowerProductMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new ProductTypeMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new CompositionProductBridgeProductMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new FlowerProductMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new HardgoodProductMap(modelBuilder));
        }


}
}
