using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class FixColoronCompositionItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompositionProductBridgeProduct_FlowerProductCategoryGrade_ProductCategoryGradeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct");

            migrationBuilder.RenameColumn(
                name: "ProductCategoryGradeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct",
                newName: "ProductCategorySizeId");

            migrationBuilder.RenameIndex(
                name: "IX_CompositionProductBridgeProduct_ProductCategoryGradeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct",
                newName: "IX_CompositionProductBridgeProduct_ProductCategorySizeId");

            migrationBuilder.AddColumn<string>(
                name: "ColorTypeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 17, 23, 57, 41, 107, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 17, 23, 57, 41, 109, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "CUS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 17, 23, 57, 41, 148, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "GWR",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 17, 23, 57, 41, 148, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 17, 23, 57, 41, 186, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 17, 23, 57, 41, 186, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 17, 23, 57, 41, 186, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 17, 23, 57, 41, 202, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 17, 23, 57, 41, 202, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 17, 23, 57, 41, 202, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 17, 23, 57, 41, 202, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 17, 23, 57, 41, 219, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 17, 23, 57, 41, 219, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 17, 23, 57, 41, 219, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 17, 23, 57, 41, 255, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 17, 23, 57, 41, 255, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 17, 23, 57, 41, 255, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 17, 23, 57, 41, 175, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 17, 23, 57, 41, 175, DateTimeKind.Utc));

            migrationBuilder.CreateIndex(
                name: "IX_CompositionProductBridgeProduct_ColorTypeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct",
                column: "ColorTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompositionProductBridgeProduct_ProductColorType_ColorTypeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct",
                column: "ColorTypeId",
                principalSchema: "CNF",
                principalTable: "ProductColorType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompositionProductBridgeProduct_FlowerProductCategoryGrade_ProductCategorySizeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct",
                column: "ProductCategorySizeId",
                principalSchema: "PROD",
                principalTable: "FlowerProductCategoryGrade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompositionProductBridgeProduct_ProductColorType_ColorTypeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CompositionProductBridgeProduct_FlowerProductCategoryGrade_ProductCategorySizeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct");

            migrationBuilder.DropIndex(
                name: "IX_CompositionProductBridgeProduct_ColorTypeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct");

            migrationBuilder.DropColumn(
                name: "ColorTypeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct");

            migrationBuilder.RenameColumn(
                name: "ProductCategorySizeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct",
                newName: "ProductCategoryGradeId");

            migrationBuilder.RenameIndex(
                name: "IX_CompositionProductBridgeProduct_ProductCategorySizeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct",
                newName: "IX_CompositionProductBridgeProduct_ProductCategoryGradeId");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 40, 0, 859, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 40, 0, 862, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "CUS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 40, 0, 905, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "GWR",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 40, 0, 905, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 40, 0, 939, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 40, 0, 939, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 40, 0, 939, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 40, 0, 957, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 40, 0, 957, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 40, 0, 957, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 40, 0, 957, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 40, 0, 974, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 40, 0, 974, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 40, 0, 974, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 40, 1, 18, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 40, 1, 18, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 40, 1, 18, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 40, 0, 932, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 16, 40, 0, 932, DateTimeKind.Utc));

            migrationBuilder.AddForeignKey(
                name: "FK_CompositionProductBridgeProduct_FlowerProductCategoryGrade_ProductCategoryGradeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct",
                column: "ProductCategoryGradeId",
                principalSchema: "PROD",
                principalTable: "FlowerProductCategoryGrade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
