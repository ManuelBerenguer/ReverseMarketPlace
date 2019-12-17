using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.EF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    DataType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    UpperCategoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_UpperCategoryId",
                        column: x => x.UpperCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTypes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Demands",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BuyerId = table.Column<Guid>(nullable: false),
                    ProductTypeId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<float>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Demands_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypeAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductTypeId = table.Column<Guid>(nullable: false),
                    AttributeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypeAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTypeAttributes_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTypeAttributes_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DemandAttributeValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DemandId = table.Column<Guid>(nullable: false),
                    AttributeId = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandAttributeValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemandAttributeValues_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DemandAttributeValues_Demands_DemandId",
                        column: x => x.DemandId,
                        principalTable: "Demands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UpperCategoryId",
                table: "Categories",
                column: "UpperCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandAttributeValues_AttributeId",
                table: "DemandAttributeValues",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandAttributeValues_DemandId",
                table: "DemandAttributeValues",
                column: "DemandId");

            migrationBuilder.CreateIndex(
                name: "IX_Demands_ProductTypeId",
                table: "Demands",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypeAttributes_AttributeId",
                table: "ProductTypeAttributes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypeAttributes_ProductTypeId",
                table: "ProductTypeAttributes",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_CategoryId",
                table: "ProductTypes",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemandAttributeValues");

            migrationBuilder.DropTable(
                name: "ProductTypeAttributes");

            migrationBuilder.DropTable(
                name: "Demands");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
