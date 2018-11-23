using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class CustomerThirdPartyAppSettingRenameThridPartyAppTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerThirdPartyAppSetting_ThirdPartyAppType_ThridPartyAppTypeId",
                schema: "CRM",
                table: "CustomerThirdPartyAppSetting");

            migrationBuilder.RenameColumn(
                name: "ThridPartyAppTypeId",
                schema: "CRM",
                table: "CustomerThirdPartyAppSetting",
                newName: "ThirdPartyAppTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerThirdPartyAppSetting_ThridPartyAppTypeId",
                schema: "CRM",
                table: "CustomerThirdPartyAppSetting",
                newName: "IX_CustomerThirdPartyAppSetting_ThirdPartyAppTypeId");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 23, 13, 56, 11, 224, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 23, 13, 56, 11, 227, DateTimeKind.Utc));

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerThirdPartyAppSetting_ThirdPartyAppType_ThirdPartyAppTypeId",
                schema: "CRM",
                table: "CustomerThirdPartyAppSetting",
                column: "ThirdPartyAppTypeId",
                principalSchema: "CNF",
                principalTable: "ThirdPartyAppType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerThirdPartyAppSetting_ThirdPartyAppType_ThirdPartyAppTypeId",
                schema: "CRM",
                table: "CustomerThirdPartyAppSetting");

            migrationBuilder.RenameColumn(
                name: "ThirdPartyAppTypeId",
                schema: "CRM",
                table: "CustomerThirdPartyAppSetting",
                newName: "ThridPartyAppTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerThirdPartyAppSetting_ThirdPartyAppTypeId",
                schema: "CRM",
                table: "CustomerThirdPartyAppSetting",
                newName: "IX_CustomerThirdPartyAppSetting_ThridPartyAppTypeId");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 23, 12, 25, 0, 97, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2018, 11, 23, 12, 25, 0, 99, DateTimeKind.Utc));

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerThirdPartyAppSetting_ThirdPartyAppType_ThridPartyAppTypeId",
                schema: "CRM",
                table: "CustomerThirdPartyAppSetting",
                column: "ThridPartyAppTypeId",
                principalSchema: "CNF",
                principalTable: "ThirdPartyAppType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
