using Microsoft.EntityFrameworkCore;

namespace School.DAL.Factories
{
    public class DbContextInMemoryFactory: INamedDbContextFactory<SchoolDbContext>
    {
        private readonly string _databaseName;

        public DbContextInMemoryFactory(string databaseName)
        {
            _databaseName = databaseName;
        }
        public SchoolDbContext Create()
        {
            var contextOptionsBuilder = new DbContextOptionsBuilder<SchoolDbContext>();
            contextOptionsBuilder.UseInMemoryDatabase(_databaseName);
            return new SchoolDbContext(contextOptionsBuilder.Options);
        }
    }
}