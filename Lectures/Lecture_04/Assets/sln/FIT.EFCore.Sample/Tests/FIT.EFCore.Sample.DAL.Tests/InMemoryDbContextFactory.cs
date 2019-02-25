using Microsoft.EntityFrameworkCore;

namespace FIT.EFCore.Sample.DAL.Tests
{
    public class InMemoryDbContextFactory : IDbContextFactory
    {
        public TodosDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodosDbContext>();
            optionsBuilder.UseInMemoryDatabase("TodoDbName");
            return new TodosDbContext(optionsBuilder.Options);
        }
    }
}