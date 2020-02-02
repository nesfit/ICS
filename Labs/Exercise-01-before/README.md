# Exercise 01

## Project demonstration
* Look at the project draft and clarify what is unclear.
     
## Azure DevOps
* [Login](https://dev.azure.com/) - https://dev.azure.com/
* Create a new organization
* Go through all tabs: Overview, Boards, Repos, Pipelines, Test Plans, Artifacts
* Add a new team member!
* Modify sprints
* Create a new Backlog Items with a task for the first commit, assigned to the current sprint
* Initialize the new project repository with License and README.md file
* Open the new repository in Visual Studio
* Download GitHub repository as ZIP, extract and copy the Exercise-01-before to your newly cloned repository
* Commit & push & finish the *Initial commit task*.

## Visual Studio 2019 
* Visual Studio -- Start page 
* Look at the Visual Studio components, VIEW, BUILD, TOOLS, TESTS, RESHARPER ...
  * Editor, Solution Explorer, Team Explorer, Error list, Outputs, ...
* Demonstrate debugging  -- breakpoint,  windows (watch, locals, breakpoints, call stack, Immediate window), conditional breakpoint, stepping, F5, F10, F11, Shift+F11 
* Create simple calculator, use shortcuts and refactorings as much as possible!
* Do not forget to commit logical, compilable parts!

## Show Other Tools
* Rider
* VSCode
* SourceTree

## Individual Assignment 
* Create project *CalculatorApp* 
* Add *CommandLineParser* lib from NuGet
* Refactor the application to be modular, each class should respect **Single Responsibility Principle**


## Shortcuts

### Visual Studio 
* F1 - help, context help for selected class 
* F7 - go to code-behind 
* F12 - Go to definitions 
* alt + mouse select - selects multiple rows
* Alt + Shift + up/down - moves current line up or down
* Ctrl + C, Ctrl + V, Ctrl + X - copy/past/cut when some text is selected, otherwise the whole line
* Ctrl + shift + V - Past text from clipboard's history
* Ctrl + [ + s - Shows Solution Explorer 
* Ctrl + R,M - Extracts Method
* Ctrl + Shift + F - Find In Files 
* Ctrl + K,R - Find All References
* Ctrl + shift + B - Build 
* Ctrl + b + n - next tab
* Ctrl + k + d - code format
* Ctrl + k + c - comments selected lines
* Ctrl + k + u - uncomments selected lines
* Ctrl + m + m - wrap current "region" 
* Ctrl + , - Find in file, class, method names
* Ctrl + shift + F - Find
* Ctrl + space - intelisence 
* Ctrl + shift + space - intelisence in oveloads

### Debug 
* F5 - start debug 
* Shift + F5 - stop debug 
* F10 - Next step 
* F11 - Next into 
* Shift + F11 - Step Out 
* Ctrl + shift + F10 - Set Next Statement 
* Ctrl + shift + ; - Code map 

### R# 
* Alt + Enter - R#'s universal shortcut
* Ctrl + w - selects logical code blocks (variable => row => block => methods => region) 
* Ctrl + Shift + W - unselects logical blocks
* Ctrl + Alt + Shift + up/down - moves method up or down
* Ctrl + Shift + R - Refactor context menu
* Ctrl + R,V - Extract Variable   
* Ctrl + R,M - Extract Method