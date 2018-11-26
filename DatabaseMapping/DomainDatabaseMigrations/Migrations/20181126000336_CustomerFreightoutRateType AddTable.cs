using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class CustomerFreightoutRateTypeAddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerFreightoutRateType",
                schema: "QUOTE",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Id = table.Column<string>(maxLength: 4, nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFreightoutRateType", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 26, 0, 3, 35, 268, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 26, 0, 3, 35, 269, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "CUBE", new DateTime(2018, 11, 26, 0, 3, 35, 310, DateTimeKind.Utc), "Seed", "Rate by volume(cubic meters)", "Cube", null, null },
                    { "BOX", new DateTime(2018, 11, 26, 0, 3, 35, 310, DateTimeKind.Utc), "Seed", "Rate by box(amount of containers)", "Box", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerFreightoutRateType",
                schema: "QUOTE");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 25, 2, 30, 6, 430, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 25, 2, 30, 6, 431, DateTimeKind.Utc));
        }
    }
}
