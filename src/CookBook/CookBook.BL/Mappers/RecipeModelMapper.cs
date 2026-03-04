using CookBook.BL.Models;
using CookBook.DAL.Entities;

namespace CookBook.BL.Mappers;

public class RecipeModelMapper
    : ModelMapperBase<RecipeEntity, RecipeListModel, RecipeDetailModel>
{
    public override RecipeListModel MapToListModel(RecipeEntity? entity)
        => entity is null
            ? RecipeListModel.Empty
            : new RecipeListModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Duration = entity.Duration,
                FoodType = entity.FoodType,
                ImageUrl = entity.ImageUrl
            };

    public override RecipeDetailModel MapToDetailModel(RecipeEntity? entity)
        => entity is null
            ? RecipeDetailModel.Empty
            : new RecipeDetailModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Duration = entity.Duration,
                FoodType = entity.FoodType,
                ImageUrl = entity.ImageUrl,
                Ingredients = MapIngredientAmountToListModel(entity.Ingredients)
                    .ToObservableCollection()
            };

    public override RecipeEntity MapToEntity(RecipeDetailModel model)
        => new()
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Duration = model.Duration,
            FoodType = model.FoodType,
            ImageUrl = model.ImageUrl
        };

    public IngredientAmountListModel MapIngredientAmountToListModel(IngredientAmountEntity? entity)
        => entity?.Ingredient is null
            ? IngredientAmountListModel.Empty
            : new IngredientAmountListModel
            {
                Id = entity.Id,
                IngredientId = entity.Ingredient.Id,
                IngredientName = entity.Ingredient.Name,
                IngredientImageUrl = entity.Ingredient.ImageUrl,
                Amount = entity.Amount,
                Unit = entity.Unit
            };

    public IEnumerable<IngredientAmountListModel> MapIngredientAmountToListModel(IEnumerable<IngredientAmountEntity> entities)
        => entities.Select(MapIngredientAmountToListModel);

    public IngredientAmountEntity MapIngredientAmountToEntity(IngredientAmountListModel model, Guid recipeId)
        => new()
        {
            Id = model.Id,
            RecipeId = recipeId,
            IngredientId = model.IngredientId,
            Amount = model.Amount,
            Unit = model.Unit,
            Recipe = null!,
            Ingredient = null!
        };
}
