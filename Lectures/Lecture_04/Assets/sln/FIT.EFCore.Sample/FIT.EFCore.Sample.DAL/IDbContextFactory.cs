namespace FIT.EFCore.Sample.DAL
{
    public interface IDbContextFactory
    {
        TodosDbContext CreateDbContext();
    }
}