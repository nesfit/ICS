using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookBook.DAL.Migrations
{
    public partial class AddSeedingIngredientWater : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("818f1def-204e-44da-b764-ca28c75e2acc"), "Mineral", "Water" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("818f1def-204e-44da-b764-ca28c75e2acc"));
        }
    }
}
