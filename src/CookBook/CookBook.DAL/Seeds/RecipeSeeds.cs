using CookBook.Common.Enums;
using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Seeds;

public static class RecipeSeeds
{
    public static readonly RecipeEntity LemonadeRecipe = new()
    {
        Id = Guid.Parse("fabde0cd-eefe-443f-baf6-3d96cc2cbf2e"),
        Name = "Lemonade",
        Description = "Sweet summer lemonade",
        Duration = TimeSpan.FromMinutes(2.5),
        FoodType = FoodType.Drink,
        ImageUrl =
            @"https://www.thespruceeats.com/thmb/bOkzNHNuzGEH2UUAbmFBtTwAy6M=/2539x2539/smart/filters:no_upscale()/homemade-lemonade-2216227-hero-02copy-767d28c1e7cf468db2282d77103d0bf4.jpg"
    };

    // All images below are from Wikimedia Commons and freely licensed (CC BY, CC BY-SA, or CC0/public domain).
    public static readonly RecipeEntity TomatoSoupRecipe = new()
    {
        Id = Guid.Parse("f1a2b3c4-d5e6-7890-abcd-ef1234560001"),
        Name = "Tomato Soup",
        Description = "A simple, warming tomato soup made with fresh tomatoes, onion and garlic.",
        Duration = TimeSpan.FromMinutes(30),
        FoodType = FoodType.Soup,
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/b/b5/Tomato_soup.jpg"
    };

    public static readonly RecipeEntity SpaghettiBoLogneseRecipe = new()
    {
        Id = Guid.Parse("f1a2b3c4-d5e6-7890-abcd-ef1234560002"),
        Name = "Spaghetti Bolognese",
        Description = "Classic Italian pasta with a rich ground beef and tomato sauce.",
        Duration = TimeSpan.FromMinutes(45),
        FoodType = FoodType.MainDish,
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/c/c4/Spaghetti_bolognese_%28hozinja%29.jpg"
    };

    public static readonly RecipeEntity ChickenStirFryRecipe = new()
    {
        Id = Guid.Parse("f1a2b3c4-d5e6-7890-abcd-ef1234560003"),
        Name = "Chicken Stir Fry",
        Description = "Quick and easy stir-fried chicken with bell peppers and soy sauce.",
        Duration = TimeSpan.FromMinutes(20),
        FoodType = FoodType.MainDish,
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/6/6b/Stir_fry.jpg"
    };

    public static readonly RecipeEntity BananaSmoothieRecipe = new()
    {
        Id = Guid.Parse("f1a2b3c4-d5e6-7890-abcd-ef1234560004"),
        Name = "Banana Smoothie",
        Description = "Creamy banana smoothie with milk and a touch of honey.",
        Duration = TimeSpan.FromMinutes(5),
        FoodType = FoodType.Drink,
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/b/be/Banana_smoothie.jpg"
    };

    public static readonly RecipeEntity ChocolateChipCookiesRecipe = new()
    {
        Id = Guid.Parse("f1a2b3c4-d5e6-7890-abcd-ef1234560005"),
        Name = "Chocolate Chip Cookies",
        Description = "Classic soft and chewy cookies loaded with chocolate chips.",
        Duration = TimeSpan.FromMinutes(25),
        FoodType = FoodType.Dessert,
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/5/50/Chocolate_chip_cookies.jpg"
    };

    public static readonly RecipeEntity ScrambledEggsRecipe = new()
    {
        Id = Guid.Parse("f1a2b3c4-d5e6-7890-abcd-ef1234560006"),
        Name = "Scrambled Eggs",
        Description = "Fluffy scrambled eggs cooked slowly in butter for a creamy result.",
        Duration = TimeSpan.FromMinutes(10),
        FoodType = FoodType.MainDish,
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/2/21/Scrambled_eggs.jpg"
    };

    public static readonly RecipeEntity PancakesRecipe = new()
    {
        Id = Guid.Parse("f1a2b3c4-d5e6-7890-abcd-ef1234560007"),
        Name = "Pancakes",
        Description = "Light and fluffy American-style pancakes, perfect for breakfast.",
        Duration = TimeSpan.FromMinutes(20),
        FoodType = FoodType.Dessert,
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/0/02/Pancakes_2.jpg"
    };

    public static readonly RecipeEntity BeefStewRecipe = new()
    {
        Id = Guid.Parse("f1a2b3c4-d5e6-7890-abcd-ef1234560008"),
        Name = "Beef Stew",
        Description = "Hearty slow-cooked beef stew with carrots, potatoes and onions.",
        Duration = TimeSpan.FromMinutes(120),
        FoodType = FoodType.MainDish,
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/7/77/Beef_stew.jpg"
    };

    public static readonly RecipeEntity HotChocolateRecipe = new()
    {
        Id = Guid.Parse("f1a2b3c4-d5e6-7890-abcd-ef1234560009"),
        Name = "Hot Chocolate",
        Description = "Rich and warming hot chocolate made with real cocoa powder.",
        Duration = TimeSpan.FromMinutes(10),
        FoodType = FoodType.Drink,
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/1/18/Hot_chocolate.jpg"
    };

    public static readonly RecipeEntity GarlicBreadRecipe = new()
    {
        Id = Guid.Parse("f1a2b3c4-d5e6-7890-abcd-ef1234560010"),
        Name = "Garlic Bread",
        Description = "Crispy baguette slices spread with garlic butter and baked until golden.",
        Duration = TimeSpan.FromMinutes(15),
        FoodType = FoodType.MainDish,
        ImageUrl = "https://wsrv.nl/?url=upload.wikimedia.org/wikipedia/commons/4/4b/Garlic_bread.jpg"
    };

    static RecipeSeeds()
    {
        LemonadeRecipe.Ingredients.Add(IngredientAmountSeeds.LemonadeLemon);
        LemonadeRecipe.Ingredients.Add(IngredientAmountSeeds.LemonadeWater);

        TomatoSoupRecipe.Ingredients.Add(IngredientAmountSeeds.TomatoSoupTomato);
        TomatoSoupRecipe.Ingredients.Add(IngredientAmountSeeds.TomatoSoupOnion);
        TomatoSoupRecipe.Ingredients.Add(IngredientAmountSeeds.TomatoSoupGarlic);
        TomatoSoupRecipe.Ingredients.Add(IngredientAmountSeeds.TomatoSoupOliveOil);
        TomatoSoupRecipe.Ingredients.Add(IngredientAmountSeeds.TomatoSoupSalt);

        SpaghettiBoLogneseRecipe.Ingredients.Add(IngredientAmountSeeds.SpagBolGroundBeef);
        SpaghettiBoLogneseRecipe.Ingredients.Add(IngredientAmountSeeds.SpagBolSpaghetti);
        SpaghettiBoLogneseRecipe.Ingredients.Add(IngredientAmountSeeds.SpagBolTomato);
        SpaghettiBoLogneseRecipe.Ingredients.Add(IngredientAmountSeeds.SpagBolOnion);
        SpaghettiBoLogneseRecipe.Ingredients.Add(IngredientAmountSeeds.SpagBolGarlic);
        SpaghettiBoLogneseRecipe.Ingredients.Add(IngredientAmountSeeds.SpagBolOliveOil);

        ChickenStirFryRecipe.Ingredients.Add(IngredientAmountSeeds.StirFryChickenBreast);
        ChickenStirFryRecipe.Ingredients.Add(IngredientAmountSeeds.StirFryBellPepper);
        ChickenStirFryRecipe.Ingredients.Add(IngredientAmountSeeds.StirFryOnion);
        ChickenStirFryRecipe.Ingredients.Add(IngredientAmountSeeds.StirFrySoySauce);
        ChickenStirFryRecipe.Ingredients.Add(IngredientAmountSeeds.StirFryGarlic);

        BananaSmoothieRecipe.Ingredients.Add(IngredientAmountSeeds.SmoothieBanana);
        BananaSmoothieRecipe.Ingredients.Add(IngredientAmountSeeds.SmoothieMilk);
        BananaSmoothieRecipe.Ingredients.Add(IngredientAmountSeeds.SmoothieHoney);

        ChocolateChipCookiesRecipe.Ingredients.Add(IngredientAmountSeeds.CookiesFlour);
        ChocolateChipCookiesRecipe.Ingredients.Add(IngredientAmountSeeds.CookiesButter);
        ChocolateChipCookiesRecipe.Ingredients.Add(IngredientAmountSeeds.CookiesSugar);
        ChocolateChipCookiesRecipe.Ingredients.Add(IngredientAmountSeeds.CookiesEgg);
        ChocolateChipCookiesRecipe.Ingredients.Add(IngredientAmountSeeds.CookiesChocolateChips);

        ScrambledEggsRecipe.Ingredients.Add(IngredientAmountSeeds.ScrambledEggsEgg);
        ScrambledEggsRecipe.Ingredients.Add(IngredientAmountSeeds.ScrambledEggsButter);
        ScrambledEggsRecipe.Ingredients.Add(IngredientAmountSeeds.ScrambledEggsMilk);
        ScrambledEggsRecipe.Ingredients.Add(IngredientAmountSeeds.ScrambledEggsSalt);

        PancakesRecipe.Ingredients.Add(IngredientAmountSeeds.PancakesFlour);
        PancakesRecipe.Ingredients.Add(IngredientAmountSeeds.PancakesEgg);
        PancakesRecipe.Ingredients.Add(IngredientAmountSeeds.PancakesMilk);
        PancakesRecipe.Ingredients.Add(IngredientAmountSeeds.PancakesButter);
        PancakesRecipe.Ingredients.Add(IngredientAmountSeeds.PancakesSugar);

        BeefStewRecipe.Ingredients.Add(IngredientAmountSeeds.StewBeef);
        BeefStewRecipe.Ingredients.Add(IngredientAmountSeeds.StewCarrot);
        BeefStewRecipe.Ingredients.Add(IngredientAmountSeeds.StewPotato);
        BeefStewRecipe.Ingredients.Add(IngredientAmountSeeds.StewOnion);
        BeefStewRecipe.Ingredients.Add(IngredientAmountSeeds.StewGarlic);

        HotChocolateRecipe.Ingredients.Add(IngredientAmountSeeds.HotChocMilk);
        HotChocolateRecipe.Ingredients.Add(IngredientAmountSeeds.HotChocCocoaPowder);
        HotChocolateRecipe.Ingredients.Add(IngredientAmountSeeds.HotChocSugar);
        HotChocolateRecipe.Ingredients.Add(IngredientAmountSeeds.HotChocHoney);

        GarlicBreadRecipe.Ingredients.Add(IngredientAmountSeeds.GarlicBreadBread);
        GarlicBreadRecipe.Ingredients.Add(IngredientAmountSeeds.GarlicBreadButter);
        GarlicBreadRecipe.Ingredients.Add(IngredientAmountSeeds.GarlicBreadGarlic);
    }

    public static DbContext SeedRecipes(this DbContext dbx)
    {
        dbx.Set<RecipeEntity>().AddRange(
            LemonadeRecipe with { Ingredients = new List<IngredientAmountEntity>() },
            TomatoSoupRecipe with { Ingredients = new List<IngredientAmountEntity>() },
            SpaghettiBoLogneseRecipe with { Ingredients = new List<IngredientAmountEntity>() },
            ChickenStirFryRecipe with { Ingredients = new List<IngredientAmountEntity>() },
            BananaSmoothieRecipe with { Ingredients = new List<IngredientAmountEntity>() },
            ChocolateChipCookiesRecipe with { Ingredients = new List<IngredientAmountEntity>() },
            ScrambledEggsRecipe with { Ingredients = new List<IngredientAmountEntity>() },
            PancakesRecipe with { Ingredients = new List<IngredientAmountEntity>() },
            BeefStewRecipe with { Ingredients = new List<IngredientAmountEntity>() },
            HotChocolateRecipe with { Ingredients = new List<IngredientAmountEntity>() },
            GarlicBreadRecipe with { Ingredients = new List<IngredientAmountEntity>() }
        );

        return dbx;
    }
}
