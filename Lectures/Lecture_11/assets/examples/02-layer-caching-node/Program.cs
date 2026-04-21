var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "ICS Docker Demo 2 (.NET) - Layer caching and rebuild behavior");

app.Run();
