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

                    b.Property<string>("ThirdPartyCustomerId")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ThridPartyAppTypeId");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("ColumnOrder", 102);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("ColumnOrder", 103);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ThridPartyAppTypeId");

                    b.ToTable("CustomerThirdPartyAppSetting","CRM");
                });

            modelBuilder.Entity("DomainModel.FileRepository", b =>
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

                    b.Property<DateTime?>("UpdatedAt")
                        .HasAnnotation("ColumnOrder", 102);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("ColumnOrder", 103);

                    b.HasKey("Id");

                    b.ToTable("FileRepository","FILE");
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
                        new { Id = "BISERP", CreatedAt = new DateTime(2018, 11, 23, 12, 25, 0, 97, DateTimeKind.Utc), CreatedBy = "Seed", Name = "Business ERP" },
                        new { Id = "SFORCE", CreatedAt = new DateTime(2018, 11, 23, 12, 25, 0, 99, DateTimeKind.Utc), CreatedBy = "Seed", Name = "Salesforce" }
                    );
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
                        .HasForeignKey("ThridPartyAppTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
