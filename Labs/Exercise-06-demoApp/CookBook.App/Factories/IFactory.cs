namespace CookBook.App.Factories
{
    public interface IFactory<out T>
    {
        T Create();
    }
}