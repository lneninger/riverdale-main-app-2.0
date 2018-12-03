using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class UsersChangePasswordHashSaltbytes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("alter table [riverdale].[dbo].[AspNetUsers] drop column[PasswordSalt];  alter table  [riverdale].[dbo].[AspNetUsers]   add[PasswordSalt] varbinary(max);");


            //migrationBuilder.AlterColumn<byte[]>(
            //    name: "PasswordSalt",
            //    table: "AspNetUsers",
            //    type: "varbinary(MAX)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "varbinary(MAX)",
            //    oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 2, 21, 2, 51, 525, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 2, 21, 2, 51, 526, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 2, 21, 2, 51, 557, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 2, 21, 2, 51, 557, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("alter table [riverdale].[dbo].[AspNetUsers] drop column[PasswordSalt];  alter table  [riverdale].[dbo].[AspNetUsers]   add[PasswordSalt] varchar(max);");

            //migrationBuilder.AlterColumn<string>(
            //    name: "PasswordSalt",
            //    table: "AspNetUsers",
            //    type: "varchar(MAX)",
            //    nullable: true,
            //    oldClrType: typeof(byte[]),
            //    oldType: "varbinary(MAX)",
            //    oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 2, 20, 45, 1, 345, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 2, 20, 45, 1, 348, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 2, 20, 45, 1, 395, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 2, 20, 45, 1, 395, DateTimeKind.Utc));
        }
    }
}
