using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class PriceLevelToTargetPrice2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SampleBox_SaleOpportunityTargetPrice_SaleOpportunityPriceLevelId",
                schema: "OPP",
                table: "SampleBox");

            migrationBuilder.DropForeignKey(
                name: "FK_SampleBoxProduct_SaleOpportunityPriceLevelProduct_SaleOpportunityPriceLevelProductId",
                schema: "OPP",
                table: "SampleBoxProduct");

            migrationBuilder.DropTable(
                name: "SaleOpportunityPriceLevelProduct");

            migrationBuilder.RenameColumn(
                name: "SaleOpportunityPriceLevelProductId",
                schema: "OPP",
                table: "SampleBoxProduct",
                newName: "SaleOpportunityTargetPriceProductId");

            migrationBuilder.RenameIndex(
                name: "IX_SampleBoxProduct_SaleOpportunityPriceLevelProductId",
                schema: "OPP",
                table: "SampleBoxProduct",
                newName: "IX_SampleBoxProduct_SaleOpportunityTargetPriceProductId");

            migrationBuilder.RenameColumn(
                name: "SaleOpportunityPriceLevelId",
                schema: "OPP",
                table: "SampleBox",
                newName: "SaleOpportunityTargetPriceId");

            migrationBuilder.RenameIndex(
                name: "IX_SampleBox_SaleOpportunityPriceLevelId",
                schema: "OPP",
                table: "SampleBox",
                newName: "IX_SampleBox_SaleOpportunityTargetPriceId");

            migrationBuilder.CreateTable(
                name: "SaleOpportunityTargetPriceProduct",
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
                    SaleOpportunityTargetPriceId = table.Column<int>(nullable: false),
                    ProductColorTypeId = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOpportunityTargetPriceProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleOpportunityTargetPriceProduct_ProductColorType_ProductColorTypeId",
                        column: x => x.ProductColorTypeId,
                        principalSchema: "CNF",
                        principalTable: "ProductColorType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleOpportunityTargetPriceProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "PROD",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleOpportunityTargetPriceProduct_SaleOpportunityTargetPrice_SaleOpportunityTargetPriceId",
                        column: x => x.SaleOpportunityTargetPriceId,
                        principalSchema: "OPP",
                        principalTable: "SaleOpportunityTargetPrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 37, 31, 420, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 37, 31, 424, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "CUS",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 37, 31, 505, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "GWR",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 37, 31, 505, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 37, 31, 566, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 37, 31, 566, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 37, 31, 566, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 37, 31, 595, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 37, 31, 595, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 37, 31, 595, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 37, 31, 594, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 37, 31, 630, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 37, 31, 630, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 37, 31, 630, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 37, 31, 707, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 37, 31, 707, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 37, 31, 707, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 37, 31, 552, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 37, 31, 552, DateTimeKind.Utc));

            migrationBuilder.CreateIndex(
                name: "IX_SaleOpportunityTargetPriceProduct_ProductColorTypeId",
                table: "SaleOpportunityTargetPriceProduct",
                column: "ProductColorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOpportunityTargetPriceProduct_ProductId",
                table: "SaleOpportunityTargetPriceProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOpportunityTargetPriceProduct_SaleOpportunityTargetPriceId",
                table: "SaleOpportunityTargetPriceProduct",
                column: "SaleOpportunityTargetPriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_SampleBox_SaleOpportunityTargetPrice_SaleOpportunityTargetPriceId",
                schema: "OPP",
                table: "SampleBox",
                column: "SaleOpportunityTargetPriceId",
                principalSchema: "OPP",
                principalTable: "SaleOpportunityTargetPrice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SampleBoxProduct_SaleOpportunityTargetPriceProduct_SaleOpportunityTargetPriceProductId",
                schema: "OPP",
                table: "SampleBoxProduct",
                column: "SaleOpportunityTargetPriceProductId",
                principalTable: "SaleOpportunityTargetPriceProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SampleBox_SaleOpportunityTargetPrice_SaleOpportunityTargetPriceId",
                schema: "OPP",
                table: "SampleBox");

            migrationBuilder.DropForeignKey(
                name: "FK_SampleBoxProduct_SaleOpportunityTargetPriceProduct_SaleOpportunityTargetPriceProductId",
                schema: "OPP",
                table: "SampleBoxProduct");

            migrationBuilder.DropTable(
                name: "SaleOpportunityTargetPriceProduct");

            migrationBuilder.RenameColumn(
                name: "SaleOpportunityTargetPriceProductId",
                schema: "OPP",
                table: "SampleBoxProduct",
                newName: "SaleOpportunityPriceLevelProductId");

            migrationBuilder.RenameIndex(
                name: "IX_SampleBoxProduct_SaleOpportunityTargetPriceProductId",
                schema: "OPP",
                table: "SampleBoxProduct",
                newName: "IX_SampleBoxProduct_SaleOpportunityPriceLevelProductId");

            migrationBuilder.RenameColumn(
                name: "SaleOpportunityTargetPriceId",
                schema: "OPP",
                table: "SampleBox",
                newName: "SaleOpportunityPriceLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_SampleBox_SaleOpportunityTargetPriceId",
                schema: "OPP",
                table: "SampleBox",
                newName: "IX_SampleBox_SaleOpportunityPriceLevelId");

            migrationBuilder.CreateTable(
                name: "SaleOpportunityPriceLevelProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    ProductAmount = table.Column<int>(nullable: false),
                    ProductColorTypeId = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    SaleOpportunityPriceLevelId = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOpportunityPriceLevelProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleOpportunityPriceLevelProduct_ProductColorType_ProductColorTypeId",
                        column: x => x.ProductColorTypeId,
                        principalSchema: "CNF",
                        principalTable: "ProductColorType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleOpportunityPriceLevelProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "PROD",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleOpportunityPriceLevelProduct_SaleOpportunityTargetPrice_SaleOpportunityPriceLevelId",
                        column: x => x.SaleOpportunityPriceLevelId,
                        principalSchema: "OPP",
                        principalTable: "SaleOpportunityTargetPrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 55, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 58, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "CUS",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 112, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "GWR",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 112, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 171, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 171, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 171, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 195, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 195, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 195, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 195, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 247, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 247, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 247, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 326, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 326, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 326, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 144, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 20, 9, 0, 24, 144, DateTimeKind.Utc));

            migrationBuilder.CreateIndex(
                name: "IX_SaleOpportunityPriceLevelProduct_ProductColorTypeId",
                table: "SaleOpportunityPriceLevelProduct",
                column: "ProductColorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOpportunityPriceLevelProduct_ProductId",
                table: "SaleOpportunityPriceLevelProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOpportunityPriceLevelProduct_SaleOpportunityPriceLevelId",
                table: "SaleOpportunityPriceLevelProduct",
                column: "SaleOpportunityPriceLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_SampleBox_SaleOpportunityTargetPrice_SaleOpportunityPriceLevelId",
                schema: "OPP",
                table: "SampleBox",
                column: "SaleOpportunityPriceLevelId",
                principalSchema: "OPP",
                principalTable: "SaleOpportunityTargetPrice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SampleBoxProduct_SaleOpportunityPriceLevelProduct_SaleOpportunityPriceLevelProductId",
                schema: "OPP",
                table: "SampleBoxProduct",
                column: "SaleOpportunityPriceLevelProductId",
                principalTable: "SaleOpportunityPriceLevelProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
