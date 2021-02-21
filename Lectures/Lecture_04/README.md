# Lecture

Presetation uses [`reveal-md`](https://github.com/webpro/reveal-md).

## Installation

```bash
npm install -g reveal-md
```

## Usage

```bash
reveal-md Lecture.md --port 8080 -w
```

## Docker

You can use Docker to run this tool without needing Node.js installed on your machine. Run the public Docker image,
providing your markdown slides as a volume. A few examples:

```bash
docker run --rm -p 8080:1948 -v ./Lecture.md:/slides webpronl/reveal-md:latest
```

## Export as PDF

```
reveal-md .\Lecture.md --port 8080 -w  --print slides.pdf
```

## Export as static content

```
 reveal-md .\Lecture.md --port 8080 -w  --static _site --static-dirs=assets
```
