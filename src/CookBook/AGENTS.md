# LLM Rules for CookBook

## Scope
- This file applies to the CookBook solution under `src/CookBook`.
- Follow these rules for any automated edits, reviews, or refactors.

## Principles
- Prefer small, focused changes over broad refactors.
- Keep changes buildable on windows and macOS (primary dev environments).
- Avoid introducing new runtime dependencies unless explicitly requested.

## Project Conventions
- Target .NET 10.0 (see `Directory.Build.props`).
- Use Central Package Management in `Directory.Packages.props`.
- Solution format is `.slnx` (`CookBook.slnx`).
- Use nullable reference types and implicit usings (already enabled).

## MAUI Guidance
- Keep DB files out of the app bundle; use `FileSystem.AppDataDirectory`.

## Git / Commits
- Use Conventional Commits with scope `cookbook`.
- Examples:
  - `fix(cookbook): ...`
  - `feat(cookbook): ...`
  - `chore(cookbook): ...`

## Tooling
- Keep `global.json` minimal (roll forward within .NET 10 feature bands).
- Avoid editing `Directory.Build.props` unless necessary.
- If adding scripts, keep them POSIX‑shell compatible.
