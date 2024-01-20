using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Seeds;

public static class IngredientSeeds
{
    public static readonly IngredientEntity Water = new()
    {
        Id = Guid.Parse("06a8a2cf-ea03-4095-a3e4-aa0291fe9c75"),
        Name = "Water",
        Description = "Mineral water",
        ImageUrl = @"https://www.pngitem.com/pimgs/m/40-406527_cartoon-glass-of-water-png-glass-of-water.png"
    };

    public static readonly IngredientEntity Lemon = new()
    {
        Id = Guid.Parse("df935095-8709-4040-a2bb-b6f97cb416dc"),
        Name = "Lemon",
        Description = "Yellow lemon",
        ImageUrl =
            @"https://www.eatthis.com/wp-content/uploads/sites/4/2020/02/lemons.jpg?quality=82&strip=1&resize=640%2C360"
    };


    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<IngredientEntity>().HasData(
            Lemon,
            Water
        );
}
