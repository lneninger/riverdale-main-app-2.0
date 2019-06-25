using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class ImproveFunzaMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "MASTERS",
                table: "Color",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IntegrationId",
                schema: "MASTERS",
                table: "Color",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "MASTERS",
                table: "Color",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "MASTERS",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IntegrationId",
                schema: "MASTERS",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "MASTERS",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "FUNZA",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IntegrationId",
                schema: "FUNZA",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "FUNZA",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "FUNZA",
                table: "Packing",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IntegrationId",
                schema: "FUNZA",
                table: "Packing",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "FUNZA",
                table: "Packing",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "MASTERS",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "IntegrationId",
                schema: "MASTERS",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "MASTERS",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "MASTERS",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "IntegrationId",
                schema: "MASTERS",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "MASTERS",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "FUNZA",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IntegrationId",
                schema: "FUNZA",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "FUNZA",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "FUNZA",
                table: "Packing");

            migrationBuilder.DropColumn(
                name: "IntegrationId",
                schema: "FUNZA",
                table: "Packing");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "FUNZA",
                table: "Packing");
        }
    }
}
