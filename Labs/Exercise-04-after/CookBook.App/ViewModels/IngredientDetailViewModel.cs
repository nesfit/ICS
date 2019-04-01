using System;
using CookBook.BL.Factories;
using CookBook.BL.Models;
using CookBook.BL.Repositories;

namespace CookBook.App.ViewModels
{
    class IngredientDetailViewModel
    {
        private readonly IIngredientRepository repository = new IngredientRepository(new DbContextFactory());

        public IngredientDetailModel Model { get; set; } = new IngredientDetailModel();

        public void Load(Guid id)
        {
            Model = repository.GetById(id);
        }

        public void Save()
        {
            if (Model.Id == Guid.Empty)
            {
                Model = repository.Create(Model);
            }
            else
            {
                repository.Update(Model);
            }
        }

        public void Delete()
        {
            repository.Delete(Model.Id);
        }
    }
}