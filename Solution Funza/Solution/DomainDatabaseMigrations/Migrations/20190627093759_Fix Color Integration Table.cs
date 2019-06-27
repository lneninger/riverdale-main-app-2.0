using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class FixColorIntegrationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                schema: "MASTERS",
                table: "Color");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FunzaUpdatedDate",
                schema: "MASTERS",
                table: "Color",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FunzaCreatedDate",
                schema: "MASTERS",
                table: "Color",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                schema: "MASTERS",
                table: "Color",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "MASTERS",
                table: "Color");

            migrationBuilder.AlterColumn<string>(
                name: "FunzaUpdatedDate",
                schema: "MASTERS",
                table: "Color",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "FunzaCreatedDate",
                schema: "MASTERS",
                table: "Color",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "State",
                schema: "MASTERS",
                table: "Color",
                nullable: true);
        }
    }
}
