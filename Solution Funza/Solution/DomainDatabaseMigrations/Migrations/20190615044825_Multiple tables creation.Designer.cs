﻿// <auto-generated />
using System;
using DomainDatabaseMigrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DomainDatabaseMigrations.Migrations
{
    [DbContext(typeof(MigrationDBContext))]
    [Migration("20190615044825_Multiple tables creation")]
    partial class Multipletablescreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DomainModel.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()")
                        .HasAnnotation("ColumnOrder", 100);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValueSql("SYSTEM_USER")
                        .HasAnnotation("ColumnOrder", 101);

                    b.Property<string>("FunzaCreatedBy");

                    b.Property<DateTime>("FunzaCreatedDate");

                    b.Property<int>("FunzaId");

                    b.Property<string>("FunzaUpdatedBy");

                    b.Property<DateTime?>("FunzaUpdatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("ToOrder");

                    b.Property<bool>("ToStem");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("ColumnOrder", 102);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("ColumnOrder", 103);

                    b.HasKey("Id");

                    b.ToTable("Category","MASTERS");
                });

            modelBuilder.Entity("DomainModel.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()")
                        .HasAnnotation("ColumnOrder", 100);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValueSql("SYSTEM_USER")
                        .HasAnnotation("ColumnOrder", 101);

                    b.Property<string>("FunzaCreatedBy");

                    b.Property<string>("FunzaCreatedDate");

                    b.Property<string>("FunzaId")
                        .IsRequired();

                    b.Property<string>("FunzaUpdatedBy");

                    b.Property<string>("FunzaUpdatedDate");

                    b.Property<string>("Hexagecimal");

                    b.Property<string>("Image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NameEnglish")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("State");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("ColumnOrder", 102);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("ColumnOrder", 103);

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.ToTable("Color","MASTERS");
                });

            modelBuilder.Entity("DomainModel.GoodPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Category");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Code");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()")
                        .HasAnnotation("ColumnOrder", 100);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValueSql("SYSTEM_USER")
                        .HasAnnotation("ColumnOrder", 101);

                    b.Property<string>("Description");

                    b.Property<int>("GoodId");

                    b.Property<string>("UnitMeasure");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("ColumnOrder", 102);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("ColumnOrder", 103);

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.ToTable("GoodPrice","FUNZA");
                });

            modelBuilder.Entity("DomainModel.Labor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<int>("BouquetTypeId");

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<decimal>("Cost");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()")
                        .HasAnnotation("ColumnOrder", 100);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValueSql("SYSTEM_USER")
                        .HasAnnotation("ColumnOrder", 101);

                    b.Property<int>("UnitAmount");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("ColumnOrder", 102);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("ColumnOrder", 103);

                    b.HasKey("Id");

                    b.ToTable("Labor","MASTERS");
                });

            modelBuilder.Entity("DomainModel.Packing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CargoMasterCode");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()")
                        .HasAnnotation("ColumnOrder", 100);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValueSql("SYSTEM_USER")
                        .HasAnnotation("ColumnOrder", 101);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("EquivalentFullQuotator");

                    b.Property<decimal>("EquivalentsFull");

                    b.Property<string>("FunzaCreatedBy");

                    b.Property<DateTime>("FunzaCreatedDate");

                    b.Property<int>("FunzaId");

                    b.Property<string>("FunzaUpdatedBy");

                    b.Property<DateTime?>("FunzaUpdatedDate");

                    b.Property<decimal>("Height");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("Length");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NameEnglish")
                        .HasColumnType("varchar(200)");

                    b.Property<bool?>("SentToQuotator");

                    b.Property<bool>("State");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("ColumnOrder", 102);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("ColumnOrder", 103);

                    b.Property<decimal>("Volume");

                    b.Property<string>("VolumeDescripcion");

                    b.Property<decimal>("VolumeEquivalentFull");

                    b.Property<decimal>("Weight");

                    b.Property<decimal>("Width");

                    b.HasKey("Id");

                    b.ToTable("Packing","FUNZA");
                });

            modelBuilder.Entity("DomainModel.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int>("CategoryId");

                    b.Property<string>("CategoryName")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(200)");

                    b.Property<int>("ColorId");

                    b.Property<string>("Comments")
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()")
                        .HasAnnotation("ColumnOrder", 100);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValueSql("SYSTEM_USER")
                        .HasAnnotation("ColumnOrder", 101);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(200)");

                    b.Property<int>("FunzaId");

                    b.Property<DateTime>("FunzaUpdatedDate");

                    b.Property<int>("ProductTypeId");

                    b.Property<string>("ProductTypeName")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("ReferenceCode")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("ReferenceDescription")
                        .HasColumnType("varchar(200)");

                    b.Property<int>("ReferenceId");

                    b.Property<int>("ReferenceTypeId");

                    b.Property<string>("ReferenceTypeName")
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("SendQuotator");

                    b.Property<int>("SizeId");

                    b.Property<int>("SpecieId");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("ColumnOrder", 102);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("ColumnOrder", 103);

                    b.Property<int>("VariatyId");

                    b.HasKey("Id");

                    b.ToTable("Product","FUNZA");
                });

            modelBuilder.Entity("DomainModel.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdjustRequestUserId");

                    b.Property<string>("Code");

                    b.Property<int>("ComboId");

                    b.Property<string>("Comments");

                    b.Property<decimal>("ConfirmationPackingPrice");

                    b.Property<decimal>("ConfirmationPriceLabor");

                    b.Property<int>("CreateStep");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()")
                        .HasAnnotation("ColumnOrder", 100);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValueSql("SYSTEM_USER")
                        .HasAnnotation("ColumnOrder", 101);

                    b.Property<string>("CreatedByUserName");

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("CreatorUserId");

                    b.Property<decimal>("FinalPrice");

                    b.Property<int>("FunzaId");

                    b.Property<decimal>("LaborDiscount");

                    b.Property<DateTime>("LastModificationTime");

                    b.Property<int>("LastModifierUserId");

                    b.Property<string>("LastModifierUserName");

                    b.Property<decimal>("Margen");

                    b.Property<int>("NoBouquets");

                    b.Property<int>("Orders");

                    b.Property<decimal>("PackingDescount");

                    b.Property<int>("PackingId");

                    b.Property<int>("PackingName");

                    b.Property<decimal>("PackingPrice");

                    b.Property<int>("PackingPriceId");

                    b.Property<decimal>("PricePerBouquet");

                    b.Property<int>("ProductId");

                    b.Property<int>("QuoteAdjustments");

                    b.Property<int>("Quotes");

                    b.Property<int>("SatelliteQuote");

                    b.Property<int>("SatelliteQuoteId");

                    b.Property<int>("SatelliteQuotes");

                    b.Property<decimal>("StartingPrice");

                    b.Property<int>("Status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("TotalCost");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("ColumnOrder", 102);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("ColumnOrder", 103);

                    b.HasKey("Id");

                    b.ToTable("Quote","FUNZA");
                });

            modelBuilder.Entity("DomainModel.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("BeginDate");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()")
                        .HasAnnotation("ColumnOrder", 100);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValueSql("SYSTEM_USER")
                        .HasAnnotation("ColumnOrder", 101);

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("ColumnOrder", 102);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("ColumnOrder", 103);

                    b.HasKey("Id");

                    b.ToTable("Season","MASTERS");
                });
#pragma warning restore 612, 618
        }
    }
}
