using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Common.Tests.Seeds;

public static class IngredientSeeds
{
    public static readonly IngredientEntity EmptyIngredient = new()
    {
        Id = default,
        Name = default!,
        Description = default!,
        ImageUrl = default!
    };
    
    public static readonly IngredientEntity Water = new()
    {
        Id = Guid.Parse(input: "06a8a2cf-ea03-4095-a3e4-aa0291fe9c75"),
        Name = "Water",
        Description = "Mineral water",
        ImageUrl = "https://www.pngitem.com/pimgs/m/40-406527_cartoon-glass-of-water-png-glass-of-water.png"
    };

    //To ensure that no tests reuse these clones for non-idempotent operations
    public static readonly IngredientEntity WaterUpdate = Water with { Id = Guid.Parse("143332B9-080E-4953-AEA5-BEF64679B052") };
    public static readonly IngredientEntity WaterDelete = Water with { Id = Guid.Parse("274D0CC9-A948-4818-AADB-A8B4C0506619") };

    public static IngredientEntity IngredientEntity1 = new()
    {
        Id = Guid.Parse(input: "df935095-8709-4040-a2bb-b6f97cb416dc"),
        Name = "Ingredient seeded ingredient 1",
        Description = "Ingredient seeded ingredient 1 description",
        ImageUrl = null
    };

    public static IngredientEntity IngredientEntity2 = new()
    {
        Id = Guid.Parse(input: "23b3902d-7d4f-4213-9cf0-112348f56238"),
        Name = "Ingredient seeded ingredient 2",
        Description = "Ingredient seeded ingredient 2 description",
        ImageUrl = null
    };

    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IngredientEntity>().HasData(
            IngredientEntity1,
            IngredientEntity2,
            Water,
            WaterUpdate,
            WaterDelete);
    }
}