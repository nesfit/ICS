namespace CookBook.DAL.Tests
{
    public class CookBookDbContextTestsClassSetupFixture : CookBookDbContextSetupFixture
    {
        public CookBookDbContext CookBookDbContextSUT { get; }
        public CookBookDbContextTestsClassSetupFixture():base(nameof(CookBookDbContextTestsClassSetupFixture)) => CookBookDbContextSUT = DbContextFactory.CreateDbContext();
    }
}