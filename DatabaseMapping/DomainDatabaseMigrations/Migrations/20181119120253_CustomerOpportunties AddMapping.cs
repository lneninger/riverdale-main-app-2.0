using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class CustomerOpportuntiesAddMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "QUOTE");

            migrationBuilder.RenameTable(
                name: "CustomerOpportunity",
                newName: "CustomerOpportunity",
                newSchema: "QUOTE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "CustomerOpportunity",
                schema: "QUOTE",
                newName: "CustomerOpportunity");
        }
    }
}
