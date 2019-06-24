using DomainDatabaseMapping.Mappings;
using DomainModel;
using Framework.EF.Logging;
using Microsoft.EntityFrameworkCore;

namespace DomainDatabaseMapping
{
    public class FunzaDBContext: DbContext
    {
        public FunzaDBContext(DbContextOptions options) : base(options)
        {
        }

        //public FunzaDBContext() : base()
        //{
        //}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseLoggerFactory(CustomLoggerFactory.LoggerFactoryImpl);
        }


        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Season> FunzaSeasons { get; set; }
        public DbSet<GoodPrice> GoodPrices { get; set; }
        public DbSet<Product> ProductMap { get; set; }
        public DbSet<Category> CategoryMap { get; set; }
        public DbSet<Color> ColorMap { get; set; }
        public DbSet<Labor> LaborMap { get; set; }
        public DbSet<Packing> PackingMap { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Base Entity Class
            new AbstractBaseEntityMap(modelBuilder).Configure();

            // Config
            modelBuilder.ApplyConfiguration(new QuoteMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new SeasonMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new GoodPriceMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new ProductMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new CategoryMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new ColorMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new LaborMap(modelBuilder));
            modelBuilder.ApplyConfiguration(new PackingMap(modelBuilder));
        }
        }
}
