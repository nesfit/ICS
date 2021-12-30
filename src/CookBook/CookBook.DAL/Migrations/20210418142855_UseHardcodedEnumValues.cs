using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookBook.DAL.Migrations
{
    public partial class UseHardcodedEnumValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IngredientAmountEntities",
                keyColumn: "Id",
                keyValue: new Guid("0d4fa150-ad80-4d46-a511-4c666166ec5e"),
                column: "Unit",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientAmountEntities",
                keyColumn: "Id",
                keyValue: new Guid("87833e66-05ba-4d6b-900b-fe5ace88dbd8"),
                column: "Unit",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("fabde0cd-eefe-443f-baf6-3d96cc2cbf2e"),
                column: "FoodType",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IngredientAmountEntities",
                keyColumn: "Id",
                keyValue: new Guid("0d4fa150-ad80-4d46-a511-4c666166ec5e"),
                column: "Unit",
                value: 0);

            migrationBuilder.UpdateData(
                table: "IngredientAmountEntities",
                keyColumn: "Id",
                keyValue: new Guid("87833e66-05ba-4d6b-900b-fe5ace88dbd8"),
                column: "Unit",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("fabde0cd-eefe-443f-baf6-3d96cc2cbf2e"),
                column: "FoodType",
                value: 0);
        }
    }
}
