using System.Collections.Generic;

namespace Examples
{
    /// <summary>
    ///     Invariance example
    ///     Tackling Invariance Using Covariance and Contravariance in C#
    ///     http://www.c-sharpcorner.com/UploadFile/24b242/tackling-invariance-using-covariance-and-contra-variance-in/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Storage<T> : IDepositor<T>, IRetreiver<T>
    {
        private readonly List<T> _inventory = new List<T>();

        void IDepositor<T>.StoreItems(T item)
        {
            this._inventory.Add(item);
        }

        IEnumerable<T> IRetreiver<T>.GetItems()
        {
            return this._inventory;
        }
    }

    ///Contravariance
    public interface IRetreiver<out T>
    {
        IEnumerable<T> GetItems();
    }

    ///Covariance
    public interface IDepositor<in T>
    {
        void StoreItems(T item);
    }
}