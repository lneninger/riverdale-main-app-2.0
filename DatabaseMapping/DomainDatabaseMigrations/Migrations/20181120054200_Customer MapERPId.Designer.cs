﻿// <auto-generated />
using System;
using DomainDatabaseMapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DomainDatabaseMigrations.Migrations
{
    [DbContext(typeof(MigrationDBContext))]
    [Migration("20181120054200_Customer MapERPId")]
    partial class CustomerMapERPId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("ERPId")
                        .IsRequired()
                        .HasColumnType("nvarchar")
                        .HasMaxLength(50);

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Customer","CRM");
                });

            modelBuilder.Entity("DomainModel.CustomerOpportunity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerOpportunity","QUOTE");
                });

            modelBuilder.Entity("DomainModel.FileRepository", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessPath")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

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

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("FileRepository","FILE");
                });

            modelBuilder.Entity("DomainModel.CustomerOpportunity", b =>
                {
                    b.HasOne("DomainModel.Customer", "Customer")
                        .WithMany("CustomerOpportunities")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
