using System;

namespace CookBook.App.Factories
{
    public class Factory<T> : IFactory<T>
    {
        private readonly Func<T> initFunc;

        public Factory(Func<T> initFunc) => this.initFunc = initFunc;

        public T Create() => initFunc();
    }
}