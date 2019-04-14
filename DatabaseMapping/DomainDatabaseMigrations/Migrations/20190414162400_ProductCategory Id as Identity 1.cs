using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class ProductCategoryIdasIdentity1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE PROD.FlowerProductCategoryGrade");
            migrationBuilder.Sql("DELETE PROD.ProductAllowedColorType");
            migrationBuilder.Sql("DELETE PROD.ProductCategory");
            
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategory",
                schema: "PROD",
                table: "ProductCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAllowedColorType",
                schema: "PROD",
                table: "ProductAllowedColorType");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "PROD",
                table: "ProductCategory");

            migrationBuilder.AddColumn<int>(
                name: "Id1",
                schema: "PROD",
                table: "ProductCategory",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                schema: "PROD",
                table: "ProductCategory",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductCategoryId",
                schema: "PROD",
                table: "ProductAllowedColorType",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TempId",
                schema: "PROD",
                table: "ProductAllowedColorType",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ProductCategoryId",
                schema: "PROD",
                table: "Product",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductCategoryId",
                schema: "PROD",
                table: "FlowerProductCategoryGrade",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                schema: "PROD",
                table: "ProductCategory",
                column: "Id1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAllowedColorType",
                schema: "PROD",
                table: "ProductAllowedColorType",
                column: "TempId");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 23, 59, 172, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 23, 59, 174, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "CUS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 23, 59, 213, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "GWR",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 23, 59, 213, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 23, 59, 239, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 23, 59, 239, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 23, 59, 239, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 23, 59, 255, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 23, 59, 255, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 23, 59, 255, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 23, 59, 255, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 23, 59, 271, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 23, 59, 271, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 23, 59, 271, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 23, 59, 311, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 23, 59, 311, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 23, 59, 311, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 23, 59, 232, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 23, 59, 232, DateTimeKind.Utc));

            migrationBuilder.AddForeignKey(
                name: "FK_FlowerProductCategoryGrade_ProductCategory_ProductCategoryId",
                schema: "PROD",
                table: "FlowerProductCategoryGrade",
                column: "ProductCategoryId",
                principalSchema: "PROD",
                principalTable: "ProductCategory",
                principalColumn: "Id1",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_ProductCategoryId",
                schema: "PROD",
                table: "Product",
                column: "ProductCategoryId",
                principalSchema: "PROD",
                principalTable: "ProductCategory",
                principalColumn: "Id1",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAllowedColorType_ProductCategory_ProductCategoryId",
                schema: "PROD",
                table: "ProductAllowedColorType",
                column: "ProductCategoryId",
                principalSchema: "PROD",
                principalTable: "ProductCategory",
                principalColumn: "Id1",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategory",
                schema: "PROD",
                table: "ProductCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAllowedColorType",
                schema: "PROD",
                table: "ProductAllowedColorType");

            migrationBuilder.DropColumn(
                name: "Id1",
                schema: "PROD",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "Identifier",
                schema: "PROD",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "TempId",
                schema: "PROD",
                table: "ProductAllowedColorType");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                schema: "PROD",
                table: "ProductCategory",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCategoryId",
                schema: "PROD",
                table: "ProductAllowedColorType",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ProductCategoryId",
                schema: "PROD",
                table: "Product",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductCategoryId",
                schema: "PROD",
                table: "FlowerProductCategoryGrade",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                schema: "PROD",
                table: "ProductCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAllowedColorType",
                schema: "PROD",
                table: "ProductAllowedColorType",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 11, 16, 40, 649, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 11, 16, 40, 651, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "CUS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 11, 16, 40, 686, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "GWR",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 11, 16, 40, 686, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 11, 16, 40, 714, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 11, 16, 40, 714, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 11, 16, 40, 714, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 11, 16, 40, 727, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 11, 16, 40, 727, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 11, 16, 40, 727, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 11, 16, 40, 727, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 11, 16, 40, 749, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 11, 16, 40, 749, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 11, 16, 40, 749, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 11, 16, 40, 783, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 11, 16, 40, 783, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 11, 16, 40, 783, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 11, 16, 40, 706, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 11, 16, 40, 706, DateTimeKind.Utc));

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
    }
}
