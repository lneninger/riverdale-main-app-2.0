using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class CustomerFreightoutAddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerFreightout",
                schema: "QUOTE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    CustomerFreightoutRateTypeId = table.Column<string>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    WProtect = table.Column<decimal>(nullable: false),
                    DateBegin = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFreightout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerFreightout_CustomerFreightoutRateType_CustomerFreightoutRateTypeId",
                        column: x => x.CustomerFreightoutRateTypeId,
                        principalSchema: "QUOTE",
                        principalTable: "CustomerFreightoutRateType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerFreightout_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "CRM",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFreightout_CustomerFreightoutRateTypeId",
                schema: "QUOTE",
                table: "CustomerFreightout",
                column: "CustomerFreightoutRateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFreightout_CustomerId",
                schema: "QUOTE",
                table: "CustomerFreightout",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerFreightout",
                schema: "QUOTE");

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

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 26, 0, 3, 35, 310, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 26, 0, 3, 35, 310, DateTimeKind.Utc));
        }
    }
}
