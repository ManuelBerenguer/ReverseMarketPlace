using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReverseMarketPlace.Demands.Infrastructure.Data.EF.Migrations
{
    public partial class SeedData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "UpperCategoryId" },
                values: new object[] { new Guid("89e86259-91c1-4638-b86e-1f8289664fa9"), "Tv & Audio", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("89e86259-91c1-4638-b86e-1f8289664fa9"));
        }
    }
}
