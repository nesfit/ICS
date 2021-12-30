using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookBook.DAL.Migrations
{
    public partial class AddedImageUrlToIngredientAndRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientAmountEntity_Ingredients_IngredientId",
                table: "IngredientAmountEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientAmountEntity_Recipes_RecipeId",
                table: "IngredientAmountEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientAmountEntity",
                table: "IngredientAmountEntity");

            migrationBuilder.RenameTable(
                name: "IngredientAmountEntity",
                newName: "IngredientAmountEntities");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientAmountEntity_RecipeId",
                table: "IngredientAmountEntities",
                newName: "IX_IngredientAmountEntities_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientAmountEntity_IngredientId",
                table: "IngredientAmountEntities",
                newName: "IX_IngredientAmountEntities_IngredientId");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientAmountEntities",
                table: "IngredientAmountEntities",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("818f1def-204e-44da-b764-ca28c75e2acc"),
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Mineral Water", "https://www.pngitem.com/pimgs/m/40-406527_cartoon-glass-of-water-png-glass-of-water.png" });

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientAmountEntities",
                table: "IngredientAmountEntities");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Ingredients");

            migrationBuilder.RenameTable(
                name: "IngredientAmountEntities",
                newName: "IngredientAmountEntity");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientAmountEntities_RecipeId",
                table: "IngredientAmountEntity",
                newName: "IX_IngredientAmountEntity_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientAmountEntities_IngredientId",
                table: "IngredientAmountEntity",
                newName: "IX_IngredientAmountEntity_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientAmountEntity",
                table: "IngredientAmountEntity",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("818f1def-204e-44da-b764-ca28c75e2acc"),
                column: "Description",
                value: "Mineral");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientAmountEntity_Ingredients_IngredientId",
                table: "IngredientAmountEntity",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientAmountEntity_Recipes_RecipeId",
                table: "IngredientAmountEntity",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
