using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SyncModelSnapshot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IngredientAmountEntities_RecipeId",
                table: "IngredientAmountEntities");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientAmountEntities_RecipeId_IngredientId",
                table: "IngredientAmountEntities",
                columns: new[] { "RecipeId", "IngredientId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IngredientAmountEntities_RecipeId_IngredientId",
                table: "IngredientAmountEntities");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientAmountEntities_RecipeId",
                table: "IngredientAmountEntities",
                column: "RecipeId");
        }
    }
}
