using System;
using System.Collections.Generic;
using CookBook.BL.Interfaces;
using CookBook.BL.Mapper;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Factories;
using CookBook.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CookBook.BL.Repositories
{
    public class IngredientRepository : RepositoryBase<IngredientEntity, IngredientListModel, IngredientDetailModel>, IIngredientRepository
    {
        public IngredientRepository(IDbContextFactory dbContextFactory)
            : base(dbContextFactory,
                IngredientMapper.MapEntity,
                IngredientMapper.MapListModel,
                IngredientMapper.MapDetailModel,
                null,
                null,
                null)
        {
        }
    }
}