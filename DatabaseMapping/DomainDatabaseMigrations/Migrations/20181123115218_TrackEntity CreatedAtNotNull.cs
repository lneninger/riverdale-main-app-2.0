using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class TrackEntityCreatedAtNotNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "CNF",
                table: "ThirdPartyAppType",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 5);

            migrationBuilder.InsertData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "BISERP", new DateTime(2018, 11, 23, 11, 52, 18, 5, DateTimeKind.Utc), "Seed", "Business ERP", null, null });

            migrationBuilder.InsertData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "SFORCE", new DateTime(2018, 11, 23, 11, 52, 18, 7, DateTimeKind.Utc), "Seed", "Salesforce", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP");

            migrationBuilder.DeleteData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "CNF",
                table: "ThirdPartyAppType",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 6);
        }
    }
}
