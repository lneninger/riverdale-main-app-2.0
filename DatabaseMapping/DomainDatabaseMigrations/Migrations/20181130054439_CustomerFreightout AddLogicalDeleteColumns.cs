using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class CustomerFreightoutAddLogicalDeleteColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "QUOTE",
                table: "CustomerFreightout",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "QUOTE",
                table: "CustomerFreightout",
                type: "nvarchar(100)",
                nullable: false,
                defaultValueSql: "SYSTEM_USER");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "QUOTE",
                table: "CustomerFreightout",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "QUOTE",
                table: "CustomerFreightout",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "QUOTE",
                table: "CustomerFreightout",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "QUOTE",
                table: "CustomerFreightout",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 30, 5, 44, 38, 148, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 30, 5, 44, 38, 149, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 30, 5, 44, 38, 187, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 30, 5, 44, 38, 187, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "QUOTE",
                table: "CustomerFreightout");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "QUOTE",
                table: "CustomerFreightout");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "QUOTE",
                table: "CustomerFreightout");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "QUOTE",
                table: "CustomerFreightout");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "QUOTE",
                table: "CustomerFreightout");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "QUOTE",
                table: "CustomerFreightout");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 29, 11, 23, 31, 742, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 29, 11, 23, 31, 743, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 29, 11, 23, 31, 782, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 29, 11, 23, 31, 782, DateTimeKind.Utc));
        }
    }
}
