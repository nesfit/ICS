using Npgsql;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? "Host=db;Port=5432;Database=appdb;Username=app;Password=apppass";

app.MapGet("/", () => "ICS Docker Demo 3 (.NET + PostgreSQL via Compose)");

app.MapGet("/db-check", async () =>
{
    try
    {
        await using var conn = new NpgsqlConnection(connectionString);
        await conn.OpenAsync();

        await using var cmd = new NpgsqlCommand("SELECT current_database(), current_user", conn);
        await using var reader = await cmd.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            return Results.Ok(new
            {
                status = "ok",
                database = reader.GetString(0),
                user = reader.GetString(1)
            });
        }

        return Results.Ok(new { status = "ok", database = "unknown" });
    }
    catch (Exception ex)
    {
        return Results.Problem($"Database connection failed: {ex.Message}");
    }
});

app.Run();
