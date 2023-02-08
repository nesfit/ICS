---
title: ICS 00 - ICS Organization
theme: simple
css: _reveal-md/theme.css
separator: "^---$"
verticalSeparator: "^\\+\\+\\+$"
highlightTheme: vs
progress: true
slideNumber: true
mouseWheel: false
enableMenu: true
enableChalkboard: true
enableTitleFooter: true
---

# Seminář C# - ICS, Organizační pokyny

---

# Rozvrh

## Přednášky

| Typ       | Místnost             | Čas            |
| --------- | -------------------- | -------------- |
| Přednáška | **E112**, E104, E105 | Čt 12:00-13:50 |

E104 a E105 bude otevřeno pouze v případě naplnění E112.

+++

## Cvičení
Cvičení jsou demonstrační. Pokud možno, přineste si vlastní zařízení, na kterém budete moct cvičení aktivně zúčastnit. Bude potřeba vývojové prostředí ideálně Visual Studio 2022 / Rider / VSCode.

| Typ                             | Místnost  | Čas            |
| ------------------------------- | --------- | -------------- |
| Dobrovolné demonstrační cvičení | **D0207** | Čt 14:00-15:50 |

+++

## Plán semestru

| Datum  | Typ | Vyučující       | Téma přednášky                                                                                                                                                                                                                                                                               |
| ------ | --- | --------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 9.02.  | L01 | Jan Pluskal     | [Úvod do jazyka C# a platformy .NET](https://nesfit.github.io/ICS/Lectures/Lecture_01/_site/) - základní syntaxe jazyka ([verze pro tisk](https://nesfit.github.io/ICS/Lectures/Lecture_01/_site/?print-pdf))                                                                                |
|        | E01 | Jan Pluskal     | Práce s Visual Studio 2022, debugování a Azure DevOps založení projektu (základy pro zracování projektu)                                                                                                                                                                                     |
| 16.02. | L02 | Jan Pluskal     | [Úvod do Objektově Orientovaného Programování](https://nesfit.github.io/ICS/Lectures/Lecture_02/_site/) ([verze pro tisk](https://nesfit.github.io/ICS/Lectures/Lecture_02/_site/?print-pdf))                                                                                                |
|        | E02 | Jan Pluskal     | Objektově orientované programování a úvod do Entity Framework                                                                                                                                                                                                                                |
| 23.02. | L03 | Tibor Jašek     | [Představení základních knihovních funkcí (BCL)](https://nesfit.github.io/ICS/Lectures/Lecture_03/_site/) - dotazování za pomocí vestavěného nástroje LINQ nad datovými zdroji (kolekcemi, XML, MSSQL) ([verze pro tisk](https://nesfit.github.io/ICS/Lectures/Lecture_03/_site/?print-pdf)) |
| 02.03. | L04 | Jan Pluskal     | [Propojení aplikace s databází](https://nesfit.github.io/ICS/Lectures/Lecture_04/_site/) ([verze pro tisk](https://nesfit.github.io/ICS/Lectures/Lecture_04/_site/?print-pdf))                                                                                                               |
|        | E03 | Jan Pluskal     | Entity framework                                                                                                                                                                                                                                                                             |
| 05.03. | P01 |                 | **Odevzdání první fáze projektu**                                                                                                                                                                                                                                                            |
| 09.03. | L05 | Martin Dybal    | Psaní čistého a udržovatelného kódu                                                                                                                                                                                                                                                          |
| 16.03. | L06 | Michal Tichý    | Automatizované testování - práce s xUnit, CI                                                                                                                                                                                                                                                 |
| 23.03. | L07 | Michal Mrnuštík | Návrhový vzor Model-View-ViewModel                                                                                                                                                                                                                                                           |

+++

| Datum    | Typ | Vyučující    | Téma přednášky                                                                                                                                                                                                                                         |
| -------- | --- | ------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
|          |
| 30.03.   | L08 | Jan Pluskal  | [Základní koncepty tvorby uživatelského rozhraní](https://nesfit.github.io/ICS/Lectures/Lecture_08/_site/) ([verze pro tisk](https://nesfit.github.io/ICS/Lectures/Lecture_08/_site/?print-pdf))                                                       |
|          | E04 | Jan Pluskal  | Základy MAUI a návrhový vzor MVVM                                                                                                                                                                                                                      |
| 06.04.   | L09 | Roman Jašek  | MAUI - tvorba komponent a stylování aplikací.                                                                                                                                                                                                          |
|          | E05 | Romen Jašek  | MAUI frontend a binding                                                                                                                                                                                                                                |
| 09.04.   | P02 |              | **Odevzdání druhé fáze projektu**                                                                                                                                                                                                                      |
| 13.04.   | L10 | Jan Pluskal  | [Paralelní a asynchronní programování](https://nesfit.github.io/ICS/Lectures/Lecture_12/_site/) - proces, vlákno, úloha z pohledu C# a použitého .NET frameworku ([verze pro tisk](https://nesfit.github.io/ICS/Lectures/Lecture_12/_site/?print-pdf)) |
| 20.04.   | L11 | Jan Pluskal  | Multiplatformní programování - .NET Standard, .NET Core., .NET, kontejnerizace a deployment aplikací                                                                                                                                                   |
|          | E06 | Jan Pluskal  | Takto můžete napsat projekt?!                                                                                                                                                                                                                          |
| 27.04.   | L12 | Martin Dybal | Návrhové vzory - vytvářecí, strukturní a chování - Gang of Four (GoF) v kontextu C#                                                                                                                                                                    |
| 02-03.05 | P03 |              | **Obhajoby projektu**                                                                                                                                                                                                                                  |
| 04.05.   | L13 |              | Téma bude doplněno                                                                                                                                                                                                                                     |

LXY - přednáška | EXY - democvičení | P0X - projekt

---

# Výuka - bodové rozdělení

| Typ výuky | Maximální bodový zisk |
| --------- | --------------------- |
| Projekt   | 100                   |

---

# Projekt
* Projekt bude vypracovaný v 5 členném týmu.

| Fáze | Obsah                                   | Body |
| ---- | --------------------------------------- | ---- |
| 1    | Objektový návrh                         | 20   |
| 2    | Entity Framework, Repository, Tests     | 30   |
| 3    | Finalizace aplikace a následná obhajoba | 50   |

* Při obhajobě:
  * musí být přítomni všichni členové týmu (vyjímka je řádně omluvená nepřítomnost dle studijního řádu),
  * obhajovat projekt bude náhodně vybraný člen týmu,
  * nemusíte chodit v obleku...

---

# Nástroje použity ve cvičeních

| Nástroj                                                                                            | Typ                | Popis                                                                                                                             |
| -------------------------------------------------------------------------------------------------- | ------------------ | --------------------------------------------------------------------------------------------------------------------------------- |
| [Visual Studio 2022](https://aka.ms/devtoolsforteaching)                                           | IDE                | Hlavní vývojové prostředí pro .Net                                                                                                |
| [Resharper](https://www.jetbrains.com/resharper/)                                                  | Doplněk            | Nástroje na lepší produktivitu, refaktorování. Studentská licence je k dispozici zdarma [zde](https://www.jetbrains.com/student/) |
| [LinqPad](http://www.linqpad.net/)                                                                 | Samostatný program | Nástroj na přístup do databáze přes Linq, SQL…                                                                                    |
| [DotPeek](https://www.jetbrains.com/decompiler/)                                                   | Samostatný program | Dekompilátor C# kódu                                                                                                              |
| [EF Core Power Tools](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools) | Doplněk            | Přidává funkcionalitu k DbContext jako je např. generování ER diagramů.                                                           |

---

# Další zajímavé nástroje

| Nástroj                                                | Typ               | Popis                                                     |
| ------------------------------------------------------ | ----------------- | --------------------------------------------------------- |
| [Rider](https://www.jetbrains.com/rider/)              | IDE               | Vývojové prostředí od JetBrains.                          |
| [Roslynator](https://github.com/JosefPihrt/Roslynator) | Analyzér, Doplněk | Open-source alternativa k Resharper postavená nad Roslyn. |

---

# Vyučující
* [Martin Dybal](https://www.linkedin.com/in/martin-dybal)
* [Roman Jašek](https://www.linkedin.com/in/roman-jasek-16921839)
* [Tibor Jašek](https://www.linkedin.com/in/tibor-jašek-717a5761)
* [Michal Mrnuštík](https://www.linkedin.com/in/michal-mrnušt%C3%ADk-31050b60/)
* [Michal Tichý]()
* [Jan Pluskal](https://www.fit.vut.cz/person/ipluskal)
* [Michal Koutenský](https://www.fit.vut.cz/person/koutenmi)
* [Daniel Dolejška](https://www.fit.vut.cz/person/dolejska)

---

# Užitečné odkazy
* [WPF-Tutorial](https://wpf-tutorial.com/)
* [Entity framework tutorial](https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx)
* [R. C. Martin SOLID](https://youtu.be/TMuno5RZNeE?t=757) Bob Martin SOLID Principles of Object Oriented and Agile Design
* [Resharper features](https://www.jetbrains.com/resharper/features/) and how to use them.
* [Pro Git book](https://git-scm.com/book/en/v2)
* [LINQ explained with sketches - the eBook](https://steven-giesel.com/blogPost/8d12d9ef-c4e6-439c-9f88-46825cf35576)

---

# Užitečná literatura
* [C# 9.0 in a Nutshell](https://www.amazon.com/C-9-0-Nutshell-Definitive-Reference/dp/1098100964), Ben Albahari, Joseph Albahari
* [Clean Code: A Handbook of Agile Software Craftsmanship](https://books.google.cz/books?id=hjEFCAAAQBAJ), Robert C. Martin
* [Agile Principles, Patterns, and Practices in C#](https://books.google.cz/books?id=hckt7v6g09oC), Robert C. Martin
* [C# 3.0 Design Patterns](https://books.google.cz/books?id=pD2XMZLGUAYC), Judith Bishop
* [The Art of Unit Testing](https://books.google.cz/books?id=2GRRmgEACAAJ&dq=the+art+of+unit+testing&hl=en&sa=X&ved=0ahUKEwjLhJeRx7DnAhU3AGMBHeScBisQ6AEILDAA), Roy Osherove

---

# Lokální vývoj

Repozitář používá symlinky, které jsou závislé na nastavení prostředí ve Windows.

Pro clonování použijte explicitní povolné symlinků.
```
git clone -c core.symlinks=true https://github.com/nesfit/ICS.git
```

Pokud dojde k chybě s oprávněním vytvořit symlink tak nejsnažší je použít git clone s Admin oprávnění. Alternativně můžete upravit local policy v Windows.

---

<!-- Has to stay, because otherwise static build would not contain logo resources referenced in CSS theme -->
![](_reveal-md/img/logo-ics.svg)

---

![](_reveal-md/img/logo.png)
