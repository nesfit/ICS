<!-- ---
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
--- -->

# Seminář C# - ICS, Organizační pokyny

---

## [FAQ - Frequently Asked Questions](https://github.com/nesfit/ICS/wiki)

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
| 8.02.  | L01 | Jan Pluskal     | [Úvod do jazyka C# a platformy .NET](https://nesfit.github.io/ICS/Lectures/Lecture_01/_site/) - základní syntaxe jazyka ([verze pro tisk](https://nesfit.github.io/ICS/Lectures/Lecture_01/_site/?print-pdf))                                                                                |
|        | E01 | Jan Pluskal     | Práce s Visual Studio 2022, debugování a Azure DevOps založení projektu (základy pro zracování projektu)                                                                                                                                                                                     |
| 15.02. | L02 | Jan Pluskal     | [Úvod do Objektově Orientovaného Programování](https://nesfit.github.io/ICS/Lectures/Lecture_02/_site/) ([verze pro tisk](https://nesfit.github.io/ICS/Lectures/Lecture_02/_site/?print-pdf))                                                                                                |
|        | E02 | Jan Pluskal     | Objektově orientované programování a úvod do Entity Framework                                                                                                                                                                                                                                |
| 22.02. | L03 | Tibor Jašek     | [Představení základních knihovních funkcí (BCL)](https://nesfit.github.io/ICS/Lectures/Lecture_03/_site/) - dotazování za pomocí vestavěného nástroje LINQ nad datovými zdroji (kolekcemi, XML, MSSQL) ([verze pro tisk](https://nesfit.github.io/ICS/Lectures/Lecture_03/_site/?print-pdf)) |
| 29.02. | L04 | Jan Pluskal     | [Propojení aplikace s databází](https://nesfit.github.io/ICS/Lectures/Lecture_04/_site/) ([verze pro tisk](https://nesfit.github.io/ICS/Lectures/Lecture_04/_site/?print-pdf))                                                                                                               |
|        | E03 | Jan Pluskal     | Entity framework                                                                                                                                                                                                                                                                             |
| 03.03. | P01 |                 | **Odevzdání první fáze projektu**                                                                                                                                                                                                                                                            |
| 07.03. | L05 | Martin Dybal    | Psaní čistého a udržovatelného kódu                                                                                                                                                                                                                                                          |
| 14.03. | L06 | Michal Tichý    | Automatizované testování - práce s xUnit, CI                                                                                                                                                                                                                                                 |
| 21.03. | L07 | Michal Mrnuštík | Návrhový vzor Model-View-ViewModel                                                                                                                                                                                                                                                           |
| 28.03. | L08 | Roman Jašek     | MAUI                                                                                                                                                                                                                                                                                         |
|        | E04 | Roman Jašek     | MAUI                                                                                                                                                                                                                                                                                         |
| 04.04. | L09 | Roman Jašek     | MAUI                                                                                                                                                                                                                                                                                         |
|        | E05 | Roman Jašek     | MAUI                                                                                                                                                                                                                                                                                         |
| 07.04. | P02 |                 | **Odevzdání druhé fáze projektu**                                                                                                                                                                                                                                                            |
| 11.04. | L10 | Jan Pluskal     | [Multiplatformní programování](https://nesfit.github.io/ICS/Lectures/Lecture_10/_site/) - .NET Standard, .NET Core., .NET, kontejnerizace a deployment aplikací ([verze pro tisk](https://nesfit.github.io/ICS/Lectures/Lecture_10/_site/?print-pdf))                                        |
| 18.04. | L11 | Jan Pluskal     | [Paralelní a asynchronní programování](https://nesfit.github.io/ICS/Lectures/Lecture_11/_site/) - proces, vlákno, úloha z pohledu C# a použitého .NET frameworku                                                                                                                             |
|        | E06 | Jan Pluskal     | Takto můžete napsat projekt?!                                                                                                                                                                                                                                                                |
| 25.04. | L12 | Martin Dybal    | Návrhové vzory - vytvářecí, strukturní a chování - Gang of Four (GoF) v kontextu C#                                                                                                                                                                                                          |
| 02.05. | L13 | Roman Jašek     | Napojení aplikace na API server                                                                                                                                                                                                                                                              |
| Dle IS | P03 |                 | **Obhajoby projektu**                                                                                                                                                                                                                                                                        |

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

+++

```pwsh
winget install Microsoft.DotNet.SDK.8

winget install Microsoft.VisualStudio.2022.Community --override "--add Microsoft.VisualStudio.Workload.NetCrossPlat --add Microsoft.VisualStudio.Workload.Data --add Microsoft.VisualStudio.Workload.ManagedDesktop Microsoft.VisualStudio.ComponentGroup.WindowsAppSDK.Cs"

winget install JetBrains.ReSharper
```

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
* [Michal Tichý](mailto:edu@tichymichal.net)
* [Jan Pluskal](https://www.fit.vut.cz/person/pluskal)
* [Michal Koutenský](https://www.fit.vut.cz/person/koutenmi)
* [Daniel Dolejška](https://www.fit.vut.cz/person/dolejska)
* [Jan Zavřel](https://www.fit.vut.cz/person/izavrel)
* [Miroslav Šafář](https://www.linkedin.com/in/miroslav-safar/)
* [Matěj Mudra](https://www.linkedin.com/in/matěj-mudra-a874461a9/)

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

# Užitečné zdroje

aneb co sledovat, pokud se chcete dozvědět víc

* [IW5](https://github.com/nesfit/iw5) - předmět, který navazuje na ICS a pokračuje v tématu vývoje v .NET dál se zaměřením na client-server a webový vývoj

+++

## Co se děje v .NET a co se chystá
* [.NET Conf](https://www.dotnetconf.net/) - konference, kde se představuje nová verze .NET (jednou ročně - **listopad**)
* [Microsoft Build](https://build.microsoft.com/en-US/home) - největší konference pro vývojáře od Microsoftu, hromada novinek (jednou ročně - **květen**)
* [.NET Blog](https://devblogs.microsoft.com/dotnet/) - blog s high-level zprávami o aktuálních novinkách (cca 10-15 článků za měsíc)
* [Themes of .NET](https://aka.ms/dotnet-product-roadmap) - .NET roadmap - podrobný přehled toho, na čem se pracuje a kdy se to plánuje

+++

## Blogy
* [Leomaris Reyes](https://askxammy.com/author/leoreyes/) - Blog zaměřený na .NET MAUI
* [Scott Hanselman](https://www.hanselman.com/blog/) - Různorodá témata, většinou zaměrená na Microsoft technologie. Autor je zkušený speaker z řad Microsoftu.
* [Steve Gordon](https://www.stevejgordon.co.uk/) - .NET, web development, cloud, low-level stuff...
* [Jiří Činčura](https://www.tabsoverspaces.com/) - performance, Entity Framework, databázy, novinky v .NET...
* [Robert Haken](https://knowledge-base.havit.cz/) - Blazor, webový vývoj, performance

+++

## Twitter
* @davidfowl - **David Fowler**, jeden z hlavních lidí ve vývoji .NET a ASP .NET
* @DamianEdwards - **Damian Edwards**, jeden z hlavních lidí ve vývoji .NET a ASP .NET
* @davidortinau - **David Ortinau**, jeden z hlavních lidí v .NET MAUI
* @MadsTorgersen - **Mads Torgersen**, hlavní člověk odpovědný za C#
* @JamesNK - **James Newton-King**, autor NewtonSoft.Json, pracuje na gRPC integraci v .NET, (de)serializace, performance...
* @jaredpar - **Jared Parsons**, pracuje na C# kompilátoru a návrhu jazyka
* @TheCodeTraveler - **Brandon Minnick**, píše a točí hlavně o .NET MAUI
* @troyhunt - **Troy Hunt**, záměr na bezpečnost, autor projektu https://haveibeenpwned.com
* @dotnetmeme - memes ze světa .NET (ne od Microsoftu)

+++

## Youtube
* [Nick Chapsas](https://www.youtube.com/@nickchapsas) - novinky v .NET, performance, webový vývoj
* [James Montemagno](https://www.youtube.com/@JamesMontemagno) - novinky v .NET, .NET MAUI
* [Gerald Versluis](https://www.youtube.com/@jfversluis) - .NET MAUI
* [.NET Community Standups](https://www.youtube.com/playlist?list=PLdo4fOcmZ0oX-DBuRG4u58ZTAJgBAeQ-t) - veřejně dostupné streamy z meetingů mezi vývojářema v Microsoftu ohledně toho, co se aktuálně děje a na čem se pracuje

+++

## Podcasty
* [.NET Rocks](https://www.dotnetrocks.com/) - 2 hodně zkušení hostitelé - Richard Campbell a Carl Fralkin, 1 host, různá témata (hlavně) z .NET světa
* [The .NET MAUI Podcast](https://www.dotnetmauipodcast.com/) - .NET MAUI, James Montemagno, David Ortinau a Matt Soucoup
* [The ReadME Podcast](https://github.com/readme/podcast) - podcast GitHubu

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
