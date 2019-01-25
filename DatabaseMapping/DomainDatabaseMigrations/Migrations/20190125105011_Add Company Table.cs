using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainDatabaseMigrations.Migrations
{
    public partial class AddCompanyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerThirdPartyAppSetting_Customer_CustomerId",
                schema: "CRM",
                table: "CustomerThirdPartyAppSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_GrowerFreight_Grower_GrowerId",
                schema: "CRM",
                table: "GrowerFreight");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleOpportunity_Customer_CustomerId",
                schema: "OPP",
                table: "SaleOpportunity");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerFreightout_Customer_CustomerId",
                schema: "QUOTE",
                table: "CustomerFreightout");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOpportunity_Customer_CustomerId",
                schema: "QUOTE",
                table: "CustomerOpportunity");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "CRM");

            migrationBuilder.DropTable(
                name: "Grower",
                schema: "CRM");

            migrationBuilder.CreateTable(
                name: "CompanyType",
                schema: "CRM",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Id = table.Column<string>(maxLength: 8, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "CRM",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CompanyTypeId = table.Column<string>(nullable: false),
                    OriginId = table.Column<int>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    OLD_CustomerId = table.Column<int>(nullable: true),
                    OLD_GrowerId = table.Column<int>(nullable: true),
                    Code = table.Column<string>(maxLength: 3, nullable: true),
                    GrowerTypeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_CompanyType_CompanyTypeId",
                        column: x => x.CompanyTypeId,
                        principalSchema: "CRM",
                        principalTable: "CompanyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Company_Location_OriginId",
                        column: x => x.OriginId,
                        principalSchema: "CNF",
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Company_GrowerType_GrowerTypeId",
                        column: x => x.GrowerTypeId,
                        principalSchema: "CRM",
                        principalTable: "GrowerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 25, 10, 50, 9, 752, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 25, 10, 50, 9, 753, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                schema: "CRM",
                table: "CompanyType",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "GWR", new DateTime(2019, 1, 25, 10, 50, 9, 796, DateTimeKind.Utc), "Seed", "Grower/Supplier of Riverdale", "Grower", null, null },
                    { "CUS", new DateTime(2019, 1, 25, 10, 50, 9, 796, DateTimeKind.Utc), "Seed", "Customer of Riverdale", "Customer", null, null }
                });

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 25, 10, 50, 9, 820, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 25, 10, 50, 9, 820, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 25, 10, 50, 9, 820, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 25, 10, 50, 9, 848, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 25, 10, 50, 9, 848, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 25, 10, 50, 9, 848, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 25, 10, 50, 9, 848, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 25, 10, 50, 9, 874, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 25, 10, 50, 9, 874, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 25, 10, 50, 9, 874, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 25, 10, 50, 9, 911, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 25, 10, 50, 9, 911, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 25, 10, 50, 9, 911, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 25, 10, 50, 9, 806, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 25, 10, 50, 9, 806, DateTimeKind.Utc));

            migrationBuilder.CreateIndex(
                name: "IX_Company_CompanyTypeId",
                schema: "CRM",
                table: "Company",
                column: "CompanyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_OriginId",
                schema: "CRM",
                table: "Company",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_GrowerTypeId",
                schema: "CRM",
                table: "Company",
                column: "GrowerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerThirdPartyAppSetting_Company_CustomerId",
                schema: "CRM",
                table: "CustomerThirdPartyAppSetting",
                column: "CustomerId",
                principalSchema: "CRM",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GrowerFreight_Company_GrowerId",
                schema: "CRM",
                table: "GrowerFreight",
                column: "GrowerId",
                principalSchema: "CRM",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOpportunity_Company_CustomerId",
                schema: "OPP",
                table: "SaleOpportunity",
                column: "CustomerId",
                principalSchema: "CRM",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerFreightout_Company_CustomerId",
                schema: "QUOTE",
                table: "CustomerFreightout",
                column: "CustomerId",
                principalSchema: "CRM",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOpportunity_Company_CustomerId",
                schema: "QUOTE",
                table: "CustomerOpportunity",
                column: "CustomerId",
                principalSchema: "CRM",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerThirdPartyAppSetting_Company_CustomerId",
                schema: "CRM",
                table: "CustomerThirdPartyAppSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_GrowerFreight_Company_GrowerId",
                schema: "CRM",
                table: "GrowerFreight");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleOpportunity_Company_CustomerId",
                schema: "OPP",
                table: "SaleOpportunity");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerFreightout_Company_CustomerId",
                schema: "QUOTE",
                table: "CustomerFreightout");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOpportunity_Company_CustomerId",
                schema: "QUOTE",
                table: "CustomerOpportunity");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "CRM");

            migrationBuilder.DropTable(
                name: "CompanyType",
                schema: "CRM");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "CRM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grower",
                schema: "CRM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 3, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", nullable: false, defaultValueSql: "SYSTEM_USER"),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    GrowerTypeId = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    OriginId = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grower", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grower_GrowerType_GrowerTypeId",
                        column: x => x.GrowerTypeId,
                        principalSchema: "CRM",
                        principalTable: "GrowerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grower_Location_OriginId",
                        column: x => x.OriginId,
                        principalSchema: "CNF",
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "BISERP",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 22, 0, 15, 0, 640, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CNF",
                table: "ThirdPartyAppType",
                keyColumn: "Id",
                keyValue: "SFORCE",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 22, 0, 15, 0, 642, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZABTA",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 22, 0, 15, 0, 696, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "FUNZAMIA",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 22, 0, 15, 0, 696, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "CRM",
                table: "GrowerType",
                keyColumn: "Id",
                keyValue: "THIRD",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 22, 0, 15, 0, 696, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AWS",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 22, 0, 15, 0, 715, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "AZU",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 22, 0, 15, 0, 715, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "DB",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 22, 0, 15, 0, 715, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "FILE",
                table: "FileSystemType",
                keyColumn: "Id",
                keyValue: "SYS",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 22, 0, 15, 0, 715, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "EVERYDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 22, 0, 15, 0, 739, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "HOLIDAY",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 22, 0, 15, 0, 739, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "OPP",
                table: "SaleSeasonCategoryType",
                keyColumn: "Id",
                keyValue: "YEARROUND",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 22, 0, 15, 0, 739, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "COMP",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 22, 0, 15, 0, 828, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "FLW",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 22, 0, 15, 0, 828, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "PROD",
                table: "ProductType",
                keyColumn: "Id",
                keyValue: "HARD",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 22, 0, 15, 0, 828, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "BOX",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 22, 0, 15, 0, 753, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "QUOTE",
                table: "CustomerFreightoutRateType",
                keyColumn: "Id",
                keyValue: "CUBE",
                column: "CreatedAt",
                value: new DateTime(2019, 1, 22, 0, 15, 0, 753, DateTimeKind.Utc));

            migrationBuilder.CreateIndex(
                name: "IX_Grower_GrowerTypeId",
                schema: "CRM",
                table: "Grower",
                column: "GrowerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Grower_OriginId",
                schema: "CRM",
                table: "Grower",
                column: "OriginId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerThirdPartyAppSetting_Customer_CustomerId",
                schema: "CRM",
                table: "CustomerThirdPartyAppSetting",
                column: "CustomerId",
                principalSchema: "CRM",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GrowerFreight_Grower_GrowerId",
                schema: "CRM",
                table: "GrowerFreight",
                column: "GrowerId",
                principalSchema: "CRM",
                principalTable: "Grower",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOpportunity_Customer_CustomerId",
                schema: "OPP",
                table: "SaleOpportunity",
                column: "CustomerId",
                principalSchema: "CRM",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerFreightout_Customer_CustomerId",
                schema: "QUOTE",
                table: "CustomerFreightout",
                column: "CustomerId",
                principalSchema: "CRM",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOpportunity_Customer_CustomerId",
                schema: "QUOTE",
                table: "CustomerOpportunity",
                column: "CustomerId",
                principalSchema: "CRM",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
