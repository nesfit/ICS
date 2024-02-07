using CookBook.App.ViewModels;
using CookBook.BL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CookBook.App.Wrappers
{
    /// <summary>
    /// For advance utilization of ModelWrapper look at https://github.com/pluskal/WPFandMVVM_TestDrivenDevelopment/blob/master/Starter/FriendStorage/FriendStorage.UI/Wrapper/Base/ModelWrapper.cs
    /// And the whole WPF and MVVM: Advanced Model Treatment course https://www.pluralsight.com/courses/wpf-mvvm-advanced-model-treatment
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ModelWrapper<T> : ViewModelBase, IModel, IValidatableObject
        where T : IModel
    {
        protected ModelWrapper(T? model)
        {
            if (model is null)
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

        protected TValue? GetValue<TValue>([CallerMemberName] string? propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName ?? string.Empty);
            return (propertyInfo?.GetValue(Model) is TValue
                ? (TValue?)propertyInfo.GetValue(Model)
                : default);
        }

        protected void SetValue<TValue>(TValue value, [CallerMemberName] string? propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName ?? string.Empty);
            var currentValue = propertyInfo?.GetValue(Model);
            if (!Equals(currentValue, value))
            {
                propertyInfo?.SetValue(Model, value);
                OnPropertyChanged(propertyName);
            }
        }

        protected void RegisterCollection<TWrapper, TModel>(
            ObservableCollection<TWrapper> wrapperCollection,
            ICollection<TModel> modelCollection)
            where TWrapper : ModelWrapper<TModel>, IModel
            where TModel : IModel
        {
            wrapperCollection.CollectionChanged += (s, e) =>
            {
                modelCollection.Clear();
                foreach (var model in wrapperCollection.Select(i => i.Model))
                {
                    modelCollection.Add(model);
                }
            };
        }

        public bool IsValid => !Validate(new ValidationContext(this)).Any();

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}