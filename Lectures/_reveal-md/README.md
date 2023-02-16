# Lecture

Presentation uses [`reveal-md`](https://github.com/webpro/reveal-md).

## Installation

```pwsh
winget install OpenJS.NodeJS.LTS
npm install -g reveal-md
```

**OR**

Use [Nix](https://nixos.org/download.html#nix-install-windows) in WSL2

```bash
nix develop --extra-experimental-features nix-command --extra-experimental-features flakes github:/nesfit/ICS
```

## Usage

```bash
reveal-md Lecture.md --port 8080 -w
```

## Export as PDF

```
reveal-md .\Lecture.md --print slides.pdf
```

## Export as static content

```
reveal-md Lecture.md --static _site --static-dirs=assets
```

## Preview exported static content

```
# docker stop ICS-Lecture-nginx; docker rm ICS-Lecture-nginx
docker run --name ICS-Lecture-nginx -p 80:80 -d nginx
docker cp _site ICS-Lecture-nginx:/usr/share/nginx/html
```

or

```
podman stop ICS-Lecture-nginx; podman rm ICS-Lecture-nginx
podman run --name ICS-Lecture-nginx -p 1080:80 -d nginx
podman cp _site ICS-Lecture-nginx:/usr/share/nginx/html
```

## Restore symlinks

```
# cd Lectures/Lecture_XY
ln -sfh ../_reveal-md _reveal-md
ln -sfh ../_reveal-md/README.md README.md
ln -sfh ../_reveal-md/reveal.json reveal.json
ln -sfh ../_reveal-md/reveal-md.json reveal-md.json 
```