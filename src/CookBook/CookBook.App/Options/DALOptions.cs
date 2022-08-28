namespace CookBook.App.Options
{
    public class DALOptions
    {
        public string? ConnectionString { get; set; }
        public bool SkipMigrationAndSeedDemoData { get; set; }
    }
}