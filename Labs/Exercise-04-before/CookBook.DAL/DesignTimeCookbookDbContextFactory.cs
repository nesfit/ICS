using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace CookBook.DAL
{
    class DesignTimeCookbookDbContextFactory : IDesignTimeDbContextFactory<CookBookDbContext>
    {
        public CookBookDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CookBookDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog = TasksDB;MultipleActiveResultSets = True;Integrated Security = True; ");
            return new CookBookDbContext(optionsBuilder.Options);
        }
    }
}
