# Demo 3 - Compose with .NET API and PostgreSQL

Goal: Start a C# API with PostgreSQL and inspect service networking + persistence.

## Run

```bash
docker compose up -d
docker compose ps
```

Check API:

- `http://localhost:8083/`
- `http://localhost:8083/db-check`

Open `http://localhost:8084` (Adminer).

Connection settings:
- System: PostgreSQL
- Server: db
- Username: app
- Password: apppass
- Database: appdb

## Stop

```bash
docker compose down
```

To also remove volume data:

```bash
docker compose down -v
```
