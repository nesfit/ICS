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


    // All images below are from Wikimedia Commons and freely licensed (CC BY, CC BY-SA, or CC0/public domain).
    public static readonly IngredientEntity Tomato = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560001"),
        Name = "Tomato",
        Description = "Fresh ripe tomato",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/8/89/Tomato_je.jpg"
    };

    public static readonly IngredientEntity Onion = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560002"),
        Name = "Onion",
        Description = "Yellow onion",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/2/25/Onion_on_White.JPG"
    };

    public static readonly IngredientEntity Garlic = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560003"),
        Name = "Garlic",
        Description = "Fresh garlic cloves",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/d/d4/Garlic_bulb.jpg"
    };

    public static readonly IngredientEntity OliveOil = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560004"),
        Name = "Olive Oil",
        Description = "Extra virgin olive oil",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/4/49/Olive_oil_from_Oneglia.jpg"
    };

    public static readonly IngredientEntity Salt = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560005"),
        Name = "Salt",
        Description = "Table salt",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/7/78/Salt_shaker_on_white_background.jpg"
    };

    public static readonly IngredientEntity GroundBeef = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560006"),
        Name = "Ground Beef",
        Description = "Lean minced beef",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/2/2b/Minced_meat.jpg"
    };

    public static readonly IngredientEntity Spaghetti = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560007"),
        Name = "Spaghetti",
        Description = "Dry spaghetti pasta",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/5/5d/Spaghetti_1.jpg"
    };

    public static readonly IngredientEntity ChickenBreast = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560008"),
        Name = "Chicken Breast",
        Description = "Boneless, skinless chicken breast",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/1/1a/Chicken_pieces.jpg"
    };

    public static readonly IngredientEntity BellPepper = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560009"),
        Name = "Bell Pepper",
        Description = "Sweet red bell pepper",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/8/83/Red_bell_peppers.jpg"
    };

    public static readonly IngredientEntity SoySauce = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560010"),
        Name = "Soy Sauce",
        Description = "Dark soy sauce",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/1/12/Soy_sauce.jpg"
    };

    public static readonly IngredientEntity Banana = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560011"),
        Name = "Banana",
        Description = "Ripe banana",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/c/c7/Banana.jpg"
    };

    public static readonly IngredientEntity Milk = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560012"),
        Name = "Milk",
        Description = "Whole cow's milk",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/0/0e/Milk_glass.jpg"
    };

    public static readonly IngredientEntity Honey = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560013"),
        Name = "Honey",
        Description = "Natural raw honey",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/c/cc/Runny_hunny.jpg"
    };

    public static readonly IngredientEntity Flour = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560014"),
        Name = "Flour",
        Description = "All-purpose wheat flour",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/6/64/All-Purpose_Flour_%284107895947%29.jpg"
    };

    public static readonly IngredientEntity Egg = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560015"),
        Name = "Egg",
        Description = "Fresh chicken egg",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/5/5e/Chicken_egg_2009-06-04.jpg"
    };

    public static readonly IngredientEntity Butter = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560016"),
        Name = "Butter",
        Description = "Unsalted butter",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/f/f4/Butter_dish.jpg"
    };

    public static readonly IngredientEntity ChocolateChips = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560017"),
        Name = "Chocolate Chips",
        Description = "Semi-sweet chocolate chips",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/3/33/Chocolate_chips.jpg"
    };

    public static readonly IngredientEntity Sugar = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560018"),
        Name = "Sugar",
        Description = "White granulated sugar",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/5/56/Sugar_2xmacro.jpg"
    };

    public static readonly IngredientEntity Carrot = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560019"),
        Name = "Carrot",
        Description = "Fresh carrot",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/d/d2/Carrots_with_stems.jpg"
    };

    public static readonly IngredientEntity Potato = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560020"),
        Name = "Potato",
        Description = "Russet potato",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/c/c8/Potato_and_cross_section.jpg"
    };

    public static readonly IngredientEntity Beef = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560021"),
        Name = "Beef",
        Description = "Beef chuck, cut into cubes",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/2/2e/Roast_beef.jpg"
    };

    public static readonly IngredientEntity CocoaPowder = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560022"),
        Name = "Cocoa Powder",
        Description = "Unsweetened cocoa powder",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/4/4d/Cocoa_powder.jpg"
    };

    public static readonly IngredientEntity Bread = new()
    {
        Id = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234560023"),
        Name = "Bread",
        Description = "White baguette or French bread",
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/3/33/Fresh_made_bread_05.jpg"
    };

    public static DbContext SeedIngredients(this DbContext dbx)
    {
        dbx.Set<IngredientEntity>().AddRange(
            Lemon,
            Water,
            Tomato,
            Onion,
            Garlic,
            OliveOil,
            Salt,
            GroundBeef,
            Spaghetti,
            ChickenBreast,
            BellPepper,
            SoySauce,
            Banana,
            Milk,
            Honey,
            Flour,
            Egg,
            Butter,
            ChocolateChips,
            Sugar,
            Carrot,
            Potato,
            Beef,
            CocoaPowder,
            Bread
        );

        return dbx;
    }
}
