namespace CookBook.App.Options;

public record DALOptions
{
    public string ConnectionString { get; init; } = null!;
    public bool SkipMigrationAndSeedDemoData { get; }
}