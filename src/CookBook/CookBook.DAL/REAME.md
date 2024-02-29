# E03 Entity framework

## Checklist

- [ ] Install `dotnet-ef`
- [ ] Explain `DbContextSqLiteFactory`
- [ ] Add / remove migration, explain `DesignTimeDbContextFactory`
- [ ] [ErikEJ / EFCorePowerTools](https://github.com/ErikEJ/EFCorePowerTools/wiki/) / [DbContext Model Graph](https://github.com/ErikEJ/EFCorePowerTools/wiki/Inspect-your-DbContext-model)
- [ ] Location of `cookbook.db` SQLite database file (see `DALInstaller`)
- [ ] [Rider - Database diagrams](https://www.jetbrains.com/help/rider/Creating_diagrams.html)
- [ ] [DataGrip](https://www.jetbrains.com/help/datagrip/sqlite.html) SQLite database IDE
- [ ] [LinqPad](https://www.linqpad.net/) LINQ to DB directly, no need for SQL
- [ ] Explain Repositories
- [ ] Explain Models(DTOs) vs Entities
- [ ] Explain Facades
- [ ] Explain Mappers
- [ ] Explain DAL.Tests
- [ ] Explain BL.Tests

> [!WARNING]
> If not state otherwise, code snippets are to be executed on the solution root level

## Dotnet tools - `dotnet-ef`

- [Docs](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)


```
dotnet new tool-manifest # creates .config/dotnet-tools.json
dotnet tool install dotnet-ef # installs locally into the solution dotnet-ef
```

## EF migrations

- [Docs](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)

### Add new migration

```
dotnet ef migrations add CurrentState --project .\CookBook.DAL\
```

> [!WARNING]
> Choose an appropriate name for the migration

### Remove migration

```
dotnet ef migrations remove --project .\CookBook.DAL\
```

## Notes

- Advanced version of BL/DAL infrastructure including Automapper, M:N relation operation using principal relation entity, etc... [CookBook 2022](https://github.com/nesfit/ICS/tree/2022)
