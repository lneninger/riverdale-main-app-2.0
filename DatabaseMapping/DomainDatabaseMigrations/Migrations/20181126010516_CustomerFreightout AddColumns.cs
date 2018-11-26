using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class CustomerFreightoutAddColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SecondLeg",
                schema: "QUOTE",
                table: "CustomerFreightout",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SurchargeHourly",
                schema: "QUOTE",
                table: "CustomerFreightout",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SurchargeYearly",
                schema: "QUOTE",
                table: "CustomerFreightout",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 26, 1, 5, 15, 157, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 26, 1, 5, 15, 159, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 26, 1, 5, 15, 210, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 26, 1, 5, 15, 210, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondLeg",
                schema: "QUOTE",
                table: "CustomerFreightout");

            migrationBuilder.DropColumn(
                name: "SurchargeHourly",
                schema: "QUOTE",
                table: "CustomerFreightout");

            migrationBuilder.DropColumn(
                name: "SurchargeYearly",
                schema: "QUOTE",
                table: "CustomerFreightout");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 26, 0, 53, 40, 906, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 26, 0, 53, 40, 908, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 26, 0, 53, 40, 959, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 26, 0, 53, 40, 959, DateTimeKind.Utc));
        }
    }
}
