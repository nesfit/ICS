using Microsoft.EntityFrameworkCore;
using CookBook.DAL.Factories;

namespace CookBook.DAL.Tests
{
    public class CookBookDbContextTestsClassSetupFixture : CookBookDbContextSetupFixture
    {
        public CookBookDbContext CookBookDbContextSUT { get; }
        public CookBookDbContextTestsClassSetupFixture():base(nameof(CookBookDbContextTestsClassSetupFixture)) => this.CookBookDbContextSUT = DbContextFactory.CreateDbContext();
    }
}