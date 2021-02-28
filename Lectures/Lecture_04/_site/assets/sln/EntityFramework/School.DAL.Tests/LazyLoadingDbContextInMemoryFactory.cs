using School.DAL;
using Microsoft.EntityFrameworkCore;
using School.DAL.Factories;

namespace School.DAL.Tests
{
    public class LazyLoadingDbContextInMemoryFactory : IDbContextFactory<SchoolDbContext>
    {
        private readonly string _databaseName;

        public LazyLoadingDbContextInMemoryFactory(string databaseName)
        {
            _databaseName = databaseName;
        }
        public SchoolDbContext Create()
        {
            var contextOptionsBuilder = new DbContextOptionsBuilder<SchoolDbContext>();
            contextOptionsBuilder.UseInMemoryDatabase(_databaseName);
            contextOptionsBuilder.UseLazyLoadingProxies();
            return new SchoolDbContext(contextOptionsBuilder.Options);
        }
    }
}