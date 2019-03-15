using DomainDatabaseMapping.Mappings;
using DomainDatabaseMapping.Mappings.Company;
using DomainDatabaseMapping.Mappings.File;
using DomainDatabaseMapping.Mappings.Product;
using DomainDatabaseMapping.Mappings.SaleOpportunity;
using DomainDatabaseMapping.Mappings.Type;
using DomainModel;
using DomainModel.Company;
using DomainModel.Company.Customer;
using DomainModel.Company.Grower;
using DomainModel.File;
using DomainModel.Product;
using DomainModel.SaleOpportunity;
using Framework.EF.Logging;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<AbstractCompany> Companies { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerSettings> CustomerSettings { get; set; }
        public DbSet<CustomerThirdPartyAppSetting> CustomerThirdPartyAppSettings { get; set; }
        public DbSet<CustomerFreightoutRateType> CustomerFreightoutRateTypes { get; set; }
        public DbSet<CustomerFreightout> CustomerFreightouts { get; set; }


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
        public DbSet<SaleOpportunityPriceLevel> SaleOpportunityPriceLevels { get; set; }
        public DbSet<SampleBox> SampleBoxes { get; set; }
        public DbSet<SampleBoxProduct> SampleBoxProducts { get; set; }
        public DbSet<SaleSeasonType> SaleSeasonTypes { get; set; }
        public DbSet<SaleSeasonCategoryType> SaleSeasonCategoryTypes { get; set; }


        // Funza
        public DbSet<DomainModel.Funza.ProductReference> FunzaProductReferences { get; set; }
        public DbSet<DomainModel.Funza.ColorReference> FunzaPColorReferences { get; set; }
        public DbSet<DomainModel.Funza.CategoryReference> FunzaCategoryReferences { get; set; }
        public DbSet<DomainModel.Funza.PackingReference> FunzaPackingReferences { get; set; }
        public DbSet<DomainModel.Funza.QuoteReference> FunzaQuoteReferences { get; set; }


        // Quote


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
            modelBuilder.ApplyConfiguration(new AbstractCompanyMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new CompanyTypeMap(modelBuilder));

            modelBuilder.ApplyConfiguration(new CustomerMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new CustomerSettingsMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new CustomerThirdPartyAppSettingMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new CustomerFreightoutRateTypeMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new CustomerFreightoutMap(modelBuilder));

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
            modelBuilder.ApplyConfiguration(new SampleBoxMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new SampleBoxProductMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new SaleOpportunitySettingsMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new SaleOpportunityPriceLevelMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new SaleSeasonTypeMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new SaleSeasonCategoryTypeMap(modelBuilder));

            // Funza
            modelBuilder.ApplyConfiguration(new DomainDatabaseMapping.Mappings.Funza.ProductReferenceMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new DomainDatabaseMapping.Mappings.Funza.ColorReferenceMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new DomainDatabaseMapping.Mappings.Funza.CategoryReferenceMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new DomainDatabaseMapping.Mappings.Funza.PackingReferenceMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new DomainDatabaseMapping.Mappings.Funza.QuoteReferenceMap(modelBuilder));


            // Quote
            
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
