using Microsoft.EntityFrameworkCore.Migrations;

namespace CookBook.DAL.Migrations
{
    public partial class AddOnCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientAmountEntities_Ingredients_IngredientId",
                table: "IngredientAmountEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientAmountEntities_Recipes_RecipeId",
                table: "IngredientAmountEntities");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientAmountEntities_Ingredients_IngredientId",
                table: "IngredientAmountEntities",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientAmountEntities_Recipes_RecipeId",
                table: "IngredientAmountEntities",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientAmountEntities_Ingredients_IngredientId",
                table: "IngredientAmountEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientAmountEntities_Recipes_RecipeId",
                table: "IngredientAmountEntities");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientAmountEntities_Ingredients_IngredientId",
                table: "IngredientAmountEntities",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientAmountEntities_Recipes_RecipeId",
                table: "IngredientAmountEntities",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
