using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class CustomerRenameERPCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ERPCode",
                schema: "CRM",
                table: "Customer",
                newName: "ERPId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ERPId",
                schema: "CRM",
                table: "Customer",
                newName: "ERPCode");
        }
    }
}
