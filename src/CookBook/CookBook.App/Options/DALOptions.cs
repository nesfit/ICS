namespace CookBook.App.Options;

public record DALOptions
{    
    public LocalDbOptions? LocalDb { get; init; }
    public SqliteOptions? Sqlite { get; init; }

    public class LocalDbOptions
    {
        public bool Enabled { get; init; }
        public string ConnectionString { get; init; } = null!;
    }


    public class SqliteOptions
    {
        public bool Enabled { get; init; }

        public string DatabaseName { get; init; } = null!;
        /// <summary>
        /// Deletes database before application startup
        /// </summary>
        public bool RecreateDatabseEachTime { get; init; } = false;

        /// <summary>
        /// Seeds DemoData from DbContext on database creation.
        /// </summary>
        public bool SeedDemoData { get; init; } = false;
    }
}
