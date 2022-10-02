using AutoMapper;
using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.BL.Facades;

public class RecipeFacade : CRUDFacade<RecipeEntity, RecipeListModel, RecipeDetailModel>
{
    private readonly RecipeModelMapper recipeModelMapper;

    public RecipeFacade(
        RecipeModelMapper recipeModelMapper,
        IUnitOfWorkFactory unitOfWorkFactory,
        IMapper mapper)
        : base(unitOfWorkFactory, mapper)
    {
        this.recipeModelMapper = recipeModelMapper;
    }

    public override async Task<IEnumerable<RecipeListModel>> GetAsync()
    {
        await using var uow = _unitOfWorkFactory.Create();
        var entities = uow
            .GetRepository<RecipeEntity>()
            .Get()
            .ToList();

        return recipeModelMapper.MapToListModel(entities);
    }
}