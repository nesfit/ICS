namespace CookBook.DAL.Options;

public record DALOptions
{
    public required string DatabaseDirectory { get; init; }
    public string DatabaseName { get; init; } = null!;
    public string DatabaseFilePath => Path.Combine(DatabaseDirectory, DatabaseName!);

    /// <summary>
    /// Deletes database before application startup
    /// </summary>
    public bool RecreateDatabaseEachTime { get; init; } = false;

    /// <summary>
    /// Seeds DemoData from DbContext on database creation.
    /// </summary>
    public bool SeedDemoData { get; init; } = false;
}
