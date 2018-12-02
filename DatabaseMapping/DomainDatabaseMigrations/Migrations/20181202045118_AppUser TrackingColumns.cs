using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class AppUserTrackingColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 2, 4, 51, 16, 875, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 2, 4, 51, 16, 877, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 2, 4, 51, 16, 920, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 2, 4, 51, 16, 920, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 1, 14, 55, 50, 246, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 1, 14, 55, 50, 247, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 1, 14, 55, 50, 297, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 1, 14, 55, 50, 297, DateTimeKind.Utc));
        }
    }
}
