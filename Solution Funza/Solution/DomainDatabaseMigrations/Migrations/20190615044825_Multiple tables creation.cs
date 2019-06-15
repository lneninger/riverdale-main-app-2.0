using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class Multipletablescreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "MASTERS",
                table: "Season",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "MASTERS",
                table: "Season",
                type: "nvarchar(100)",
                nullable: false,
                defaultValueSql: "SYSTEM_USER");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "MASTERS",
                table: "Season",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "MASTERS",
                table: "Season",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdjustRequestUserId",
                schema: "FUNZA",
                table: "Quote",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "FUNZA",
                table: "Quote",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComboId",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                schema: "FUNZA",
                table: "Quote",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ConfirmationPackingPrice",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ConfirmationPriceLabor",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CreateStep",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserName",
                schema: "FUNZA",
                table: "Quote",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatorUserId",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalPrice",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "FunzaId",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "LaborDiscount",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifierUserId",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastModifierUserName",
                schema: "FUNZA",
                table: "Quote",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Margen",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "NoBouquets",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Orders",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PackingDescount",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PackingId",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PackingName",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PackingPrice",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PackingPriceId",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerBouquet",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "QuoteAdjustments",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quotes",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SatelliteQuote",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SatelliteQuoteId",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SatelliteQuotes",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "StartingPrice",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "FUNZA",
                table: "Quote",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                schema: "FUNZA",
                table: "Quote",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "GoodPrice",
                schema: "FUNZA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UnitMeasure = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    GoodId = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodPrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packing",
                schema: "FUNZA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    FunzaId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: true),
                    NameEnglish = table.Column<string>(type: "varchar(200)", nullable: true),
                    Description = table.Column<string>(type: "varchar(200)", nullable: true),
                    EquivalentsFull = table.Column<decimal>(nullable: false),
                    Length = table.Column<decimal>(nullable: false),
                    Width = table.Column<decimal>(nullable: false),
                    Height = table.Column<decimal>(nullable: false),
                    Volume = table.Column<decimal>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    State = table.Column<bool>(nullable: false),
                    Image = table.Column<string>(type: "varchar(200)", nullable: true),
                    CargoMasterCode = table.Column<string>(nullable: true),
                    VolumeDescripcion = table.Column<string>(nullable: true),
                    VolumeEquivalentFull = table.Column<decimal>(nullable: false),
                    SentToQuotator = table.Column<bool>(nullable: true),
                    EquivalentFullQuotator = table.Column<string>(nullable: true),
                    FunzaCreatedBy = table.Column<string>(nullable: true),
                    FunzaCreatedDate = table.Column<DateTime>(nullable: false),
                    FunzaUpdatedBy = table.Column<string>(nullable: true),
                    FunzaUpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "FUNZA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    FunzaId = table.Column<int>(nullable: false),
                    SpecieId = table.Column<int>(nullable: false),
                    VariatyId = table.Column<int>(nullable: false),
                    SizeId = table.Column<int>(nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(type: "varchar(200)", nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", nullable: true),
                    Comments = table.Column<string>(type: "varchar(200)", nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    CategoryName = table.Column<string>(type: "varchar(200)", nullable: true),
                    ProductTypeId = table.Column<int>(nullable: false),
                    ProductTypeName = table.Column<string>(type: "varchar(200)", nullable: true),
                    ReferenceId = table.Column<int>(nullable: false),
                    ReferenceCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    ReferenceDescription = table.Column<string>(type: "varchar(200)", nullable: true),
                    ReferenceTypeId = table.Column<int>(nullable: false),
                    ReferenceTypeName = table.Column<string>(type: "varchar(200)", nullable: true),
                    SendQuotator = table.Column<bool>(nullable: false),
                    FunzaUpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "MASTERS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    FunzaId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    ToOrder = table.Column<bool>(nullable: false),
                    ToStem = table.Column<bool>(nullable: false),
                    FunzaCreatedBy = table.Column<string>(nullable: true),
                    FunzaCreatedDate = table.Column<DateTime>(nullable: false),
                    FunzaUpdatedBy = table.Column<string>(nullable: true),
                    FunzaUpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                schema: "MASTERS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    FunzaId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    NameEnglish = table.Column<string>(type: "varchar(200)", nullable: false),
                    State = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    Hexagecimal = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    FunzaCreatedBy = table.Column<string>(nullable: true),
                    FunzaCreatedDate = table.Column<string>(nullable: true),
                    FunzaUpdatedBy = table.Column<string>(nullable: true),
                    FunzaUpdatedDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Labor",
                schema: "MASTERS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Code = table.Column<string>(nullable: false),
                    UnitAmount = table.Column<int>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    BouquetTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodPrice",
                schema: "FUNZA");

            migrationBuilder.DropTable(
                name: "Packing",
                schema: "FUNZA");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "FUNZA");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "MASTERS");

            migrationBuilder.DropTable(
                name: "Color",
                schema: "MASTERS");

            migrationBuilder.DropTable(
                name: "Labor",
                schema: "MASTERS");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "MASTERS",
                table: "Season");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "MASTERS",
                table: "Season");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "MASTERS",
                table: "Season");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "MASTERS",
                table: "Season");

            migrationBuilder.DropColumn(
                name: "AdjustRequestUserId",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "ComboId",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "Comments",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "ConfirmationPackingPrice",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "ConfirmationPriceLabor",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "CreateStep",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "CreatedByUserName",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "FinalPrice",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "FunzaId",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "LaborDiscount",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "LastModifierUserName",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "Margen",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "NoBouquets",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "Orders",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "PackingDescount",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "PackingId",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "PackingName",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "PackingPrice",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "PackingPriceId",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "PricePerBouquet",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "QuoteAdjustments",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "Quotes",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "SatelliteQuote",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "SatelliteQuoteId",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "SatelliteQuotes",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "StartingPrice",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "FUNZA",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                schema: "FUNZA",
                table: "Quote");
        }
    }
}
