using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class PriceLevelToTargetPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleOpportunityPriceLevelProduct_SaleOpportunityPriceLevel_SaleOpportunityPriceLevelId",
                table: "SaleOpportunityPriceLevelProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleOpportunityPriceLevel_SaleOpportunity_SaleOpportunityId",
                schema: "OPP",
                table: "SaleOpportunityPriceLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleOpportunityPriceLevel_SaleOpportunitySettings_SaleOpportunitySettingsId",
                schema: "OPP",
                table: "SaleOpportunityPriceLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleOpportunityPriceLevel_SaleSeasonType_SaleSeasonTypeId",
                schema: "OPP",
                table: "SaleOpportunityPriceLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_SampleBox_SaleOpportunityPriceLevel_SaleOpportunityPriceLevelId",
                schema: "OPP",
                table: "SampleBox");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleOpportunityPriceLevel",
                schema: "OPP",
                table: "SaleOpportunityPriceLevel");

            migrationBuilder.RenameTable(
                name: "SaleOpportunityPriceLevel",
                schema: "OPP",
                newName: "SaleOpportunityTargetPrice",
                newSchema: "OPP");

            migrationBuilder.RenameIndex(
                name: "IX_SaleOpportunityPriceLevel_SaleSeasonTypeId",
                schema: "OPP",
                table: "SaleOpportunityTargetPrice",
                newName: "IX_SaleOpportunityTargetPrice_SaleSeasonTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleOpportunityPriceLevel_SaleOpportunitySettingsId",
                schema: "OPP",
                table: "SaleOpportunityTargetPrice",
                newName: "IX_SaleOpportunityTargetPrice_SaleOpportunitySettingsId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleOpportunityPriceLevel_SaleOpportunityId",
                schema: "OPP",
                table: "SaleOpportunityTargetPrice",
                newName: "IX_SaleOpportunityTargetPrice_SaleOpportunityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleOpportunityTargetPrice",
                schema: "OPP",
                table: "SaleOpportunityTargetPrice",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 55, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 58, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "CUS",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 112, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "GWR",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 112, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 171, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 171, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 171, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 195, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 195, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 195, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 195, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 247, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 247, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 247, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 326, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 326, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 326, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 144, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 144, DateTimeKind.Utc));

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOpportunityPriceLevelProduct_SaleOpportunityTargetPrice_SaleOpportunityPriceLevelId",
                table: "SaleOpportunityPriceLevelProduct",
                column: "SaleOpportunityPriceLevelId",
                principalSchema: "OPP",
                principalTable: "SaleOpportunityTargetPrice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOpportunityTargetPrice_SaleOpportunity_SaleOpportunityId",
                schema: "OPP",
                table: "SaleOpportunityTargetPrice",
                column: "SaleOpportunityId",
                principalSchema: "OPP",
                principalTable: "SaleOpportunity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOpportunityTargetPrice_SaleOpportunitySettings_SaleOpportunitySettingsId",
                schema: "OPP",
                table: "SaleOpportunityTargetPrice",
                column: "SaleOpportunitySettingsId",
                principalSchema: "OPP",
                principalTable: "SaleOpportunitySettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOpportunityTargetPrice_SaleSeasonType_SaleSeasonTypeId",
                schema: "OPP",
                table: "SaleOpportunityTargetPrice",
                column: "SaleSeasonTypeId",
                principalSchema: "OPP",
                principalTable: "SaleSeasonType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SampleBox_SaleOpportunityTargetPrice_SaleOpportunityPriceLevelId",
                schema: "OPP",
                table: "SampleBox",
                column: "SaleOpportunityPriceLevelId",
                principalSchema: "OPP",
                principalTable: "SaleOpportunityTargetPrice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleOpportunityPriceLevelProduct_SaleOpportunityTargetPrice_SaleOpportunityPriceLevelId",
                table: "SaleOpportunityPriceLevelProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleOpportunityTargetPrice_SaleOpportunity_SaleOpportunityId",
                schema: "OPP",
                table: "SaleOpportunityTargetPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleOpportunityTargetPrice_SaleOpportunitySettings_SaleOpportunitySettingsId",
                schema: "OPP",
                table: "SaleOpportunityTargetPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleOpportunityTargetPrice_SaleSeasonType_SaleSeasonTypeId",
                schema: "OPP",
                table: "SaleOpportunityTargetPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_SampleBox_SaleOpportunityTargetPrice_SaleOpportunityPriceLevelId",
                schema: "OPP",
                table: "SampleBox");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleOpportunityTargetPrice",
                schema: "OPP",
                table: "SaleOpportunityTargetPrice");

            migrationBuilder.RenameTable(
                name: "SaleOpportunityTargetPrice",
                schema: "OPP",
                newName: "SaleOpportunityPriceLevel",
                newSchema: "OPP");

            migrationBuilder.RenameIndex(
                name: "IX_SaleOpportunityTargetPrice_SaleSeasonTypeId",
                schema: "OPP",
                table: "SaleOpportunityPriceLevel",
                newName: "IX_SaleOpportunityPriceLevel_SaleSeasonTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleOpportunityTargetPrice_SaleOpportunitySettingsId",
                schema: "OPP",
                table: "SaleOpportunityPriceLevel",
                newName: "IX_SaleOpportunityPriceLevel_SaleOpportunitySettingsId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleOpportunityTargetPrice_SaleOpportunityId",
                schema: "OPP",
                table: "SaleOpportunityPriceLevel",
                newName: "IX_SaleOpportunityPriceLevel_SaleOpportunityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleOpportunityPriceLevel",
                schema: "OPP",
                table: "SaleOpportunityPriceLevel",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 8, 55, 38, 573, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 8, 55, 38, 576, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "CUS",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 8, 55, 38, 650, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "GWR",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 8, 55, 38, 650, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 8, 55, 38, 715, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 8, 55, 38, 715, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 8, 55, 38, 715, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 8, 55, 38, 734, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 8, 55, 38, 734, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 8, 55, 38, 734, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 8, 55, 38, 734, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 8, 55, 38, 767, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 8, 55, 38, 767, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 8, 55, 38, 767, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 8, 55, 38, 864, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 8, 55, 38, 864, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 8, 55, 38, 864, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 8, 55, 38, 699, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 8, 55, 38, 699, DateTimeKind.Utc));

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOpportunityPriceLevelProduct_SaleOpportunityPriceLevel_SaleOpportunityPriceLevelId",
                table: "SaleOpportunityPriceLevelProduct",
                column: "SaleOpportunityPriceLevelId",
                principalSchema: "OPP",
                principalTable: "SaleOpportunityPriceLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOpportunityPriceLevel_SaleOpportunity_SaleOpportunityId",
                schema: "OPP",
                table: "SaleOpportunityPriceLevel",
                column: "SaleOpportunityId",
                principalSchema: "OPP",
                principalTable: "SaleOpportunity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOpportunityPriceLevel_SaleOpportunitySettings_SaleOpportunitySettingsId",
                schema: "OPP",
                table: "SaleOpportunityPriceLevel",
                column: "SaleOpportunitySettingsId",
                principalSchema: "OPP",
                principalTable: "SaleOpportunitySettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOpportunityPriceLevel_SaleSeasonType_SaleSeasonTypeId",
                schema: "OPP",
                table: "SaleOpportunityPriceLevel",
                column: "SaleSeasonTypeId",
                principalSchema: "OPP",
                principalTable: "SaleSeasonType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SampleBox_SaleOpportunityPriceLevel_SaleOpportunityPriceLevelId",
                schema: "OPP",
                table: "SampleBox",
                column: "SaleOpportunityPriceLevelId",
                principalSchema: "OPP",
                principalTable: "SaleOpportunityPriceLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
