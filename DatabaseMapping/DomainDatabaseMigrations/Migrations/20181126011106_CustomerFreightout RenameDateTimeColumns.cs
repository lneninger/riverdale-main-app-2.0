using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class CustomerFreightoutRenameDateTimeColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateEnd",
                schema: "QUOTE",
                table: "CustomerFreightout",
                newName: "DateTo");

            migrationBuilder.RenameColumn(
                name: "DateBegin",
                schema: "QUOTE",
                table: "CustomerFreightout",
                newName: "DateFrom");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 26, 1, 11, 5, 924, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 26, 1, 11, 5, 926, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 26, 1, 11, 5, 963, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 26, 1, 11, 5, 963, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTo",
                schema: "QUOTE",
                table: "CustomerFreightout",
                newName: "DateEnd");

            migrationBuilder.RenameColumn(
                name: "DateFrom",
                schema: "QUOTE",
                table: "CustomerFreightout",
                newName: "DateBegin");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 26, 1, 7, 12, 20, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 26, 1, 7, 12, 21, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 26, 1, 7, 12, 58, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 26, 1, 7, 12, 58, DateTimeKind.Utc));
        }
    }
}
