using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class FileSystemType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PROD");

            migrationBuilder.AddColumn<int>(
                name: "FileSize",
                schema: "FILE",
                table: "FileRepository",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FileSystemTypeId",
                schema: "FILE",
                table: "FileRepository",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullFilePath",
                schema: "FILE",
                table: "FileRepository",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThumbnailFileSize",
                schema: "FILE",
                table: "FileRepository",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailFullFilePath",
                schema: "FILE",
                table: "FileRepository",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FileSystemType",
                schema: "FILE",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Id = table.Column<string>(maxLength: 4, nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileSystemType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "PROD",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ProductTypeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                schema: "PROD",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Id = table.Column<string>(maxLength: 4, nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompositionProductBridgeProduct",
                schema: "PROD",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompositionProductId = table.Column<int>(nullable: false),
                    CompositionItemId = table.Column<int>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompositionProductBridgeProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompositionProductBridgeProduct_Product_CompositionItemId",
                        column: x => x.CompositionItemId,
                        principalSchema: "PROD",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompositionProductBridgeProduct_Product_CompositionProductId",
                        column: x => x.CompositionProductId,
                        principalSchema: "PROD",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductMedia",
                schema: "PROD",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(maxLength: 4, nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    FileRepositoryId = table.Column<int>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductMedia_FileRepository_FileRepositoryId",
                        column: x => x.FileRepositoryId,
                        principalSchema: "FILE",
                        principalTable: "FileRepository",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMedia_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "PROD",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 12, 0, 38, 24, 44, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 12, 0, 38, 24, 46, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                schema: "FILE",
                table: "FileSystemType",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "DB", new DateTime(2018, 12, 12, 0, 38, 24, 100, DateTimeKind.Utc), "Seed", "Internal Database Repository", "Database", null, null },
                    { "AWS", new DateTime(2018, 12, 12, 0, 38, 24, 100, DateTimeKind.Utc), "Seed", "Amazon S3 File Repository", "AWS S3", null, null },
                    { "SYS", new DateTime(2018, 12, 12, 0, 38, 24, 100, DateTimeKind.Utc), "Seed", "File System Repository", "File System", null, null }
                });

            migrationBuilder.InsertData(
                schema: "PROD",
                table: "ProductType",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "FLW", new DateTime(2018, 12, 12, 0, 38, 24, 208, DateTimeKind.Utc), "Seed", "Raw Flower", "Flower", null, null },
                    { "COMP", new DateTime(2018, 12, 12, 0, 38, 24, 208, DateTimeKind.Utc), "Seed", "Multiple Product Composition. Kit", "Composition", null, null },
                    { "HARD", new DateTime(2018, 12, 12, 0, 38, 24, 208, DateTimeKind.Utc), "Seed", "Hardgood", "Hardgood", null, null }
                });

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 12, 0, 38, 24, 106, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 12, 0, 38, 24, 106, DateTimeKind.Utc));

            migrationBuilder.CreateIndex(
                name: "IX_FileRepository_FileSystemTypeId",
                schema: "FILE",
                table: "FileRepository",
                column: "FileSystemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompositionProductBridgeProduct_CompositionItemId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct",
                column: "CompositionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CompositionProductBridgeProduct_CompositionProductId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct",
                column: "CompositionProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMedia_FileRepositoryId",
                schema: "PROD",
                table: "ProductMedia",
                column: "FileRepositoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMedia_ProductId",
                schema: "PROD",
                table: "ProductMedia",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileRepository_FileSystemType_FileSystemTypeId",
                schema: "FILE",
                table: "FileRepository",
                column: "FileSystemTypeId",
                principalSchema: "FILE",
                principalTable: "FileSystemType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileRepository_FileSystemType_FileSystemTypeId",
                schema: "FILE",
                table: "FileRepository");

            migrationBuilder.DropTable(
                name: "FileSystemType",
                schema: "FILE");

            migrationBuilder.DropTable(
                name: "CompositionProductBridgeProduct",
                schema: "PROD");

            migrationBuilder.DropTable(
                name: "ProductMedia",
                schema: "PROD");

            migrationBuilder.DropTable(
                name: "ProductType",
                schema: "PROD");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "PROD");

            migrationBuilder.DropIndex(
                name: "IX_FileRepository_FileSystemTypeId",
                schema: "FILE",
                table: "FileRepository");

            migrationBuilder.DropColumn(
                name: "FileSize",
                schema: "FILE",
                table: "FileRepository");

            migrationBuilder.DropColumn(
                name: "FileSystemTypeId",
                schema: "FILE",
                table: "FileRepository");

            migrationBuilder.DropColumn(
                name: "FullFilePath",
                schema: "FILE",
                table: "FileRepository");

            migrationBuilder.DropColumn(
                name: "ThumbnailFileSize",
                schema: "FILE",
                table: "FileRepository");

            migrationBuilder.DropColumn(
                name: "ThumbnailFullFilePath",
                schema: "FILE",
                table: "FileRepository");

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 7, 2, 25, 15, 985, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 7, 2, 25, 15, 987, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 7, 2, 25, 16, 24, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2018, 12, 7, 2, 25, 16, 23, DateTimeKind.Utc));
        }
    }
}
