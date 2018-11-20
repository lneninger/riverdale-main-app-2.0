using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class FileRepositoryChangeSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FILE");

            migrationBuilder.RenameTable(
                name: "FileRepository",
                schema: "CRM",
                newName: "FileRepository",
                newSchema: "FILE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "FileRepository",
                schema: "FILE",
                newName: "FileRepository",
                newSchema: "CRM");
        }
    }
}
