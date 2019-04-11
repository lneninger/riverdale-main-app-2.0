using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class AddFlowerCategoryAndGrades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductColorType_ProductColorTypeId",
                schema: "PROD",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductColorTypeId",
                schema: "PROD",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductColorTypeId",
                schema: "PROD",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "FlowerProductCategoryId",
                schema: "PROD",
                table: "Product",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlowerProductCategoryGradeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FlowerProductCategory",
                schema: "PROD",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Id = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerProductCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlowerProductCategoryGrade",
                schema: "PROD",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Id = table.Column<int>(maxLength: 4, nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    FlowerProductCategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerProductCategoryGrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowerProductCategoryGrade_FlowerProductCategory_FlowerProductCategoryId",
                        column: x => x.FlowerProductCategoryId,
                        principalSchema: "PROD",
                        principalTable: "FlowerProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 9, 17, 35, 627, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 9, 17, 35, 629, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "CUS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 9, 17, 35, 666, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "GWR",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 9, 17, 35, 666, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 9, 17, 35, 700, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 9, 17, 35, 700, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 9, 17, 35, 700, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 9, 17, 35, 719, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 9, 17, 35, 719, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 9, 17, 35, 719, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 9, 17, 35, 719, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 9, 17, 35, 741, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 9, 17, 35, 741, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 9, 17, 35, 741, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 9, 17, 35, 774, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 9, 17, 35, 774, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 9, 17, 35, 774, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 9, 17, 35, 690, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 4, 11, 9, 17, 35, 690, DateTimeKind.Utc));

            migrationBuilder.CreateIndex(
                name: "IX_Product_FlowerProductCategoryId",
                schema: "PROD",
                table: "Product",
                column: "FlowerProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompositionProductBridgeProduct_FlowerProductCategoryGradeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct",
                column: "FlowerProductCategoryGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerProductCategoryGrade_FlowerProductCategoryId",
                schema: "PROD",
                table: "FlowerProductCategoryGrade",
                column: "FlowerProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompositionProductBridgeProduct_FlowerProductCategoryGrade_FlowerProductCategoryGradeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct",
                column: "FlowerProductCategoryGradeId",
                principalSchema: "PROD",
                principalTable: "FlowerProductCategoryGrade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_FlowerProductCategory_FlowerProductCategoryId",
                schema: "PROD",
                table: "Product",
                column: "FlowerProductCategoryId",
                principalSchema: "PROD",
                principalTable: "FlowerProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompositionProductBridgeProduct_FlowerProductCategoryGrade_FlowerProductCategoryGradeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_FlowerProductCategory_FlowerProductCategoryId",
                schema: "PROD",
                table: "Product");

            migrationBuilder.DropTable(
                name: "FlowerProductCategoryGrade",
                schema: "PROD");

            migrationBuilder.DropTable(
                name: "FlowerProductCategory",
                schema: "PROD");

            migrationBuilder.DropIndex(
                name: "IX_Product_FlowerProductCategoryId",
                schema: "PROD",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_CompositionProductBridgeProduct_FlowerProductCategoryGradeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct");

            migrationBuilder.DropColumn(
                name: "FlowerProductCategoryId",
                schema: "PROD",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "FlowerProductCategoryGradeId",
                schema: "PROD",
                table: "CompositionProductBridgeProduct");

            migrationBuilder.AddColumn<string>(
                name: "ProductColorTypeId",
                schema: "PROD",
                table: "Product",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 22, 9, 0, 52, 547, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 22, 9, 0, 52, 548, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "CUS",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 22, 9, 0, 52, 585, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: "GWR",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 22, 9, 0, 52, 585, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 22, 9, 0, 52, 616, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 22, 9, 0, 52, 616, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 22, 9, 0, 52, 615, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 22, 9, 0, 52, 632, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 22, 9, 0, 52, 632, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 22, 9, 0, 52, 632, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 22, 9, 0, 52, 632, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 22, 9, 0, 52, 651, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 22, 9, 0, 52, 651, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 22, 9, 0, 52, 651, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 22, 9, 0, 52, 690, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 22, 9, 0, 52, 690, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 22, 9, 0, 52, 690, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 22, 9, 0, 52, 607, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 3, 22, 9, 0, 52, 607, DateTimeKind.Utc));

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductColorTypeId",
                schema: "PROD",
                table: "Product",
                column: "ProductColorTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductColorType_ProductColorTypeId",
                schema: "PROD",
                table: "Product",
                column: "ProductColorTypeId",
                principalSchema: "CNF",
                principalTable: "ProductColorType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
