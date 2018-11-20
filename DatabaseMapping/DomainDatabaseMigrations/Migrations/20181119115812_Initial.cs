using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CRM");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "CRM",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar", maxLength: 100, nullable: false),
                    ERPCode = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileRepository",
                schema: "CRM",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RootPath = table.Column<string>(type: "nvarchar", maxLength: 100, nullable: false),
                    AccessPath = table.Column<string>(type: "nvarchar", maxLength: 500, nullable: true),
                    RelativePath = table.Column<string>(type: "nvarchar", maxLength: 500, nullable: true),
                    FileName = table.Column<string>(type: "nvarchar", maxLength: 150, nullable: false),
                    ThumbnailFileName = table.Column<string>(type: "nvarchar", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileRepository", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOpportunity",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOpportunity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerOpportunity_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "CRM",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOpportunity_CustomerId",
                table: "CustomerOpportunity",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOpportunity");

            migrationBuilder.DropTable(
                name: "FileRepository",
                schema: "CRM");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "CRM");
        }
    }
}
