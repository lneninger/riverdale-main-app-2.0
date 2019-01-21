using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class AddFunzaintegrationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                schema: "FUNZA",
                table: "ProductReference",
                newName: "FunzaUpdatedDate");

            migrationBuilder.RenameColumn(
                name: "Observations",
                schema: "FUNZA",
                table: "ProductReference",
                newName: "Comments");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "FUNZA",
                table: "ProductReference",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "FUNZA",
                table: "ProductReference",
                type: "nvarchar(100)",
                nullable: false,
                defaultValueSql: "SYSTEM_USER");

            migrationBuilder.AddColumn<int>(
                name: "FunzaId",
                schema: "FUNZA",
                table: "ProductReference",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "FUNZA",
                table: "ProductReference",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "FUNZA",
                table: "ProductReference",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryReference",
                schema: "FUNZA",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FunzaId = table.Column<int>(nullable: false),
                    ProductCategoryId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_CategoryReference", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColorReference",
                schema: "FUNZA",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    table.PrimaryKey("PK_ColorReference", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackingReference",
                schema: "FUNZA",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    table.PrimaryKey("PK_PackingReference", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 21, 11, 43, 59, 321, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 21, 11, 43, 59, 322, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 21, 11, 43, 59, 353, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 21, 11, 43, 59, 353, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 21, 11, 43, 59, 353, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 21, 11, 43, 59, 381, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 21, 11, 43, 59, 381, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 21, 11, 43, 59, 381, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 21, 11, 43, 59, 381, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 21, 11, 43, 59, 407, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 21, 11, 43, 59, 407, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 21, 11, 43, 59, 407, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 21, 11, 43, 59, 490, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 21, 11, 43, 59, 490, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 21, 11, 43, 59, 490, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 21, 11, 43, 59, 423, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 21, 11, 43, 59, 423, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryReference",
                schema: "FUNZA");

            migrationBuilder.DropTable(
                name: "ColorReference",
                schema: "FUNZA");

            migrationBuilder.DropTable(
                name: "PackingReference",
                schema: "FUNZA");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "FUNZA",
                table: "ProductReference");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "FUNZA",
                table: "ProductReference");

            migrationBuilder.DropColumn(
                name: "FunzaId",
                schema: "FUNZA",
                table: "ProductReference");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "FUNZA",
                table: "ProductReference");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "FUNZA",
                table: "ProductReference");

            migrationBuilder.RenameColumn(
                name: "FunzaUpdatedDate",
                schema: "FUNZA",
                table: "ProductReference",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "Comments",
                schema: "FUNZA",
                table: "ProductReference",
                newName: "Observations");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 15, 11, 51, 29, 446, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 15, 11, 51, 29, 447, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 15, 11, 51, 29, 479, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 15, 11, 51, 29, 479, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 15, 11, 51, 29, 479, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 15, 11, 51, 29, 495, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 15, 11, 51, 29, 495, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 15, 11, 51, 29, 495, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 15, 11, 51, 29, 494, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 15, 11, 51, 29, 514, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 15, 11, 51, 29, 514, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 15, 11, 51, 29, 514, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 15, 11, 51, 29, 598, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 15, 11, 51, 29, 598, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 15, 11, 51, 29, 598, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 15, 11, 51, 29, 520, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 15, 11, 51, 29, 520, DateTimeKind.Utc));
        }
    }
}
