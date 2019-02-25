using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;

namespace FIT.EFCore.Sample.DAL
{
    public class DefaultDbContextFactory : IDbContextFactory
    {
        public TodosDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodosDbContext>();
            optionsBuilder.UseSqlServer(
                    @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog = TasksDB;MultipleActiveResultSets = True;Integrated Security = True");
            return new TodosDbContext(optionsBuilder.Options);
        }
    }
}