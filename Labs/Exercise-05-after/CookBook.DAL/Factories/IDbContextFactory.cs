namespace CookBook.DAL.Factories
{
    public interface IDbContextFactory
    {
        CookBookDbContext CreateDbContext();
    }
}
