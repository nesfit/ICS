using AutoMapper;
using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.BL.Facades;

public class RecipeFacade : CRUDFacade<RecipeEntity, RecipeListModel, RecipeDetailModel>
{
    private readonly IngredientAmountMapper ingredientAmountMapper;
    private readonly RecipeModelMapper recipeModelMapper;

    public RecipeFacade(
        IngredientAmountMapper ingredientAmountMapper,
        RecipeModelMapper recipeModelMapper,
        IUnitOfWorkFactory unitOfWorkFactory,
        IMapper mapper)
        : base(unitOfWorkFactory, mapper)
    {
        this.ingredientAmountMapper = ingredientAmountMapper;
        this.recipeModelMapper = recipeModelMapper;
    }

    public override async Task<IEnumerable<RecipeListModel>> GetAsync()
    {
        await using var uow = unitOfWorkFactory.Create();
        var entities = uow
            .GetRepository<RecipeEntity>()
            .Get()
            .ToList();

        return recipeModelMapper.MapToListModel(entities);
    }

    public override async Task<RecipeDetailModel?> GetAsync(Guid id)
    {
        await using var uow = unitOfWorkFactory.Create();
        var entity = await uow.GetRepository<RecipeEntity>()
            .Get()
            .SingleOrDefaultAsync(e => e.Id == id);

        return recipeModelMapper.MapToDetailModel(entity);
    }

    public override async Task<RecipeDetailModel> SaveAsync(RecipeDetailModel recipeDetailModel)
    {
        var entity = recipeModelMapper.MapToEntity(recipeDetailModel);

        var uow = unitOfWorkFactory.Create();
        var recipeRepository = uow.GetRecipeRepository();
        var insertedRecipeEntity = await recipeRepository.InsertOrUpdateAsync(entity);
        var result = recipeModelMapper.MapToDetailModel(insertedRecipeEntity);

        var ingredientAmountRepository = uow.GetIngredientAmountRepository();
        foreach (var ingredientAmountDetailModel in recipeDetailModel.Ingredients)
        {
            var ingredientAmountEntity = ingredientAmountMapper.MapToEntity(ingredientAmountDetailModel, recipeDetailModel.Id);

            var insertedIngredientAmountEntity = await ingredientAmountRepository.InsertOrUpdateAsync(ingredientAmountEntity);
            result.Ingredients.Add(ingredientAmountMapper.MapToDetailModel(insertedIngredientAmountEntity));
        }

        await uow.CommitAsync();

        return result;
    }
}