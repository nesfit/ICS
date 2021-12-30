using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookBook.DAL.Migrations
{
    public partial class AddRecipeSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("818f1def-204e-44da-b764-ca28c75e2acc"));

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("df935095-8709-4040-a2bb-b6f97cb416dc"), "Ingredient seeded ingredient 1 description", null!, "Ingredient seeded ingredient 1" },
                    { new Guid("23b3902d-7d4f-4213-9cf0-112348f56238"), "Ingredient seeded ingredient 2 description", null!, "Ingredient seeded ingredient 2" },
                    { new Guid("06a8a2cf-ea03-4095-a3e4-aa0291fe9c75"), "Mineral water", "https://www.pngitem.com/pimgs/m/40-406527_cartoon-glass-of-water-png-glass-of-water.png", "Water" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "Duration", "FoodType", "ImageUrl", "Name" },
                values: new object[] { new Guid("fabde0cd-eefe-443f-baf6-3d96cc2cbf2e"), "Recipe seeded recipe 1 description", new TimeSpan(0, 2, 0, 0, 0), 0, null!, "Recipe seeded recipe 1" });

            migrationBuilder.InsertData(
                table: "IngredientAmountEntities",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId", "Unit" },
                values: new object[] { new Guid("0d4fa150-ad80-4d46-a511-4c666166ec5e"), 1.0, new Guid("df935095-8709-4040-a2bb-b6f97cb416dc"), new Guid("fabde0cd-eefe-443f-baf6-3d96cc2cbf2e"), 0 });

            migrationBuilder.InsertData(
                table: "IngredientAmountEntities",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId", "Unit" },
                values: new object[] { new Guid("87833e66-05ba-4d6b-900b-fe5ace88dbd8"), 2.0, new Guid("23b3902d-7d4f-4213-9cf0-112348f56238"), new Guid("fabde0cd-eefe-443f-baf6-3d96cc2cbf2e"), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IngredientAmountEntities",
                keyColumn: "Id",
                keyValue: new Guid("0d4fa150-ad80-4d46-a511-4c666166ec5e"));

            migrationBuilder.DeleteData(
                table: "IngredientAmountEntities",
                keyColumn: "Id",
                keyValue: new Guid("87833e66-05ba-4d6b-900b-fe5ace88dbd8"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("06a8a2cf-ea03-4095-a3e4-aa0291fe9c75"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("23b3902d-7d4f-4213-9cf0-112348f56238"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("df935095-8709-4040-a2bb-b6f97cb416dc"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("fabde0cd-eefe-443f-baf6-3d96cc2cbf2e"));

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[] { new Guid("818f1def-204e-44da-b764-ca28c75e2acc"), "Mineral Water", "https://www.pngitem.com/pimgs/m/40-406527_cartoon-glass-of-water-png-glass-of-water.png", "Water" });
        }
    }
}
