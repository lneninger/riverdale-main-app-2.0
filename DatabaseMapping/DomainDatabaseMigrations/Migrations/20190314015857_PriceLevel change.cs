using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class PriceLevelchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE OPP.SampleBox");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleOpportunity_SaleSeasonType_SaleSeasonTypeId",
                schema: "OPP",
                table: "SaleOpportunity");

            migrationBuilder.DropForeignKey(
                name: "FK_SampleBox_SaleOpportunity_SaleOpportunityId",
                schema: "OPP",
                table: "SampleBox");

            migrationBuilder.DropForeignKey(
                name: "FK_SampleBoxProduct_ProductColorType_ProductColorTypeId",
                schema: "OPP",
                table: "SampleBoxProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_SampleBoxProduct_Product_ProductId",
                schema: "OPP",
                table: "SampleBoxProduct");

            migrationBuilder.DropIndex(
                name: "IX_SampleBoxProduct_ProductColorTypeId",
                schema: "OPP",
                table: "SampleBoxProduct");

            migrationBuilder.DropIndex(
                name: "IX_SaleOpportunitySettings_SaleOpportunityId",
                schema: "OPP",
                table: "SaleOpportunitySettings");

            migrationBuilder.DropIndex(
                name: "IX_SaleOpportunity_SaleSeasonTypeId",
                schema: "OPP",
                table: "SaleOpportunity");

            migrationBuilder.DropColumn(
                name: "ProductAmount",
                schema: "OPP",
                table: "SampleBoxProduct");

            migrationBuilder.DropColumn(
                name: "ProductColorTypeId",
                schema: "OPP",
                table: "SampleBoxProduct");

            migrationBuilder.DropColumn(
                name: "SaleSeasonTypeId",
                schema: "OPP",
                table: "SaleOpportunity");

            migrationBuilder.DropColumn(
                name: "TargetPrice",
                schema: "OPP",
                table: "SaleOpportunity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                schema: "OPP",
                table: "SampleBoxProduct",
                newName: "SaleOpportunityPriceLevelProductId");

            migrationBuilder.RenameIndex(
                name: "IX_SampleBoxProduct_ProductId",
                schema: "OPP",
                table: "SampleBoxProduct",
                newName: "IX_SampleBoxProduct_SaleOpportunityPriceLevelProductId");

            migrationBuilder.RenameColumn(
                name: "SaleOpportunityId",
                schema: "OPP",
                table: "SampleBox",
                newName: "SaleOpportunityPriceLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_SampleBox_SaleOpportunityId",
                schema: "OPP",
                table: "SampleBox",
                newName: "IX_SampleBox_SaleOpportunityPriceLevelId");

            migrationBuilder.CreateTable(
                name: "SaleOpportunityPriceLevel",
                schema: "OPP",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SaleOpportunityId = table.Column<int>(nullable: false),
                    TargetPrice = table.Column<decimal>(nullable: true),
                    SaleSeasonTypeId = table.Column<int>(nullable: false),
                    SaleOpportunitySettingsId = table.Column<int>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOpportunityPriceLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleOpportunityPriceLevel_SaleOpportunity_SaleOpportunityId",
                        column: x => x.SaleOpportunityId,
                        principalSchema: "OPP",
                        principalTable: "SaleOpportunity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleOpportunityPriceLevel_SaleOpportunitySettings_SaleOpportunitySettingsId",
                        column: x => x.SaleOpportunitySettingsId,
                        principalSchema: "OPP",
                        principalTable: "SaleOpportunitySettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleOpportunityPriceLevel_SaleSeasonType_SaleSeasonTypeId",
                        column: x => x.SaleSeasonTypeId,
                        principalSchema: "OPP",
                        principalTable: "SaleSeasonType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleOpportunityPriceLevelProduct",
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
                    SaleOpportunityPriceLevelId = table.Column<int>(nullable: false),
                    ProductColorTypeId = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
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
                        name: "FK_SaleOpportunityPriceLevelProduct_SaleOpportunityPriceLevel_SaleOpportunityPriceLevelId",
                        column: x => x.SaleOpportunityPriceLevelId,
                        principalSchema: "OPP",
                        principalTable: "SaleOpportunityPriceLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 14, 1, 58, 55, 525, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 14, 1, 58, 55, 527, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "CUS",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 14, 1, 58, 55, 570, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "GWR",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 14, 1, 58, 55, 570, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 14, 1, 58, 55, 600, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 14, 1, 58, 55, 600, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 14, 1, 58, 55, 600, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 14, 1, 58, 55, 617, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 14, 1, 58, 55, 617, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 14, 1, 58, 55, 617, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 14, 1, 58, 55, 617, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 14, 1, 58, 55, 634, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 14, 1, 58, 55, 634, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 14, 1, 58, 55, 634, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 14, 1, 58, 55, 682, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 14, 1, 58, 55, 682, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 14, 1, 58, 55, 682, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 14, 1, 58, 55, 590, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 14, 1, 58, 55, 590, DateTimeKind.Utc));

            migrationBuilder.CreateIndex(
                name: "IX_SaleOpportunitySettings_SaleOpportunityId",
                schema: "OPP",
                table: "SaleOpportunitySettings",
                column: "SaleOpportunityId");

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

            migrationBuilder.CreateIndex(
                name: "IX_SaleOpportunityPriceLevel_SaleOpportunityId",
                schema: "OPP",
                table: "SaleOpportunityPriceLevel",
                column: "SaleOpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOpportunityPriceLevel_SaleOpportunitySettingsId",
                schema: "OPP",
                table: "SaleOpportunityPriceLevel",
                column: "SaleOpportunitySettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOpportunityPriceLevel_SaleSeasonTypeId",
                schema: "OPP",
                table: "SaleOpportunityPriceLevel",
                column: "SaleSeasonTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SampleBox_SaleOpportunityPriceLevel_SaleOpportunityPriceLevelId",
                schema: "OPP",
                table: "SampleBox",
                column: "SaleOpportunityPriceLevelId",
                principalSchema: "OPP",
                principalTable: "SaleOpportunityPriceLevel",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SampleBox_SaleOpportunityPriceLevel_SaleOpportunityPriceLevelId",
                schema: "OPP",
                table: "SampleBox");

            migrationBuilder.DropForeignKey(
                name: "FK_SampleBoxProduct_SaleOpportunityPriceLevelProduct_SaleOpportunityPriceLevelProductId",
                schema: "OPP",
                table: "SampleBoxProduct");

            migrationBuilder.DropTable(
                name: "SaleOpportunityPriceLevelProduct");

            migrationBuilder.DropTable(
                name: "SaleOpportunityPriceLevel",
                schema: "OPP");

            migrationBuilder.DropIndex(
                name: "IX_SaleOpportunitySettings_SaleOpportunityId",
                schema: "OPP",
                table: "SaleOpportunitySettings");

            migrationBuilder.RenameColumn(
                name: "SaleOpportunityPriceLevelProductId",
                schema: "OPP",
                table: "SampleBoxProduct",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_SampleBoxProduct_SaleOpportunityPriceLevelProductId",
                schema: "OPP",
                table: "SampleBoxProduct",
                newName: "IX_SampleBoxProduct_ProductId");

            migrationBuilder.RenameColumn(
                name: "SaleOpportunityPriceLevelId",
                schema: "OPP",
                table: "SampleBox",
                newName: "SaleOpportunityId");

            migrationBuilder.RenameIndex(
                name: "IX_SampleBox_SaleOpportunityPriceLevelId",
                schema: "OPP",
                table: "SampleBox",
                newName: "IX_SampleBox_SaleOpportunityId");

            migrationBuilder.AddColumn<int>(
                name: "ProductAmount",
                schema: "OPP",
                table: "SampleBoxProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductColorTypeId",
                schema: "OPP",
                table: "SampleBoxProduct",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SaleSeasonTypeId",
                schema: "OPP",
                table: "SaleOpportunity",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TargetPrice",
                schema: "OPP",
                table: "SaleOpportunity",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 14, 9, 47, 53, 35, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 14, 9, 47, 53, 36, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "CUS",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 14, 9, 47, 53, 71, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "GWR",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 14, 9, 47, 53, 71, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 14, 9, 47, 53, 99, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 14, 9, 47, 53, 99, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 14, 9, 47, 53, 99, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 14, 9, 47, 53, 119, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 14, 9, 47, 53, 119, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 14, 9, 47, 53, 119, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 14, 9, 47, 53, 119, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 14, 9, 47, 53, 137, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 14, 9, 47, 53, 137, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 14, 9, 47, 53, 137, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 14, 9, 47, 53, 167, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 14, 9, 47, 53, 167, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 14, 9, 47, 53, 167, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 14, 9, 47, 53, 89, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 2, 14, 9, 47, 53, 89, DateTimeKind.Utc));

            migrationBuilder.CreateIndex(
                name: "IX_SampleBoxProduct_ProductColorTypeId",
                schema: "OPP",
                table: "SampleBoxProduct",
                column: "ProductColorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOpportunitySettings_SaleOpportunityId",
                schema: "OPP",
                table: "SaleOpportunitySettings",
                column: "SaleOpportunityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleOpportunity_SaleSeasonTypeId",
                schema: "OPP",
                table: "SaleOpportunity",
                column: "SaleSeasonTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOpportunity_SaleSeasonType_SaleSeasonTypeId",
                schema: "OPP",
                table: "SaleOpportunity",
                column: "SaleSeasonTypeId",
                principalSchema: "OPP",
                principalTable: "SaleSeasonType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SampleBox_SaleOpportunity_SaleOpportunityId",
                schema: "OPP",
                table: "SampleBox",
                column: "SaleOpportunityId",
                principalSchema: "OPP",
                principalTable: "SaleOpportunity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SampleBoxProduct_ProductColorType_ProductColorTypeId",
                schema: "OPP",
                table: "SampleBoxProduct",
                column: "ProductColorTypeId",
                principalSchema: "CNF",
                principalTable: "ProductColorType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SampleBoxProduct_Product_ProductId",
                schema: "OPP",
                table: "SampleBoxProduct",
                column: "ProductId",
                principalSchema: "PROD",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
