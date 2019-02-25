using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FIT.EFCore.Sample.DAL
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TodosDbContext>
    {
        public TodosDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodosDbContext>();
            optionsBuilder.UseSqlServer(
                @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog = TasksDB;MultipleActiveResultSets = True;Integrated Security = True");
            return new TodosDbContext(optionsBuilder.Options);
        }
    }
}