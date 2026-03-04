using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace School.DAL.Tests;

public static class TestDbContextFactory
{
    public static SchoolDbContext CreateInMemory(bool lazyLoading = false, string? databaseName = null)
    {
        var contextOptionsBuilder = new DbContextOptionsBuilder<SchoolDbContext>();
        contextOptionsBuilder.UseInMemoryDatabase(databaseName ?? Guid.NewGuid().ToString("N"));
        if (lazyLoading)
        {
            contextOptionsBuilder.UseLazyLoadingProxies();
        }

        var context = new SchoolDbContext(contextOptionsBuilder.Options);
        context.Database.EnsureCreated();
        return context;
    }

    public static SqliteTestDatabase CreateSqliteInMemory()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<SchoolDbContext>()
            .UseSqlite(connection)
            .Options;

        using (var context = new SchoolDbContext(options))
        {
            context.Database.EnsureCreated();
        }

        return new SqliteTestDatabase(connection, options);
    }
}

public sealed class SqliteTestDatabase : IDisposable
{
    public SqliteTestDatabase(SqliteConnection connection, DbContextOptions<SchoolDbContext> options)
    {
        Connection = connection;
        Options = options;
    }

    public SqliteConnection Connection { get; }
    public DbContextOptions<SchoolDbContext> Options { get; }

    public SchoolDbContext CreateContext() => new(Options);

    public void Dispose() => Connection.Dispose();
}
