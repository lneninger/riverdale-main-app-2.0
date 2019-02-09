using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class AddtableSampleBox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSettings_Company_CustomerId1",
                schema: "CRM",
                table: "CustomerSettings");

            migrationBuilder.DropTable(
                name: "SaleOpportunityProduct",
                schema: "OPP");

            migrationBuilder.DropIndex(
                name: "IX_CustomerSettings_CustomerId1",
                schema: "CRM",
                table: "CustomerSettings");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                schema: "CRM",
                table: "CustomerSettings");

            migrationBuilder.CreateTable(
                name: "SampleBox",
                schema: "OPP",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Order = table.Column<int>(nullable: false),
                    SaleOpportunityId = table.Column<int>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleBox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleBox_SaleOpportunity_SaleOpportunityId",
                        column: x => x.SaleOpportunityId,
                        principalSchema: "OPP",
                        principalTable: "SaleOpportunity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SampleBoxProduct",
                schema: "OPP",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Order = table.Column<int>(nullable: false),
                    ProductAmount = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    SampleBoxId = table.Column<int>(nullable: false),
                    ProductAllowedColorTypeId = table.Column<int>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleBoxProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleBoxProduct_ProductAllowedColorType_ProductAllowedColorTypeId",
                        column: x => x.ProductAllowedColorTypeId,
                        principalSchema: "PROD",
                        principalTable: "ProductAllowedColorType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SampleBoxProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "PROD",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SampleBoxProduct_SampleBox_SampleBoxId",
                        column: x => x.SampleBoxId,
                        principalSchema: "OPP",
                        principalTable: "SampleBox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 9, 12, 42, 17, 176, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 9, 12, 42, 17, 178, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "CUS",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 9, 12, 42, 17, 220, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "GWR",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 9, 12, 42, 17, 220, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 9, 12, 42, 17, 250, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 9, 12, 42, 17, 250, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 9, 12, 42, 17, 250, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 9, 12, 42, 17, 266, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 9, 12, 42, 17, 266, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 9, 12, 42, 17, 266, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 9, 12, 42, 17, 266, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 9, 12, 42, 17, 284, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 9, 12, 42, 17, 284, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 9, 12, 42, 17, 284, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 9, 12, 42, 17, 320, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 9, 12, 42, 17, 320, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 9, 12, 42, 17, 320, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 9, 12, 42, 17, 240, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 9, 12, 42, 17, 240, DateTimeKind.Utc));

            migrationBuilder.CreateIndex(
                name: "IX_SampleBox_SaleOpportunityId",
                schema: "OPP",
                table: "SampleBox",
                column: "SaleOpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleBoxProduct_ProductAllowedColorTypeId",
                schema: "OPP",
                table: "SampleBoxProduct",
                column: "ProductAllowedColorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleBoxProduct_ProductId",
                schema: "OPP",
                table: "SampleBoxProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleBoxProduct_SampleBoxId",
                schema: "OPP",
                table: "SampleBoxProduct",
                column: "SampleBoxId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSettings_Company_CustomerId",
                schema: "CRM",
                table: "CustomerSettings",
                column: "CustomerId",
                principalSchema: "CRM",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSettings_Company_CustomerId",
                schema: "CRM",
                table: "CustomerSettings");

            migrationBuilder.DropTable(
                name: "SampleBoxProduct",
                schema: "OPP");

            migrationBuilder.DropTable(
                name: "SampleBox",
                schema: "OPP");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                schema: "CRM",
                table: "CustomerSettings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SaleOpportunityProduct",
                schema: "OPP",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    ProductAllowedColorTypeId = table.Column<int>(nullable: true),
                    ProductAmount = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    SaleOpportunityId = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOpportunityProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleOpportunityProduct_ProductAllowedColorType_ProductAllowedColorTypeId",
                        column: x => x.ProductAllowedColorTypeId,
                        principalSchema: "PROD",
                        principalTable: "ProductAllowedColorType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleOpportunityProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "PROD",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleOpportunityProduct_SaleOpportunity_SaleOpportunityId",
                        column: x => x.SaleOpportunityId,
                        principalSchema: "OPP",
                        principalTable: "SaleOpportunity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 6, 3, 5, 863, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 6, 3, 5, 865, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "CUS",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 6, 3, 5, 908, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "GWR",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 6, 3, 5, 908, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 6, 3, 5, 935, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 6, 3, 5, 935, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 6, 3, 5, 935, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 6, 3, 5, 954, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 6, 3, 5, 954, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 6, 3, 5, 954, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 6, 3, 5, 954, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 6, 3, 5, 979, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 6, 3, 5, 979, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 6, 3, 5, 979, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 6, 3, 6, 24, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 6, 3, 6, 24, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 6, 3, 6, 24, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 6, 3, 5, 927, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 8, 6, 3, 5, 927, DateTimeKind.Utc));

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSettings_CustomerId1",
                schema: "CRM",
                table: "CustomerSettings",
                column: "CustomerId1",
                unique: true,
                filter: "[CustomerId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOpportunityProduct_ProductAllowedColorTypeId",
                schema: "OPP",
                table: "SaleOpportunityProduct",
                column: "ProductAllowedColorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOpportunityProduct_ProductId",
                schema: "OPP",
                table: "SaleOpportunityProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOpportunityProduct_SaleOpportunityId",
                schema: "OPP",
                table: "SaleOpportunityProduct",
                column: "SaleOpportunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSettings_Company_CustomerId1",
                schema: "CRM",
                table: "CustomerSettings",
                column: "CustomerId1",
                principalSchema: "CRM",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
