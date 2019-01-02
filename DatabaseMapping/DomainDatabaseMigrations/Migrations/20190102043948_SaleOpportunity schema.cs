using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class SaleOpportunityschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "OPP");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                schema: "PROD",
                table: "ProductType",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "PROD",
                table: "ProductType",
                type: "nvarchar(100)",
                nullable: false,
                defaultValueSql: "SYSTEM_USER",
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "PROD",
                table: "ProductType",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                schema: "PROD",
                table: "ProductMedia",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "PROD",
                table: "ProductMedia",
                type: "nvarchar(100)",
                nullable: false,
                defaultValueSql: "SYSTEM_USER",
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "PROD",
                table: "ProductMedia",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                schema: "PROD",
                table: "Product",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "PROD",
                table: "Product",
                type: "nvarchar(100)",
                nullable: false,
                defaultValueSql: "SYSTEM_USER",
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "PROD",
                table: "Product",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SaleSeasonCategoryType",
                schema: "OPP",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Id = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleSeasonCategoryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleSeasonType",
                schema: "OPP",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SaleSeasonCategoryTypeId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleSeasonType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleSeasonType_SaleSeasonCategoryType_SaleSeasonCategoryTypeId",
                        column: x => x.SaleSeasonCategoryTypeId,
                        principalSchema: "OPP",
                        principalTable: "SaleSeasonCategoryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleOpportunity",
                schema: "OPP",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    SaleSeasonTypeId = table.Column<int>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOpportunity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleOpportunity_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "CRM",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleOpportunity_SaleSeasonType_SaleSeasonTypeId",
                        column: x => x.SaleSeasonTypeId,
                        principalSchema: "OPP",
                        principalTable: "SaleSeasonType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleOpportunityProduct",
                schema: "OPP",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SaleOpportunityId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOpportunityProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleOpportunityProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "PROD",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleOpportunityProduct_SaleOpportunity_SaleOpportunityId",
                        column: x => x.SaleOpportunityId,
                        principalSchema: "OPP",
                        principalTable: "SaleOpportunity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 2, 4, 39, 47, 100, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 2, 4, 39, 47, 102, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 2, 4, 39, 47, 168, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 2, 4, 39, 47, 168, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 2, 4, 39, 47, 168, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 2, 4, 39, 47, 168, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "EVERYDAY", new DateTime(2019, 1, 2, 4, 39, 47, 185, DateTimeKind.Utc), "Seed", "Available at any moment", "Every day", null, null },
                    { "HOLIDAY", new DateTime(2019, 1, 2, 4, 39, 47, 185, DateTimeKind.Utc), "Seed", "Holiday", "Holiday", null, null },
                    { "YEARROUND", new DateTime(2019, 1, 2, 4, 39, 47, 185, DateTimeKind.Utc), "Seed", "Sale around the year", "Year round", null, null }
                });

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 2, 4, 39, 47, 282, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 2, 4, 39, 47, 282, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 2, 4, 39, 47, 282, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 2, 4, 39, 47, 187, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 2, 4, 39, 47, 187, DateTimeKind.Utc));

            migrationBuilder.CreateIndex(
                name: "IX_SaleOpportunity_CustomerId",
                schema: "OPP",
                table: "SaleOpportunity",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOpportunity_SaleSeasonTypeId",
                schema: "OPP",
                table: "SaleOpportunity",
                column: "SaleSeasonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOpportunityProduct_ProductId",
                schema: "OPP",
                table: "SaleOpportunityProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOpportunityProduct_SaleOpportunityId",
                schema: "OPP",
                table: "SaleOpportunityProduct",
                column: "SaleOpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleSeasonType_SaleSeasonCategoryTypeId",
                schema: "OPP",
                table: "SaleSeasonType",
                column: "SaleSeasonCategoryTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleOpportunityProduct",
                schema: "OPP");

            migrationBuilder.DropTable(
                name: "SaleOpportunity",
                schema: "OPP");

            migrationBuilder.DropTable(
                name: "SaleSeasonType",
                schema: "OPP");

            migrationBuilder.DropTable(
                name: "SaleSeasonCategoryType",
                schema: "OPP");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                schema: "PROD",
                table: "ProductType",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "PROD",
                table: "ProductType",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldDefaultValueSql: "SYSTEM_USER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "PROD",
                table: "ProductType",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                schema: "PROD",
                table: "ProductMedia",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "PROD",
                table: "ProductMedia",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldDefaultValueSql: "SYSTEM_USER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "PROD",
                table: "ProductMedia",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                schema: "PROD",
                table: "Product",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "PROD",
                table: "Product",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldDefaultValueSql: "SYSTEM_USER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "PROD",
                table: "Product",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 1, 19, 32, 52, 977, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 1, 19, 32, 52, 979, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 1, 19, 32, 53, 24, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 1, 19, 32, 53, 24, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 1, 19, 32, 53, 24, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 1, 19, 32, 53, 24, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 1, 19, 32, 53, 127, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 1, 19, 32, 53, 127, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 1, 19, 32, 53, 127, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 1, 19, 32, 53, 27, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 1, 19, 32, 53, 27, DateTimeKind.Utc));
        }
    }
}
