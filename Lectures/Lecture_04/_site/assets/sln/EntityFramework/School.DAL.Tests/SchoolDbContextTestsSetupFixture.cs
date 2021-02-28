using System;
using Microsoft.EntityFrameworkCore;

namespace School.DAL.Tests
{
    public sealed class SchoolDbContextTestsSetupFixture : IDisposable
    {
        public SchoolDbContextTestsSetupFixture()
        {
            SchoolDbContextSut = CreateSchoolDbContext();
        }

        public SchoolDbContext SchoolDbContextSut { get; set; }

        public void Dispose() => SchoolDbContextSut?.Dispose();

        public static SchoolDbContext CreateSchoolDbContext() => new(CreateDbContextOptions());

        private static DbContextOptions<SchoolDbContext> CreateDbContextOptions()
        {
            var contextOptionsBuilder = new DbContextOptionsBuilder<SchoolDbContext>();
            contextOptionsBuilder.UseInMemoryDatabase("TestInMemoryDb");
            return contextOptionsBuilder.Options;
        }
    }
}