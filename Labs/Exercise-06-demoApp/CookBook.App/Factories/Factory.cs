using System;

namespace CookBook.App.Factories
{
    public class Factory<T> : IFactory<T>
    {
        private readonly Func<T> _initFunc;

        public Factory(Func<T> initFunc) => this._initFunc = initFunc;

        public T Create() => _initFunc();
    }
}