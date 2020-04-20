using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using CookBook.App.ViewModels;
using CookBook.Common;

namespace CookBook.App.Wrappers
{
    public abstract class ModelWrapper<T> : ViewModelBase, IId where T : IId
    {
        protected ModelWrapper(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            Model = model;
        }

        public Guid Id
        {
            get => GetValue<Guid>();
            set => SetValue(value);
        }

        public T Model { get; }

        protected TValue GetValue<TValue>([CallerMemberName] string propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName);
            return (TValue) propertyInfo.GetValue(Model);
        }

        protected void SetValue<TValue>(TValue value,
            [CallerMemberName] string propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName);
            var currentValue = propertyInfo.GetValue(Model);
            if (!Equals(currentValue, value))
            {
                propertyInfo.SetValue(Model, value);
                OnPropertyChanged(propertyName);
            }
        }

        protected void RegisterCollection<TWrapper, TModel>(
            ObservableCollection<TWrapper> wrapperCollection,
            ICollection<TModel> modelCollection) where TWrapper : ModelWrapper<TModel>, IId where  TModel : IId
        {
            wrapperCollection.CollectionChanged += (s, e) =>
            {
                modelCollection.Clear();
                foreach (var model in wrapperCollection.Select(i=>i.Model))
                {
                    modelCollection.Add(model);
                }
            };
        }
    }
}