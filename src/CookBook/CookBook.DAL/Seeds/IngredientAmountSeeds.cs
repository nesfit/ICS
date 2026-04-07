using CookBook.Common.Enums;
using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Seeds;

public static class IngredientAmountSeeds
{
    public static readonly IngredientAmountEntity LemonadeLemon = new()
    {
        Id = Guid.Parse("0d4fa150-ad80-4d46-a511-4c666166ec5e"),
        RecipeId = RecipeSeeds.LemonadeRecipe.Id,
        IngredientId = IngredientSeeds.Lemon.Id,
        Amount = 250,
        Unit = Unit.Ml,
        Recipe = RecipeSeeds.LemonadeRecipe,
        Ingredient = IngredientSeeds.Lemon
    };

    public static readonly IngredientAmountEntity LemonadeWater = new()
    {
        Id = Guid.Parse("87833e66-05ba-4d6b-900b-fe5ace88dbd8"),
        RecipeId = RecipeSeeds.LemonadeRecipe.Id,
        IngredientId = IngredientSeeds.Water.Id,
        Amount = 2.0m,
        Unit = Unit.L,
        Recipe = RecipeSeeds.LemonadeRecipe,
        Ingredient = IngredientSeeds.Water
    };

    // --- Tomato Soup ---
    public static readonly IngredientAmountEntity TomatoSoupTomato = new()
    {
        Id = Guid.Parse("cc000001-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.TomatoSoupRecipe.Id,
        IngredientId = IngredientSeeds.Tomato.Id,
        Amount = 600,
        Unit = Unit.G,
        Recipe = RecipeSeeds.TomatoSoupRecipe,
        Ingredient = IngredientSeeds.Tomato
    };

    public static readonly IngredientAmountEntity TomatoSoupOnion = new()
    {
        Id = Guid.Parse("cc000002-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.TomatoSoupRecipe.Id,
        IngredientId = IngredientSeeds.Onion.Id,
        Amount = 150,
        Unit = Unit.G,
        Recipe = RecipeSeeds.TomatoSoupRecipe,
        Ingredient = IngredientSeeds.Onion
    };

    public static readonly IngredientAmountEntity TomatoSoupGarlic = new()
    {
        Id = Guid.Parse("cc000003-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.TomatoSoupRecipe.Id,
        IngredientId = IngredientSeeds.Garlic.Id,
        Amount = 20,
        Unit = Unit.G,
        Recipe = RecipeSeeds.TomatoSoupRecipe,
        Ingredient = IngredientSeeds.Garlic
    };

    public static readonly IngredientAmountEntity TomatoSoupOliveOil = new()
    {
        Id = Guid.Parse("cc000004-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.TomatoSoupRecipe.Id,
        IngredientId = IngredientSeeds.OliveOil.Id,
        Amount = 30,
        Unit = Unit.Ml,
        Recipe = RecipeSeeds.TomatoSoupRecipe,
        Ingredient = IngredientSeeds.OliveOil
    };

    public static readonly IngredientAmountEntity TomatoSoupSalt = new()
    {
        Id = Guid.Parse("cc000005-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.TomatoSoupRecipe.Id,
        IngredientId = IngredientSeeds.Salt.Id,
        Amount = 5,
        Unit = Unit.G,
        Recipe = RecipeSeeds.TomatoSoupRecipe,
        Ingredient = IngredientSeeds.Salt
    };

    // --- Spaghetti Bolognese ---
    public static readonly IngredientAmountEntity SpagBolGroundBeef = new()
    {
        Id = Guid.Parse("cc000006-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.SpaghettiBoLogneseRecipe.Id,
        IngredientId = IngredientSeeds.GroundBeef.Id,
        Amount = 400,
        Unit = Unit.G,
        Recipe = RecipeSeeds.SpaghettiBoLogneseRecipe,
        Ingredient = IngredientSeeds.GroundBeef
    };

    public static readonly IngredientAmountEntity SpagBolSpaghetti = new()
    {
        Id = Guid.Parse("cc000007-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.SpaghettiBoLogneseRecipe.Id,
        IngredientId = IngredientSeeds.Spaghetti.Id,
        Amount = 400,
        Unit = Unit.G,
        Recipe = RecipeSeeds.SpaghettiBoLogneseRecipe,
        Ingredient = IngredientSeeds.Spaghetti
    };

    public static readonly IngredientAmountEntity SpagBolTomato = new()
    {
        Id = Guid.Parse("cc000008-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.SpaghettiBoLogneseRecipe.Id,
        IngredientId = IngredientSeeds.Tomato.Id,
        Amount = 400,
        Unit = Unit.G,
        Recipe = RecipeSeeds.SpaghettiBoLogneseRecipe,
        Ingredient = IngredientSeeds.Tomato
    };

    public static readonly IngredientAmountEntity SpagBolOnion = new()
    {
        Id = Guid.Parse("cc000009-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.SpaghettiBoLogneseRecipe.Id,
        IngredientId = IngredientSeeds.Onion.Id,
        Amount = 150,
        Unit = Unit.G,
        Recipe = RecipeSeeds.SpaghettiBoLogneseRecipe,
        Ingredient = IngredientSeeds.Onion
    };

    public static readonly IngredientAmountEntity SpagBolGarlic = new()
    {
        Id = Guid.Parse("cc000010-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.SpaghettiBoLogneseRecipe.Id,
        IngredientId = IngredientSeeds.Garlic.Id,
        Amount = 20,
        Unit = Unit.G,
        Recipe = RecipeSeeds.SpaghettiBoLogneseRecipe,
        Ingredient = IngredientSeeds.Garlic
    };

    public static readonly IngredientAmountEntity SpagBolOliveOil = new()
    {
        Id = Guid.Parse("cc000011-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.SpaghettiBoLogneseRecipe.Id,
        IngredientId = IngredientSeeds.OliveOil.Id,
        Amount = 30,
        Unit = Unit.Ml,
        Recipe = RecipeSeeds.SpaghettiBoLogneseRecipe,
        Ingredient = IngredientSeeds.OliveOil
    };

    // --- Chicken Stir Fry ---
    public static readonly IngredientAmountEntity StirFryChickenBreast = new()
    {
        Id = Guid.Parse("cc000012-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.ChickenStirFryRecipe.Id,
        IngredientId = IngredientSeeds.ChickenBreast.Id,
        Amount = 500,
        Unit = Unit.G,
        Recipe = RecipeSeeds.ChickenStirFryRecipe,
        Ingredient = IngredientSeeds.ChickenBreast
    };

    public static readonly IngredientAmountEntity StirFryBellPepper = new()
    {
        Id = Guid.Parse("cc000013-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.ChickenStirFryRecipe.Id,
        IngredientId = IngredientSeeds.BellPepper.Id,
        Amount = 200,
        Unit = Unit.G,
        Recipe = RecipeSeeds.ChickenStirFryRecipe,
        Ingredient = IngredientSeeds.BellPepper
    };

    public static readonly IngredientAmountEntity StirFryOnion = new()
    {
        Id = Guid.Parse("cc000014-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.ChickenStirFryRecipe.Id,
        IngredientId = IngredientSeeds.Onion.Id,
        Amount = 150,
        Unit = Unit.G,
        Recipe = RecipeSeeds.ChickenStirFryRecipe,
        Ingredient = IngredientSeeds.Onion
    };

    public static readonly IngredientAmountEntity StirFrySoySauce = new()
    {
        Id = Guid.Parse("cc000015-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.ChickenStirFryRecipe.Id,
        IngredientId = IngredientSeeds.SoySauce.Id,
        Amount = 50,
        Unit = Unit.Ml,
        Recipe = RecipeSeeds.ChickenStirFryRecipe,
        Ingredient = IngredientSeeds.SoySauce
    };

    public static readonly IngredientAmountEntity StirFryGarlic = new()
    {
        Id = Guid.Parse("cc000016-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.ChickenStirFryRecipe.Id,
        IngredientId = IngredientSeeds.Garlic.Id,
        Amount = 20,
        Unit = Unit.G,
        Recipe = RecipeSeeds.ChickenStirFryRecipe,
        Ingredient = IngredientSeeds.Garlic
    };

    // --- Banana Smoothie ---
    public static readonly IngredientAmountEntity SmoothieBanana = new()
    {
        Id = Guid.Parse("cc000017-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.BananaSmoothieRecipe.Id,
        IngredientId = IngredientSeeds.Banana.Id,
        Amount = 200,
        Unit = Unit.G,
        Recipe = RecipeSeeds.BananaSmoothieRecipe,
        Ingredient = IngredientSeeds.Banana
    };

    public static readonly IngredientAmountEntity SmoothieMilk = new()
    {
        Id = Guid.Parse("cc000018-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.BananaSmoothieRecipe.Id,
        IngredientId = IngredientSeeds.Milk.Id,
        Amount = 250,
        Unit = Unit.Ml,
        Recipe = RecipeSeeds.BananaSmoothieRecipe,
        Ingredient = IngredientSeeds.Milk
    };

    public static readonly IngredientAmountEntity SmoothieHoney = new()
    {
        Id = Guid.Parse("cc000019-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.BananaSmoothieRecipe.Id,
        IngredientId = IngredientSeeds.Honey.Id,
        Amount = 30,
        Unit = Unit.G,
        Recipe = RecipeSeeds.BananaSmoothieRecipe,
        Ingredient = IngredientSeeds.Honey
    };

    // --- Chocolate Chip Cookies ---
    public static readonly IngredientAmountEntity CookiesFlour = new()
    {
        Id = Guid.Parse("cc000020-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.ChocolateChipCookiesRecipe.Id,
        IngredientId = IngredientSeeds.Flour.Id,
        Amount = 250,
        Unit = Unit.G,
        Recipe = RecipeSeeds.ChocolateChipCookiesRecipe,
        Ingredient = IngredientSeeds.Flour
    };

    public static readonly IngredientAmountEntity CookiesButter = new()
    {
        Id = Guid.Parse("cc000021-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.ChocolateChipCookiesRecipe.Id,
        IngredientId = IngredientSeeds.Butter.Id,
        Amount = 150,
        Unit = Unit.G,
        Recipe = RecipeSeeds.ChocolateChipCookiesRecipe,
        Ingredient = IngredientSeeds.Butter
    };

    public static readonly IngredientAmountEntity CookiesSugar = new()
    {
        Id = Guid.Parse("cc000022-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.ChocolateChipCookiesRecipe.Id,
        IngredientId = IngredientSeeds.Sugar.Id,
        Amount = 200,
        Unit = Unit.G,
        Recipe = RecipeSeeds.ChocolateChipCookiesRecipe,
        Ingredient = IngredientSeeds.Sugar
    };

    public static readonly IngredientAmountEntity CookiesEgg = new()
    {
        Id = Guid.Parse("cc000023-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.ChocolateChipCookiesRecipe.Id,
        IngredientId = IngredientSeeds.Egg.Id,
        Amount = 100,
        Unit = Unit.G,
        Recipe = RecipeSeeds.ChocolateChipCookiesRecipe,
        Ingredient = IngredientSeeds.Egg
    };

    public static readonly IngredientAmountEntity CookiesChocolateChips = new()
    {
        Id = Guid.Parse("cc000024-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.ChocolateChipCookiesRecipe.Id,
        IngredientId = IngredientSeeds.ChocolateChips.Id,
        Amount = 200,
        Unit = Unit.G,
        Recipe = RecipeSeeds.ChocolateChipCookiesRecipe,
        Ingredient = IngredientSeeds.ChocolateChips
    };

    // --- Scrambled Eggs ---
    public static readonly IngredientAmountEntity ScrambledEggsEgg = new()
    {
        Id = Guid.Parse("cc000025-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.ScrambledEggsRecipe.Id,
        IngredientId = IngredientSeeds.Egg.Id,
        Amount = 200,
        Unit = Unit.G,
        Recipe = RecipeSeeds.ScrambledEggsRecipe,
        Ingredient = IngredientSeeds.Egg
    };

    public static readonly IngredientAmountEntity ScrambledEggsButter = new()
    {
        Id = Guid.Parse("cc000026-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.ScrambledEggsRecipe.Id,
        IngredientId = IngredientSeeds.Butter.Id,
        Amount = 20,
        Unit = Unit.G,
        Recipe = RecipeSeeds.ScrambledEggsRecipe,
        Ingredient = IngredientSeeds.Butter
    };

    public static readonly IngredientAmountEntity ScrambledEggsMilk = new()
    {
        Id = Guid.Parse("cc000027-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.ScrambledEggsRecipe.Id,
        IngredientId = IngredientSeeds.Milk.Id,
        Amount = 50,
        Unit = Unit.Ml,
        Recipe = RecipeSeeds.ScrambledEggsRecipe,
        Ingredient = IngredientSeeds.Milk
    };

    public static readonly IngredientAmountEntity ScrambledEggsSalt = new()
    {
        Id = Guid.Parse("cc000028-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.ScrambledEggsRecipe.Id,
        IngredientId = IngredientSeeds.Salt.Id,
        Amount = 3,
        Unit = Unit.G,
        Recipe = RecipeSeeds.ScrambledEggsRecipe,
        Ingredient = IngredientSeeds.Salt
    };

    // --- Pancakes ---
    public static readonly IngredientAmountEntity PancakesFlour = new()
    {
        Id = Guid.Parse("cc000029-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.PancakesRecipe.Id,
        IngredientId = IngredientSeeds.Flour.Id,
        Amount = 200,
        Unit = Unit.G,
        Recipe = RecipeSeeds.PancakesRecipe,
        Ingredient = IngredientSeeds.Flour
    };

    public static readonly IngredientAmountEntity PancakesEgg = new()
    {
        Id = Guid.Parse("cc000030-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.PancakesRecipe.Id,
        IngredientId = IngredientSeeds.Egg.Id,
        Amount = 100,
        Unit = Unit.G,
        Recipe = RecipeSeeds.PancakesRecipe,
        Ingredient = IngredientSeeds.Egg
    };

    public static readonly IngredientAmountEntity PancakesMilk = new()
    {
        Id = Guid.Parse("cc000031-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.PancakesRecipe.Id,
        IngredientId = IngredientSeeds.Milk.Id,
        Amount = 300,
        Unit = Unit.Ml,
        Recipe = RecipeSeeds.PancakesRecipe,
        Ingredient = IngredientSeeds.Milk
    };

    public static readonly IngredientAmountEntity PancakesButter = new()
    {
        Id = Guid.Parse("cc000032-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.PancakesRecipe.Id,
        IngredientId = IngredientSeeds.Butter.Id,
        Amount = 30,
        Unit = Unit.G,
        Recipe = RecipeSeeds.PancakesRecipe,
        Ingredient = IngredientSeeds.Butter
    };

    public static readonly IngredientAmountEntity PancakesSugar = new()
    {
        Id = Guid.Parse("cc000033-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.PancakesRecipe.Id,
        IngredientId = IngredientSeeds.Sugar.Id,
        Amount = 30,
        Unit = Unit.G,
        Recipe = RecipeSeeds.PancakesRecipe,
        Ingredient = IngredientSeeds.Sugar
    };

    // --- Beef Stew ---
    public static readonly IngredientAmountEntity StewBeef = new()
    {
        Id = Guid.Parse("cc000034-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.BeefStewRecipe.Id,
        IngredientId = IngredientSeeds.Beef.Id,
        Amount = 600,
        Unit = Unit.G,
        Recipe = RecipeSeeds.BeefStewRecipe,
        Ingredient = IngredientSeeds.Beef
    };

    public static readonly IngredientAmountEntity StewCarrot = new()
    {
        Id = Guid.Parse("cc000035-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.BeefStewRecipe.Id,
        IngredientId = IngredientSeeds.Carrot.Id,
        Amount = 200,
        Unit = Unit.G,
        Recipe = RecipeSeeds.BeefStewRecipe,
        Ingredient = IngredientSeeds.Carrot
    };

    public static readonly IngredientAmountEntity StewPotato = new()
    {
        Id = Guid.Parse("cc000036-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.BeefStewRecipe.Id,
        IngredientId = IngredientSeeds.Potato.Id,
        Amount = 400,
        Unit = Unit.G,
        Recipe = RecipeSeeds.BeefStewRecipe,
        Ingredient = IngredientSeeds.Potato
    };

    public static readonly IngredientAmountEntity StewOnion = new()
    {
        Id = Guid.Parse("cc000037-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.BeefStewRecipe.Id,
        IngredientId = IngredientSeeds.Onion.Id,
        Amount = 200,
        Unit = Unit.G,
        Recipe = RecipeSeeds.BeefStewRecipe,
        Ingredient = IngredientSeeds.Onion
    };

    public static readonly IngredientAmountEntity StewGarlic = new()
    {
        Id = Guid.Parse("cc000038-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.BeefStewRecipe.Id,
        IngredientId = IngredientSeeds.Garlic.Id,
        Amount = 30,
        Unit = Unit.G,
        Recipe = RecipeSeeds.BeefStewRecipe,
        Ingredient = IngredientSeeds.Garlic
    };

    // --- Hot Chocolate ---
    public static readonly IngredientAmountEntity HotChocMilk = new()
    {
        Id = Guid.Parse("cc000039-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.HotChocolateRecipe.Id,
        IngredientId = IngredientSeeds.Milk.Id,
        Amount = 300,
        Unit = Unit.Ml,
        Recipe = RecipeSeeds.HotChocolateRecipe,
        Ingredient = IngredientSeeds.Milk
    };

    public static readonly IngredientAmountEntity HotChocCocoaPowder = new()
    {
        Id = Guid.Parse("cc000040-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.HotChocolateRecipe.Id,
        IngredientId = IngredientSeeds.CocoaPowder.Id,
        Amount = 30,
        Unit = Unit.G,
        Recipe = RecipeSeeds.HotChocolateRecipe,
        Ingredient = IngredientSeeds.CocoaPowder
    };

    public static readonly IngredientAmountEntity HotChocSugar = new()
    {
        Id = Guid.Parse("cc000041-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.HotChocolateRecipe.Id,
        IngredientId = IngredientSeeds.Sugar.Id,
        Amount = 30,
        Unit = Unit.G,
        Recipe = RecipeSeeds.HotChocolateRecipe,
        Ingredient = IngredientSeeds.Sugar
    };

    public static readonly IngredientAmountEntity HotChocHoney = new()
    {
        Id = Guid.Parse("cc000042-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.HotChocolateRecipe.Id,
        IngredientId = IngredientSeeds.Honey.Id,
        Amount = 20,
        Unit = Unit.G,
        Recipe = RecipeSeeds.HotChocolateRecipe,
        Ingredient = IngredientSeeds.Honey
    };

    // --- Garlic Bread ---
    public static readonly IngredientAmountEntity GarlicBreadBread = new()
    {
        Id = Guid.Parse("cc000043-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.GarlicBreadRecipe.Id,
        IngredientId = IngredientSeeds.Bread.Id,
        Amount = 400,
        Unit = Unit.G,
        Recipe = RecipeSeeds.GarlicBreadRecipe,
        Ingredient = IngredientSeeds.Bread
    };

    public static readonly IngredientAmountEntity GarlicBreadButter = new()
    {
        Id = Guid.Parse("cc000044-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.GarlicBreadRecipe.Id,
        IngredientId = IngredientSeeds.Butter.Id,
        Amount = 100,
        Unit = Unit.G,
        Recipe = RecipeSeeds.GarlicBreadRecipe,
        Ingredient = IngredientSeeds.Butter
    };

    public static readonly IngredientAmountEntity GarlicBreadGarlic = new()
    {
        Id = Guid.Parse("cc000045-0000-4000-8000-000000000000"),
        RecipeId = RecipeSeeds.GarlicBreadRecipe.Id,
        IngredientId = IngredientSeeds.Garlic.Id,
        Amount = 30,
        Unit = Unit.G,
        Recipe = RecipeSeeds.GarlicBreadRecipe,
        Ingredient = IngredientSeeds.Garlic
    };

    public static DbContext SeedIngredientAmounts(this DbContext dbx)
    {
        dbx.Set<IngredientAmountEntity>().AddRange(
            LemonadeLemon with { Recipe = null!, Ingredient = null! },
            LemonadeWater with { Recipe = null!, Ingredient = null! },
            TomatoSoupTomato with { Recipe = null!, Ingredient = null! },
            TomatoSoupOnion with { Recipe = null!, Ingredient = null! },
            TomatoSoupGarlic with { Recipe = null!, Ingredient = null! },
            TomatoSoupOliveOil with { Recipe = null!, Ingredient = null! },
            TomatoSoupSalt with { Recipe = null!, Ingredient = null! },
            SpagBolGroundBeef with { Recipe = null!, Ingredient = null! },
            SpagBolSpaghetti with { Recipe = null!, Ingredient = null! },
            SpagBolTomato with { Recipe = null!, Ingredient = null! },
            SpagBolOnion with { Recipe = null!, Ingredient = null! },
            SpagBolGarlic with { Recipe = null!, Ingredient = null! },
            SpagBolOliveOil with { Recipe = null!, Ingredient = null! },
            StirFryChickenBreast with { Recipe = null!, Ingredient = null! },
            StirFryBellPepper with { Recipe = null!, Ingredient = null! },
            StirFryOnion with { Recipe = null!, Ingredient = null! },
            StirFrySoySauce with { Recipe = null!, Ingredient = null! },
            StirFryGarlic with { Recipe = null!, Ingredient = null! },
            SmoothieBanana with { Recipe = null!, Ingredient = null! },
            SmoothieMilk with { Recipe = null!, Ingredient = null! },
            SmoothieHoney with { Recipe = null!, Ingredient = null! },
            CookiesFlour with { Recipe = null!, Ingredient = null! },
            CookiesButter with { Recipe = null!, Ingredient = null! },
            CookiesSugar with { Recipe = null!, Ingredient = null! },
            CookiesEgg with { Recipe = null!, Ingredient = null! },
            CookiesChocolateChips with { Recipe = null!, Ingredient = null! },
            ScrambledEggsEgg with { Recipe = null!, Ingredient = null! },
            ScrambledEggsButter with { Recipe = null!, Ingredient = null! },
            ScrambledEggsMilk with { Recipe = null!, Ingredient = null! },
            ScrambledEggsSalt with { Recipe = null!, Ingredient = null! },
            PancakesFlour with { Recipe = null!, Ingredient = null! },
            PancakesEgg with { Recipe = null!, Ingredient = null! },
            PancakesMilk with { Recipe = null!, Ingredient = null! },
            PancakesButter with { Recipe = null!, Ingredient = null! },
            PancakesSugar with { Recipe = null!, Ingredient = null! },
            StewBeef with { Recipe = null!, Ingredient = null! },
            StewCarrot with { Recipe = null!, Ingredient = null! },
            StewPotato with { Recipe = null!, Ingredient = null! },
            StewOnion with { Recipe = null!, Ingredient = null! },
            StewGarlic with { Recipe = null!, Ingredient = null! },
            HotChocMilk with { Recipe = null!, Ingredient = null! },
            HotChocCocoaPowder with { Recipe = null!, Ingredient = null! },
            HotChocSugar with { Recipe = null!, Ingredient = null! },
            HotChocHoney with { Recipe = null!, Ingredient = null! },
            GarlicBreadBread with { Recipe = null!, Ingredient = null! },
            GarlicBreadButter with { Recipe = null!, Ingredient = null! },
            GarlicBreadGarlic with { Recipe = null!, Ingredient = null! }
        );

        return dbx;
    }
}
