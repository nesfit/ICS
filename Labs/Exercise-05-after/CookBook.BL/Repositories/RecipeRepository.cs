using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.DAL;
using CookBook.DAL.Entities;
using CookBook.DAL.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CookBook.BL.Repositories
{
    public class RecipeRepository : RepositoryBase<RecipeEntity, RecipeListModel, RecipeDetailModel>, IRecipeRepository
    {
        public RecipeRepository(INamedDbContextFactory<CookBookDbContext> dbContextFactory)
            : base(dbContextFactory,
                RecipeMapper.MapDetailModelToEntity,
                RecipeMapper.MapEntityToListModel,
                RecipeMapper.MapEntityToDetailModel,
                new Func<RecipeEntity, IEnumerable<IEntity>>[] { entity => entity.Ingredients },
                entities => entities.Include(entity => entity.Ingredients)
                    .ThenInclude(entity => entity.Ingredient),
                null)
        {
        }
    }
}