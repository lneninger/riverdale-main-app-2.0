using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class FixProductCategoryEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlowerProductCategoryGrade_FlowerProductCategory_FlowerProductCategoryId",
                schema: "PROD",
                table: "FlowerProductCategoryGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_FlowerProductCategory_FlowerProductCategoryId",
                schema: "PROD",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAllowedColorType_FlowerProductCategory_FlowerProductCategoryId",
                schema: "PROD",
                table: "ProductAllowedColorType");

            migrationBuilder.DropTable(
                name: "FlowerProductCategory",
                schema: "PROD");

            migrationBuilder.RenameColumn(
                name: "FlowerProductCategoryId",
                schema: "PROD",
                table: "ProductAllowedColorType",
                newName: "ProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAllowedColorType_FlowerProductCategoryId",
                schema: "PROD",
                table: "ProductAllowedColorType",
                newName: "IX_ProductAllowedColorType_ProductCategoryId");

            migrationBuilder.RenameColumn(
                name: "FlowerProductCategoryId",
                schema: "PROD",
                table: "Product",
                newName: "ProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_FlowerProductCategoryId",
                schema: "PROD",
                table: "Product",
                newName: "IX_Product_ProductCategoryId");

            migrationBuilder.RenameColumn(
                name: "FlowerProductCategoryId",
                schema: "PROD",
                table: "FlowerProductCategoryGrade",
                newName: "ProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_FlowerProductCategoryGrade_FlowerProductCategoryId",
                schema: "PROD",
                table: "FlowerProductCategoryGrade",
                newName: "IX_FlowerProductCategoryGrade_ProductCategoryId");

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "PROD",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Id = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 13, 21, 27, 45, 277, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 13, 21, 27, 45, 279, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "CUS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 13, 21, 27, 45, 339, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "GWR",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 13, 21, 27, 45, 339, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 13, 21, 27, 45, 366, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 13, 21, 27, 45, 366, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 13, 21, 27, 45, 365, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 13, 21, 27, 45, 382, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 13, 21, 27, 45, 382, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 13, 21, 27, 45, 382, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 13, 21, 27, 45, 382, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 13, 21, 27, 45, 405, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 13, 21, 27, 45, 405, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 13, 21, 27, 45, 405, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 13, 21, 27, 45, 483, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 13, 21, 27, 45, 483, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 13, 21, 27, 45, 483, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 13, 21, 27, 45, 358, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 13, 21, 27, 45, 358, DateTimeKind.Utc));

            migrationBuilder.AddForeignKey(
                name: "FK_FlowerProductCategoryGrade_ProductCategory_ProductCategoryId",
                schema: "PROD",
                table: "FlowerProductCategoryGrade",
                column: "ProductCategoryId",
                principalSchema: "PROD",
                principalTable: "ProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_ProductCategoryId",
                schema: "PROD",
                table: "Product",
                column: "ProductCategoryId",
                principalSchema: "PROD",
                principalTable: "ProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAllowedColorType_ProductCategory_ProductCategoryId",
                schema: "PROD",
                table: "ProductAllowedColorType",
                column: "ProductCategoryId",
                principalSchema: "PROD",
                principalTable: "ProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlowerProductCategoryGrade_ProductCategory_ProductCategoryId",
                schema: "PROD",
                table: "FlowerProductCategoryGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategory_ProductCategoryId",
                schema: "PROD",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAllowedColorType_ProductCategory_ProductCategoryId",
                schema: "PROD",
                table: "ProductAllowedColorType");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "PROD");

            migrationBuilder.RenameColumn(
                name: "ProductCategoryId",
                schema: "PROD",
                table: "ProductAllowedColorType",
                newName: "FlowerProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAllowedColorType_ProductCategoryId",
                schema: "PROD",
                table: "ProductAllowedColorType",
                newName: "IX_ProductAllowedColorType_FlowerProductCategoryId");

            migrationBuilder.RenameColumn(
                name: "ProductCategoryId",
                schema: "PROD",
                table: "Product",
                newName: "FlowerProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductCategoryId",
                schema: "PROD",
                table: "Product",
                newName: "IX_Product_FlowerProductCategoryId");

            migrationBuilder.RenameColumn(
                name: "ProductCategoryId",
                schema: "PROD",
                table: "FlowerProductCategoryGrade",
                newName: "FlowerProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_FlowerProductCategoryGrade_ProductCategoryId",
                schema: "PROD",
                table: "FlowerProductCategoryGrade",
                newName: "IX_FlowerProductCategoryGrade_FlowerProductCategoryId");

            migrationBuilder.CreateTable(
                name: "FlowerProductCategory",
                schema: "PROD",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerProductCategory", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 10, 45, 30, 828, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 10, 45, 30, 830, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "CUS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 10, 45, 30, 877, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "GWR",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 10, 45, 30, 877, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 10, 45, 30, 909, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 10, 45, 30, 909, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 10, 45, 30, 909, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 10, 45, 30, 925, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 10, 45, 30, 925, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 10, 45, 30, 925, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 10, 45, 30, 925, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 10, 45, 30, 945, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 10, 45, 30, 945, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 10, 45, 30, 945, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 10, 45, 30, 981, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 10, 45, 30, 981, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 10, 45, 30, 981, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 10, 45, 30, 898, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 10, 45, 30, 898, DateTimeKind.Utc));

            migrationBuilder.AddForeignKey(
                name: "FK_FlowerProductCategoryGrade_FlowerProductCategory_FlowerProductCategoryId",
                schema: "PROD",
                table: "FlowerProductCategoryGrade",
                column: "FlowerProductCategoryId",
                principalSchema: "PROD",
                principalTable: "FlowerProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_FlowerProductCategory_FlowerProductCategoryId",
                schema: "PROD",
                table: "Product",
                column: "FlowerProductCategoryId",
                principalSchema: "PROD",
                principalTable: "FlowerProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAllowedColorType_FlowerProductCategory_FlowerProductCategoryId",
                schema: "PROD",
                table: "ProductAllowedColorType",
                column: "FlowerProductCategoryId",
                principalSchema: "PROD",
                principalTable: "FlowerProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
