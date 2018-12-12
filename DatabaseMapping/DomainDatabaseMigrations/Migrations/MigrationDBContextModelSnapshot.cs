﻿// <auto-generated />
using System;
using DomainDatabaseMapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DomainDatabaseMigrations.Migrations
{
    [DbContext(typeof(MigrationDBContext))]
    partial class MigrationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DomainModel.Customer", b =>
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

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("ColumnOrder", 102);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("ColumnOrder", 103);

                    b.HasKey("Id");

                    b.ToTable("Customer","CRM");
                });

            modelBuilder.Entity("DomainModel.CustomerFreightout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<string>("CustomerFreightoutRateTypeId")
                        .IsRequired();

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<bool?>("IsDeleted");

                    b.Property<decimal>("SecondLeg");

                    b.Property<decimal?>("SurchargeHourly");

                    b.Property<decimal?>("SurchargeYearly");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("ColumnOrder", 102);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("ColumnOrder", 103);

                    b.Property<decimal>("WProtect");

                    b.HasKey("Id");

                    b.HasIndex("CustomerFreightoutRateTypeId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerFreightout","QUOTE");
                });

            modelBuilder.Entity("DomainModel.CustomerFreightoutRateType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(4);

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
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("ColumnOrder", 102);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("ColumnOrder", 103);

                    b.HasKey("Id");

                    b.ToTable("CustomerFreightoutRateType","QUOTE");

                    b.HasData(
                        new { Id = "CUBE", CreatedAt = new DateTime(2018, 12, 12, 0, 38, 24, 106, DateTimeKind.Utc), CreatedBy = "Seed", Description = "Rate by volume(cubic meters)", Name = "Cube" },
                        new { Id = "BOX", CreatedAt = new DateTime(2018, 12, 12, 0, 38, 24, 106, DateTimeKind.Utc), CreatedBy = "Seed", Description = "Rate by box(amount of containers)", Name = "Box" }
                    );
                });

            modelBuilder.Entity("DomainModel.CustomerOpportunity", b =>
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

                    b.Property<int>("CustomerId");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("ColumnOrder", 102);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("ColumnOrder", 103);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerOpportunity","QUOTE");
                });

            modelBuilder.Entity("DomainModel.CustomerThirdPartyAppSetting", b =>
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

                    b.Property<int>("CustomerId");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("ThirdPartyAppTypeId");

                    b.Property<string>("ThirdPartyCustomerId")
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("ColumnOrder", 102);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("ColumnOrder", 103);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ThirdPartyAppTypeId");

                    b.ToTable("CustomerThirdPartyAppSetting","CRM");
                });

            modelBuilder.Entity("DomainModel.File.FileRepository", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessPath")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(500);

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

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar")
                        .HasMaxLength(150);

                    b.Property<int>("FileSize");

                    b.Property<string>("FileSystemTypeId");

                    b.Property<string>("FullFilePath");

                    b.Property<string>("RelativePath")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(500);

                    b.Property<string>("RootPath")
                        .IsRequired()
                        .HasColumnType("nvarchar")
                        .HasMaxLength(100);

                    b.Property<string>("ThumbnailFileName")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(150);

                    b.Property<int>("ThumbnailFileSize");

                    b.Property<string>("ThumbnailFullFilePath");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("ColumnOrder", 102);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("ColumnOrder", 103);

                    b.HasKey("Id");

                    b.HasIndex("FileSystemTypeId");

                    b.ToTable("FileRepository","FILE");
                });

            modelBuilder.Entity("DomainModel.File.FileSystemType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(4);

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
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("ColumnOrder", 102);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("ColumnOrder", 103);

                    b.HasKey("Id");

                    b.ToTable("FileSystemType","FILE");

                    b.HasData(
                        new { Id = "DB", CreatedAt = new DateTime(2018, 12, 12, 0, 38, 24, 100, DateTimeKind.Utc), CreatedBy = "Seed", Description = "Internal Database Repository", Name = "Database" },
                        new { Id = "AWS", CreatedAt = new DateTime(2018, 12, 12, 0, 38, 24, 100, DateTimeKind.Utc), CreatedBy = "Seed", Description = "Amazon S3 File Repository", Name = "AWS S3" },
                        new { Id = "SYS", CreatedAt = new DateTime(2018, 12, 12, 0, 38, 24, 100, DateTimeKind.Utc), CreatedBy = "Seed", Description = "File System Repository", Name = "File System" }
                    );
                });

            modelBuilder.Entity("DomainModel.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("Password");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PictureUrl");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DomainModel.Product.AbstractProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("ProductTypeId")
                        .IsRequired();

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Product","PROD");

                    b.HasDiscriminator<string>("ProductTypeId").HasValue("AbstractProduct");
                });

            modelBuilder.Entity("DomainModel.Product.CompositionProductBridge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompositionItemId");

                    b.Property<int>("CompositionProductId");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<bool?>("IsDeleted");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CompositionItemId");

                    b.HasIndex("CompositionProductId");

                    b.ToTable("CompositionProductBridgeProduct","PROD");
                });

            modelBuilder.Entity("DomainModel.Product.ProductMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(4)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<int>("FileRepositoryId");

                    b.Property<bool?>("IsDeleted");

                    b.Property<int>("ProductId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("FileRepositoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductMedia","PROD");
                });

            modelBuilder.Entity("DomainModel.Product.ProductType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(4);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("ProductType","PROD");

                    b.HasData(
                        new { Id = "FLW", CreatedAt = new DateTime(2018, 12, 12, 0, 38, 24, 208, DateTimeKind.Utc), CreatedBy = "Seed", Description = "Raw Flower", Name = "Flower" },
                        new { Id = "COMP", CreatedAt = new DateTime(2018, 12, 12, 0, 38, 24, 208, DateTimeKind.Utc), CreatedBy = "Seed", Description = "Multiple Product Composition. Kit", Name = "Composition" },
                        new { Id = "HARD", CreatedAt = new DateTime(2018, 12, 12, 0, 38, 24, 208, DateTimeKind.Utc), CreatedBy = "Seed", Description = "Hardgood", Name = "Hardgood" }
                    );
                });

            modelBuilder.Entity("DomainModel.ProductColorType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3);

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

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("HexCode")
                        .IsRequired()
                        .HasMaxLength(6);

                    b.Property<bool>("IsBasicColor")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("ColumnOrder", 102);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("ColumnOrder", 103);

                    b.HasKey("Id");

                    b.ToTable("ProductColorType","CNF");
                });

            modelBuilder.Entity("DomainModel.ThirdPartyAppType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(6);

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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("ColumnOrder", 102);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("ColumnOrder", 103);

                    b.HasKey("Id");

                    b.ToTable("ThirdPartyAppType","CNF");

                    b.HasData(
                        new { Id = "BISERP", CreatedAt = new DateTime(2018, 12, 12, 0, 38, 24, 44, DateTimeKind.Utc), CreatedBy = "Seed", Name = "Business ERP" },
                        new { Id = "SFORCE", CreatedAt = new DateTime(2018, 12, 12, 0, 38, 24, 46, DateTimeKind.Utc), CreatedBy = "Seed", Name = "Salesforce" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DomainModel.Product.CompositionProduct", b =>
                {
                    b.HasBaseType("DomainModel.Product.AbstractProduct");


                    b.ToTable("CompositionProduct");

                    b.HasDiscriminator().HasValue("COMP");
                });

            modelBuilder.Entity("DomainModel.Product.FlowerProduct", b =>
                {
                    b.HasBaseType("DomainModel.Product.AbstractProduct");


                    b.ToTable("FlowerProduct");

                    b.HasDiscriminator().HasValue("FLW");
                });

            modelBuilder.Entity("DomainModel.Product.HardgoodProduct", b =>
                {
                    b.HasBaseType("DomainModel.Product.AbstractProduct");


                    b.ToTable("HardgoodProduct");

                    b.HasDiscriminator().HasValue("HARD");
                });

            modelBuilder.Entity("DomainModel.CustomerFreightout", b =>
                {
                    b.HasOne("DomainModel.CustomerFreightoutRateType", "CustomerFreightoutRateType")
                        .WithMany("CustomerFreightouts")
                        .HasForeignKey("CustomerFreightoutRateTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DomainModel.Customer", "Customer")
                        .WithMany("CustomerFreightouts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.CustomerOpportunity", b =>
                {
                    b.HasOne("DomainModel.Customer", "Customer")
                        .WithMany("CustomerOpportunities")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.CustomerThirdPartyAppSetting", b =>
                {
                    b.HasOne("DomainModel.Customer", "Customer")
                        .WithMany("CustomerThirdPartyAppSettings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DomainModel.ThirdPartyAppType", "ThirdPartyAppType")
                        .WithMany()
                        .HasForeignKey("ThirdPartyAppTypeId");
                });

            modelBuilder.Entity("DomainModel.File.FileRepository", b =>
                {
                    b.HasOne("DomainModel.File.FileSystemType", "FileSystemType")
                        .WithMany()
                        .HasForeignKey("FileSystemTypeId");
                });

            modelBuilder.Entity("DomainModel.Product.CompositionProductBridge", b =>
                {
                    b.HasOne("DomainModel.Product.AbstractProduct", "CompositionItem")
                        .WithMany()
                        .HasForeignKey("CompositionItemId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DomainModel.Product.CompositionProduct", "CompositionProduct")
                        .WithMany("Items")
                        .HasForeignKey("CompositionProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DomainModel.Product.ProductMedia", b =>
                {
                    b.HasOne("DomainModel.File.FileRepository", "FileRepository")
                        .WithMany()
                        .HasForeignKey("FileRepositoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DomainModel.Product.AbstractProduct", "Product")
                        .WithMany("ProductMedia")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DomainModel.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DomainModel.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DomainModel.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DomainModel.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
