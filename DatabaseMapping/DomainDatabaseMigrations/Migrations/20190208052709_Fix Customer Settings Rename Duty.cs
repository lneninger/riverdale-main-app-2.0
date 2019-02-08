using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class FixCustomerSettingsRenameDuty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duty",
                schema: "CRM",
                table: "CustomerSettings",
                newName: "DefaultDuty");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 27, 8, 80, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 27, 8, 82, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "CUS",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 27, 8, 125, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "GWR",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 27, 8, 125, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 27, 8, 156, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 27, 8, 156, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 27, 8, 156, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 27, 8, 183, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 27, 8, 183, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 27, 8, 183, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 27, 8, 183, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 27, 8, 204, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 27, 8, 204, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 27, 8, 204, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 27, 8, 240, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 27, 8, 240, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 27, 8, 240, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 27, 8, 143, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 27, 8, 143, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DefaultDuty",
                schema: "CRM",
                table: "CustomerSettings",
                newName: "Duty");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 24, 29, 586, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 24, 29, 588, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "CUS",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 24, 29, 635, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "GWR",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 24, 29, 635, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 24, 29, 662, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 24, 29, 662, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 24, 29, 662, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 24, 29, 680, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 24, 29, 680, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 24, 29, 680, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 24, 29, 679, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 24, 29, 698, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 24, 29, 699, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 24, 29, 699, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 24, 29, 730, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 24, 29, 730, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 24, 29, 730, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 24, 29, 654, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 5, 24, 29, 654, DateTimeKind.Utc));
        }
    }
}
