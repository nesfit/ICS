using System;
using Microsoft.EntityFrameworkCore;

namespace School.DAL.Tests
{
    public class SchoolDbContextTestsSetupFixture : IDisposable
    {
        public SchoolDbContextTestsSetupFixture()
        {
            SchoolDbContextSut = CreateSchoolDbContext();
        }

        public SchoolDbContext SchoolDbContextSut { get; set; }

        public void Dispose()
        {
            SchoolDbContextSut?.Dispose();
        }

        public SchoolDbContext CreateSchoolDbContext()
        {
            return new SchoolDbContext(CreateDbContextOptions());
        }

        private DbContextOptions<SchoolDbContext> CreateDbContextOptions()
        {
            var contextOptionsBuilder = new DbContextOptionsBuilder<SchoolDbContext>();
            contextOptionsBuilder.UseInMemoryDatabase("TestInMemoryDb");
            return contextOptionsBuilder.Options;
        }
    }
}