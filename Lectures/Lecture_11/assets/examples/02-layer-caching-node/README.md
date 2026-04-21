# Demo 2 - Layer caching with .NET

Goal: Show why Dockerfile ordering affects rebuild speed for a C# web app.

## Run

```bash
docker build -t ics-demo2 .
docker run --rm -p 8082:8080 ics-demo2
```

Open `http://localhost:8082`.

## What to observe

1. Build once.
2. Change only `Program.cs` and build again.
3. Notice that `dotnet restore` is cached.
