using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookBook.DAL.Migrations
{
    public partial class Addednavigationproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IngredientAmoutEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Unit = table.Column<int>(nullable: false),
                    RecipeId = table.Column<Guid>(nullable: true),
                    IngredientId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientAmoutEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientAmoutEntity_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngredientAmoutEntity_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientAmoutEntity_IngredientId",
                table: "IngredientAmoutEntity",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientAmoutEntity_RecipeId",
                table: "IngredientAmoutEntity",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientAmoutEntity");
        }
    }
}
