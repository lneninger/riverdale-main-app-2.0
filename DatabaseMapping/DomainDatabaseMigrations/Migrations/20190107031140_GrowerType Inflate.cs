using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class GrowerTypeInflate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grower_GrowerType_GrowerTypeId",
                schema: "CRM",
                table: "Grower");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrowerType",
                schema: "CRM",
                table: "GrowerType");

            migrationBuilder.DropIndex(
                name: "IX_Grower_GrowerTypeId",
                schema: "CRM",
                table: "Grower");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "CRM",
                table: "GrowerType");

            migrationBuilder.DropColumn(
                name: "GrowerTypeId",
                schema: "CRM",
                table: "Grower");

            migrationBuilder.AddColumn<string>(
                name: "IdNew",
                schema: "CRM",
                table: "GrowerType",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "CRM",
                table: "Grower",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrowerType",
                schema: "CRM",
                table: "GrowerType",
                column: "IdNew");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 3, 11, 39, 361, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 3, 11, 39, 365, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                schema: "CRM",
                table: "GrowerType",
                columns: new[] { "IdNew", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "FUNZAMIA", new DateTime(2019, 1, 7, 3, 11, 39, 424, DateTimeKind.Utc), "Seed", "Branch Miami", "Funza Miami", null, null },
                    { "THIRD", new DateTime(2019, 1, 7, 3, 11, 39, 424, DateTimeKind.Utc), "Seed", "Third Party Grower", "Third Party", null, null },
                    { "FUNZABTA", new DateTime(2019, 1, 7, 3, 11, 39, 424, DateTimeKind.Utc), "Seed", "Branch Bogota", "Funza Bogota", null, null }
                });

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 3, 11, 39, 444, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 3, 11, 39, 444, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 3, 11, 39, 444, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 3, 11, 39, 444, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 3, 11, 39, 471, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 3, 11, 39, 471, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 3, 11, 39, 471, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 3, 11, 39, 574, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 3, 11, 39, 574, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 3, 11, 39, 574, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 3, 11, 39, 473, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 3, 11, 39, 473, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GrowerType",
                schema: "CRM",
                table: "GrowerType");

            migrationBuilder.DeleteData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "IdNew",
                keyValue: "FUNZABTA");

            migrationBuilder.DeleteData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "IdNew",
                keyValue: "FUNZAMIA");

            migrationBuilder.DeleteData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "IdNew",
                keyValue: "THIRD");

            migrationBuilder.DropColumn(
                name: "IdNew",
                schema: "CRM",
                table: "GrowerType");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "CRM",
                table: "Grower");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                schema: "CRM",
                table: "GrowerType",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GrowerTypeId",
                schema: "CRM",
                table: "Grower",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrowerType",
                schema: "CRM",
                table: "GrowerType",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 1, 58, 57, 861, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 1, 58, 57, 864, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 1, 58, 57, 942, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 1, 58, 57, 942, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 1, 58, 57, 942, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 1, 58, 57, 942, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 1, 58, 57, 969, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 1, 58, 57, 969, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 1, 58, 57, 969, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 1, 58, 58, 82, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 1, 58, 58, 82, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 1, 58, 58, 82, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 1, 58, 57, 973, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 7, 1, 58, 57, 973, DateTimeKind.Utc));

            migrationBuilder.CreateIndex(
                name: "IX_Grower_GrowerTypeId",
                schema: "CRM",
                table: "Grower",
                column: "GrowerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grower_GrowerType_GrowerTypeId",
                schema: "CRM",
                table: "Grower",
                column: "GrowerTypeId",
                principalSchema: "CRM",
                principalTable: "GrowerType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
