using System.Collections.Generic;

namespace Examples
{
    /// <summary>
    ///     Invariance example
    ///     Tackling Invariance Using Covariant and Contravariant modifiers in C#
    ///     http://www.c-sharpcorner.com/UploadFile/24b242/tackling-invariance-using-covariance-and-contra-variance-in/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Storage<T> : IDepositor<T>, IRetriever<T>
    {
        private readonly List<T> _inventory = new List<T>();

        void IDepositor<T>.StoreItems(T item)
        {
            this._inventory.Add(item);
        }

        IEnumerable<T> IRetriever<T>.GetItems()
        {
            return this._inventory;
        }
    }

    ///Covariant
    public interface IRetriever<out T>
    {
        IEnumerable<T> GetItems();
    }

    ///Contravariant
    public interface IDepositor<in T>
    {
        void StoreItems(T item);
    }
}
