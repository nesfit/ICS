using Microsoft.EntityFrameworkCore.Migrations;

namespace CookBook.DAL.Migrations
{
    public partial class FixIngredientDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientAmountEntity_Ingredients_IngredientId",
                table: "IngredientAmountEntity");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientAmountEntity_Ingredients_IngredientId",
                table: "IngredientAmountEntity",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientAmountEntity_Ingredients_IngredientId",
                table: "IngredientAmountEntity");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientAmountEntity_Ingredients_IngredientId",
                table: "IngredientAmountEntity",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
