using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class FixColorIntegrationTableId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FunzaId",
                schema: "MASTERS",
                table: "Color",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FunzaId",
                schema: "MASTERS",
                table: "Color",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
