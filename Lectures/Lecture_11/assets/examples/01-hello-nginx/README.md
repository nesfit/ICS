# Demo 1 - Static site in a container

Goal: Build and run a minimal image that serves a static page.

## Run

```bash
docker build -t ics-demo1 .
docker run --rm -p 8081:80 ics-demo1
```

Open `http://localhost:8081`.
