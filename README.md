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

# Aktuality k předmětu
 - [Visual Studio 2022 Enterprise](https://aka.ms/devtoolsforteaching) je nově dostupné v Azure Dev Tools for Teaching. Přihlášení je nutné s loginem z domény VUT, tj xlogin00@vutbr.cz
 - Při vytváření repozitáře respektujte schéma ze [zadání](/Project/README.md) *https://dev.azure.com/ics-2022-team0000/project*. Je nezbytně nutné použít Vaše účty z domény *vutbr.cz*. Do Vašich repozitářů pro projekt přidejte účet **uciteliw5@vutbr.cz**. Pokud uděláte chybu a pouze nesedí url, dá se v nastavení změnit.
    * Pokud máte vytvořeno pod soukromými účty, je třeba vytvořit projekt znovu pod univerzitními a pushnout existující repozitář tak, aby Vám zůstala historie včetně správných časů commitů.
    * Účet **uciteliw5@vutbr.cz** přidejte jako poslední a ujistěte se, že má nastavena oprávnění `Stakeholder`. Vaše účty musí mít oprávnění `Basic`, abyste viděli kód. Nastavení oprávnění organizace uvidíte na **https://dev.azure.com/ics-2022-team0000/_settings/users**.

---

# Rozvrh

## Přednášky

| Typ       | Místnost | Čas            |
| --------- | -------- | -------------- |
| Přednáška | D105     | Pá 08:00-09:50 |

+++

## Cvičení
Cvičení jsou demonstrační. Pokud možno, přineste si vlastní zařízení, na kterém budete moct cvičení aktivně zúčastnit. Bude potřeba vývojové prostředí ideálně Visual Studio 2022 / Rider / VSCode.

| Typ                             | Místnost | Čas            |
| ------------------------------- | -------- | -------------- |
| Dobrovolné demonstrační cvičení | D105     | Pá 10:00-11:50 |

+++

## Plán semestru

| Datum    | Typ | Téma přednášky                                                                                                                                                                                         |
| -------- | --- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| 11.02.   | L01 | [Úvod do jazyka C# a platformy .NET](https://nesfit.github.io/ICS/Lectures/Lecture_01/_site/) - základní syntaxe jazyka ([verze pro tisk](https://nesfit.github.io/ICS/Lectures/Lecture_01/_site/?print-pdf))                                                                               |
|          | E01 | Práce s Visual Studio 2022 a Azure DevOps (základy pro zracování projektu)                                                                                                                                                              |
| 18.02.   | L02 | [Úvod do Objektově Orientovaného Programování](https://nesfit.github.io/ICS/Lectures/Lecture_02/_site/) ([verze pro tisk](https://nesfit.github.io/ICS/Lectures/Lecture_02/_site/?print-pdf))                                                                                                |
|          | E02 | Objektově orientované programování a úvod do Entity Framework                                                                                                                                          |
| 25.02.   | L03 | [Představení základních knihovních funkcí (BCL)](https://nesfit.github.io/ICS/Lectures/Lecture_03/_site/) - dotazování za pomocí vestavěného nástroje LINQ nad datovými zdroji (kolekcemi, XML, MSSQL) ([verze pro tisk](https://nesfit.github.io/ICS/Lectures/Lecture_03/_site/?print-pdf))|
| 04.03.   | L04 | [Propojení aplikace s databází](https://nesfit.github.io/ICS/Lectures/Lecture_04/_site/) ([verze pro tisk](https://nesfit.github.io/ICS/Lectures/Lecture_04/_site/?print-pdf))                                                                                                              |
|          | E03 | Entity framework                                                                                                                                                                                       |
| 06.03.   | P01 | Odevzdání první fáze projektu                                                                                                                                                                          |
| 11.03.   | L05 | Psaní čistého a udržovatelného kódu                                                                                                                                                                    |
| 18.03.   | L06 | Návrhový vzor Model-View-ViewModel (MVVM)                                                                                                                                                              |

+++

| Datum    | Typ | Téma přednášky                                                                                                                                                                                         |
| -------- | --- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| 25.03.   | L07 | Automatizované testování - práce s xUnit, CI                                                                                                                                                           |
| 01.04.   | L08 | [Základní koncepty tvorby uživatelského rozhraní](https://nesfit.github.io/ICS/Lectures/Lecture_08/_site/) ([verze pro tisk](https://nesfit.github.io/ICS/Lectures/Lecture_08/_site/?print-pdf))                                                                                            |
|          | E04 | Základy WPF a návrhový vzor MVVM                                                                                                                                                                       |
| 08.04.   | L09 | WPF - tvorba komponent a stylování aplikací.                                                                                                                                                           |
|          | E05 | WPF frontend a binding                                                                                                                                                                                 |
| 10.04.   | P02 | Odevzdání druhé fáze projektu                                                                                                                                                                           |
| 15.04.   | L10 | Velikonoce - Velký Pátek                                                                                                                                                                               |
| 22.04.   | L11 | [Paralelní a asynchronní programování](https://nesfit.github.io/ICS/Lectures/Lecture_10/_site/) - proces, vlákno, úloha z pohledu C# a použitého .NET frameworku ([verze pro tisk](https://nesfit.github.io/ICS/Lectures/Lecture_10/_site/?print-pdf))                                      |
|          | E06 | Takto můžete napsat projekt?!                                                                                                                                                                          |
| 29.04.   | L12 | Návrhové vzory - vytvářecí, strukturní a chování - Gang of Four (GoF) v kontextu C#                                                                                                                    |
| 03-04.05 | P03 | Obhajoby projektu                                                                                                                                                                                      |
| 06.05.   | L13 | Multiplatformní programování - .NET Standard, .NET Core., kontejnerizace aplikací pomocí Docker                                                                                                        |

LXY - přednáška | EXY - democvičení | P0X - projekt

---

# Projekt
* Projekt bude vypracovaný v 5ti členném týmu.

| Fáze | Obsah                                   | Body |
| ---- | --------------------------------------- | ---- |
| 1    | Objektový návrh                         | 20   |
| 2    | Entity Framework, Repository, Tests     | 30   |
| 3    | Finalizace aplikace a následná obhajoba | 50   |

* Při obhajobě:
  * musí být přítomni všichni členové týmu,
  * obhajovat projekt bude náhodně vybraný člen týmu,
  * nemusíte chodit v obleku...,

---

# Nástroje použity ve cvičeních

| Nástroj                                                                                              | Typ                | Popis                                                                                                                             |
| ---------------------------------------------------------------------------------------------------- | ------------------ | --------------------------------------------------------------------------------------------------------------------------------- |
| [Visual Studio 2022](https://aka.ms/devtoolsforteaching)                                             | Samostatný program | Hlavní vývojové prostředí pro .Net                                                                                                |
| [Resharper](https://www.jetbrains.com/resharper/)                                                    | Doplněk            | Nástroje na lepší produktivitu, refaktorování. Studentská licence je k dispozici zdarma [zde](https://www.jetbrains.com/student/) |
| [Code metrices](https://visualstudiogallery.msdn.microsoft.com/369d38e1-53d3-4f5c-9351-a0560162a6d9) | Doplněk            | Zobrazování složitosti jednotlivých metod                                                                                         |

+++

| Nástroj                                                                                             | Typ                | Popis                                          |
| --------------------------------------------------------------------------------------------------- | ------------------ | ---------------------------------------------- |
| [LinqPad](http://www.linqpad.net/)                                                                  | Samostatný program | Nástroj na přístup do databáze přes Linq, SQL… |
| [DotPeek](https://www.jetbrains.com/decompiler/)                                                    | Samostatný program | Dekompilátor C# kódu                           |
| [MarkdownEditor](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor) | Doplněk            | Handy Markdown editor for VS                   |

---

* Q: Connection string používaný v cvičeních.
* A:

```XML
<connectionStrings>
  <add name="TasksContext"
       connectionString="Data Source=(LocalDB)\MSSQLLocalDB;
                         Initial Catalog=TasksDB;
                         MultipleActiveResultSets=True;
                         Integrated Security=True;"
           providerName="System.Data.SqlClient" />
</connectionStrings>
```

---

# Výuka - bodové rozdělení

| Typ výuky | Maximální bodový zisk |
| --------- | --------------------- |
| Projekt   | 100                   |

---

# Vyučující
* [Martin Dybal](https://www.linkedin.com/in/martin-dybal)
* [Roman Jašek](https://www.linkedin.com/in/roman-jasek-16921839)
* [Tibor Jašek](https://www.linkedin.com/in/tibor-jašek-717a5761)
* [Michal Mrnuštík](https://www.linkedin.com/in/michal-mrnušt%C3%ADk-31050b60/)
* [Michal Tichý]()
* [Jan Pluskal](https://www.fit.vut.cz/person/ipluskal)
* [Michal Koutenský](https://www.fit.vut.cz/person/koutenmi)

---

# Užitečné odkazy
* [WPF-Tutorial](https://wpf-tutorial.com/)
* [Entity framework tutorial](http://www.entityframeworktutorial.net/code-first/entity-framework-code-first.aspx)
* [R. C. Martin SOLID](https://youtu.be/TMuno5RZNeE?t=757) Bob Martin SOLID Principles of Object Oriented and Agile Design
* [Resharper features](https://www.jetbrains.com/resharper/features/) and how to use them.
* [Pro Git book](https://git-scm.com/book/en/v2)

---

# Užitečná literatura
* [C# 9.0 in a Nutshell](https://www.amazon.com/C-9-0-Nutshell-Definitive-Reference/dp/1098100964), Ben Albahari, Joseph Albahari
* [Clean Code: A Handbook of Agile Software Craftsmanship](https://books.google.cz/books?id=hjEFCAAAQBAJ), Robert C. Martin
* [Agile Principles, Patterns, and Practices in C#](https://books.google.cz/books?id=hckt7v6g09oC), Robert C. Martin
* [C# 3.0 Design Patterns](https://books.google.cz/books?id=pD2XMZLGUAYC), Judith Bishop
* [The Art of Unit Testing](https://books.google.cz/books?id=2GRRmgEACAAJ&dq=the+art+of+unit+testing&hl=en&sa=X&ved=0ahUKEwjLhJeRx7DnAhU3AGMBHeScBisQ6AEILDAA), Roy Osherove

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
+++
![](_reveal-md/img/logo.png)