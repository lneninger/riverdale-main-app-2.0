using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class ImproveMappingMechanism : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE CRM.Customer set CreatedBy = SYSTEM_USER");


            migrationBuilder.EnsureSchema(
                name: "CNF");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                schema: "QUOTE",
                table: "CustomerOpportunity",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "QUOTE",
                table: "CustomerOpportunity",
                type: "nvarchar(100)",
                nullable: false,
                defaultValueSql: "SYSTEM_USER",
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "QUOTE",
                table: "CustomerOpportunity",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                schema: "FILE",
                table: "FileRepository",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "FILE",
                table: "FileRepository",
                type: "nvarchar(100)",
                nullable: false,
                defaultValueSql: "SYSTEM_USER",
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "FILE",
                table: "FileRepository",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                schema: "CRM",
                table: "Customer",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "CRM",
                table: "Customer",
                type: "nvarchar(100)",
                nullable: false,
                defaultValueSql: "SYSTEM_USER",
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "CRM",
                table: "Customer",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateTable(
                name: "ThirdPartyAppType",
                schema: "CNF",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Id = table.Column<string>(maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThirdPartyAppType", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThirdPartyAppType",
                schema: "CNF");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                schema: "QUOTE",
                table: "CustomerOpportunity",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "QUOTE",
                table: "CustomerOpportunity",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldDefaultValueSql: "SYSTEM_USER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "QUOTE",
                table: "CustomerOpportunity",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                schema: "FILE",
                table: "FileRepository",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "FILE",
                table: "FileRepository",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldDefaultValueSql: "SYSTEM_USER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "FILE",
                table: "FileRepository",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                schema: "CRM",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "CRM",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldDefaultValueSql: "SYSTEM_USER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "CRM",
                table: "Customer",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");
        }
    }
}
