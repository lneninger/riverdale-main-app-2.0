using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class FileAddFileSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                schema: "FILE",
                table: "FileRepository",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 24, 19, 30, 33, 391, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 24, 19, 30, 33, 393, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 24, 19, 30, 33, 436, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 24, 19, 30, 33, 436, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 24, 19, 30, 33, 436, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                schema: "FILE",
                table: "FileSystemType",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "AZU", new DateTime(2018, 12, 24, 19, 30, 33, 436, DateTimeKind.Utc), "Seed", "Azure Storage File Repository", "Azure Storage", null, null });

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 24, 19, 30, 33, 559, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 24, 19, 30, 33, 559, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 24, 19, 30, 33, 559, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 24, 19, 30, 33, 440, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 24, 19, 30, 33, 440, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU");

            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                schema: "FILE",
                table: "FileRepository",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 19, 7, 50, 32, 841, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 19, 7, 50, 32, 843, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 19, 7, 50, 32, 871, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 19, 7, 50, 32, 871, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 19, 7, 50, 32, 871, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 19, 7, 50, 32, 941, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 19, 7, 50, 32, 941, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 19, 7, 50, 32, 941, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 19, 7, 50, 32, 873, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 19, 7, 50, 32, 873, DateTimeKind.Utc));
        }
    }
}
