using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class CustomerThirdPartyAppSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerThirdPartyAppSetting",
                schema: "CRM",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    ThridPartyAppTypeId = table.Column<string>(nullable: true),
                    ThirdPartyCustomerId = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerThirdPartyAppSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerThirdPartyAppSetting_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "CRM",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerThirdPartyAppSetting_ThirdPartyAppType_ThridPartyAppTypeId",
                        column: x => x.ThridPartyAppTypeId,
                        principalSchema: "CNF",
                        principalTable: "ThirdPartyAppType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 23, 12, 3, 52, 206, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 23, 12, 3, 52, 207, DateTimeKind.Utc));

            migrationBuilder.CreateIndex(
                name: "IX_CustomerThirdPartyAppSetting_CustomerId",
                schema: "CRM",
                table: "CustomerThirdPartyAppSetting",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerThirdPartyAppSetting_ThridPartyAppTypeId",
                schema: "CRM",
                table: "CustomerThirdPartyAppSetting",
                column: "ThridPartyAppTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerThirdPartyAppSetting",
                schema: "CRM");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 23, 11, 52, 18, 5, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 23, 11, 52, 18, 7, DateTimeKind.Utc));
        }
    }
}
