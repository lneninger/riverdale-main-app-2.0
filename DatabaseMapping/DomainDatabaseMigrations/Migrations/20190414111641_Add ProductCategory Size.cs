using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class AddProductCategorySize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompositionProductBridgeProduct_FlowerProductCategoryGrade_FlowerProductCategoryGradeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "PROD",
                table: "FlowerProductCategoryGrade",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "FlowerProductCategoryGradeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct",
                newName: "ProductCategoryGradeId");

            migrationBuilder.RenameIndex(
                name: "IX_CompositionProductBridgeProduct_FlowerProductCategoryGradeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct",
                newName: "IX_CompositionProductBridgeProduct_ProductCategoryGradeId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "PROD",
                table: "FlowerProductCategoryGrade",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "PROD",
                table: "FlowerProductCategoryGrade",
                nullable: true);

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
                name: "FK_CompositionProductBridgeProduct_FlowerProductCategoryGrade_ProductCategoryGradeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct",
                column: "ProductCategoryGradeId",
                principalSchema: "PROD",
                principalTable: "FlowerProductCategoryGrade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompositionProductBridgeProduct_FlowerProductCategoryGrade_ProductCategoryGradeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "PROD",
                table: "FlowerProductCategoryGrade");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "PROD",
                table: "FlowerProductCategoryGrade");

            migrationBuilder.RenameColumn(
                name: "Size",
                schema: "PROD",
                table: "FlowerProductCategoryGrade",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProductCategoryGradeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct",
                newName: "FlowerProductCategoryGradeId");

            migrationBuilder.RenameIndex(
                name: "IX_CompositionProductBridgeProduct_ProductCategoryGradeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct",
                newName: "IX_CompositionProductBridgeProduct_FlowerProductCategoryGradeId");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 0, 57, 7, 842, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 0, 57, 7, 844, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "CUS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 0, 57, 7, 900, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "GWR",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 0, 57, 7, 900, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 0, 57, 7, 932, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 0, 57, 7, 932, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 0, 57, 7, 932, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 0, 57, 7, 951, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 0, 57, 7, 951, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 0, 57, 7, 951, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 0, 57, 7, 951, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 0, 57, 7, 970, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 0, 57, 7, 970, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 0, 57, 7, 970, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 0, 57, 8, 31, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 0, 57, 8, 31, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 0, 57, 8, 31, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 0, 57, 7, 922, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 14, 0, 57, 7, 922, DateTimeKind.Utc));

            migrationBuilder.AddForeignKey(
                name: "FK_CompositionProductBridgeProduct_FlowerProductCategoryGrade_FlowerProductCategoryGradeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct",
                column: "FlowerProductCategoryGradeId",
                principalSchema: "PROD",
                principalTable: "FlowerProductCategoryGrade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
