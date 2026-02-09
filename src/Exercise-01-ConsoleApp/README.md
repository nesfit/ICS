# Exercise 01

Getting started guide and in-class checklist for the console app exercise.

## Azure for students

Visit https://azure.microsoft.com/en-us/free/students/ and explore student benefits:
- PluralSight subscription
- Azure Dev Tools for Teaching: https://azureforeducation.microsoft.com/devtools

## Install prerequisites (optional)

### Dependencies

```pwsh
winget install Git.Git
winget install Microsoft.DotNet.SDK.10
dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org
```

### Recommended tooling / IDEs

> Warning: without Visual Studio 2026 with at least the workloads below, the MAUI app will not run.

- Visual Studio 2026 + Resharper

```pwsh
winget install Microsoft.VisualStudio.Enterprise --override "--add Microsoft.VisualStudio.Workload.NetCrossPlat --add Microsoft.VisualStudio.Workload.Data --add Microsoft.VisualStudio.Workload.ManagedDesktop --add Microsoft.VisualStudio.Workload.NetWeb"

# https://www.jetbrains.com/community/education/#students
winget install JetBrains.Toolbox 
```

- Rider
```pwsh
# https://www.jetbrains.com/community/education/#students
winget install JetBrains.Rider
```

## Project demonstration
- Look at the project draft and clarify what is unclear.

## Azure DevOps
- Login: https://dev.azure.com/
- Create a new organization
- Go through all tabs: Overview, Boards, Repos, Pipelines, Test Plans, Artifacts
- Add a new team member
- Modify sprints
- Create a new Backlog Item with a task for the first commit, assigned to the current sprint
- Initialize the new project repository with a license and README.md
- Open the new repository in Visual Studio
- Commit, push, and finish the *Initial commit task*

## Visual Studio 2026
- Visual Studio start page
- Look at Visual Studio components: View, Build, Tools, Tests, ReSharper
- Key windows: Editor, Solution Explorer, Team Explorer, Error List, Output
- Demonstrate debugging: breakpoints; Watch, Locals, Breakpoints, Call Stack, Immediate Window; conditional breakpoints; stepping (F5, F10, F11, Shift+F11)
- Create a simple calculator; use shortcuts and refactorings as much as possible
- Commit logical, compilable parts

## Show other tools
- Rider
- VS Code
- SourceTree

## Individual Assignment
- Create project *CalculatorApp*
- Add *CommandLineParser* from NuGet
- Refactor the application to be modular; each class should respect the **Single Responsibility Principle**
- Try to compile with `dotnet build /warnaserror`

## Shortcuts

### Visual Studio
- F1: help, context help for the selected class
- F7: go to code-behind
- F12: go to definition
- Alt + mouse select: select multiple rows
- Alt + Shift + up/down: move current line up or down
- Ctrl + C / Ctrl + V / Ctrl + X: copy/paste/cut when text is selected, otherwise the whole line
- Ctrl + Shift + V: paste text from clipboard history
- Ctrl + [ + S: show Solution Explorer
- Ctrl + R, M: extract method
- Ctrl + Shift + F: find in files
- Ctrl + K, R: find all references
- Ctrl + Shift + B: build
- Ctrl + B, N: next tab
- Ctrl + K, D: format code
- Ctrl + K, C: comment selected lines
- Ctrl + K, U: uncomment selected lines
- Ctrl + M, M: wrap current region
- Ctrl + ,: find in file, class, method names
- Ctrl + Space: Intellisense
- Ctrl + Shift + Space: Intellisense in overloads

### Debug
- F5: start debugging
- Shift + F5: stop debugging
- F10: step over
- F11: step into
- Shift + F11: step out
- Ctrl + Shift + F10: set next statement
- Ctrl + Shift + ;: code map

### R#
- Alt + Enter: ReSharper's universal shortcut
- Ctrl + W: select logical code blocks (variable -> row -> block -> methods -> region)
- Ctrl + Shift + W: unselect logical blocks
- Ctrl + Alt + Shift + up/down: move method up or down
- Ctrl + Shift + R: refactor context menu
- Ctrl + R, V: extract variable
- Ctrl + R, M: extract method
