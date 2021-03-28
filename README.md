# Seminář C# - ICS, Organizační pokyny

---

# Aktuality k předmětu
 - [Visual Studio 2019 Enterprise](https://aka.ms/devtoolsforteaching) je nově dostupné v Azure Dev Tools for Teaching. Přihlášení je nutné s loginem z domény VUT, tj xlogin00@vutbr.cz
 - Při vytváření repozitáře respektujte schéma ze [zadání](/Project/README.md) *https://dev.azure.com/ics-2021-team0000/project*. Je nezbytně nutné použít Vaše účty z domény *vutbr.cz*. Do Vašich repozitářů pro projekt přidejte účet **uciteliw5@vutbr.cz**. Pokud uděláte chybu a pouze nesedí url, dá se v nastavení změnit.
    * Pokud máte vytvořeno pod soukromými účty, je třeba vytvořit projekt znovu pod univerzitními a pushnout existující repozitář tak, aby Vám zůstala historie včetně správných časů commitů.
    * Pokud bude kolize s existující organizací, použijte suffix *team0000-01*.

---

# Přednášky

| Typ                                  | Místnost | Čas            |
| ------------------------------------ |----------| -------------- |
| Přednáška                            | D0206    | Po 13:00-14:50 |

+++

0. Organizace kurzu
1. [Úvod do jazyka C# a platformy .NET](https://nesfit.github.io/ICS/Lectures/Lecture_01/_site/)
   * základní syntaxe jazyka, instalace a představení Visual Studia
2. [Úvod do Objektově Orientované Programování](https://nesfit.github.io/ICS/Lectures/Lecture_02/_site/)
   * pokročilé konstrukce v jazyce C# - výjimky, události, delegáty, lambda výrazy a generika
3. [Představení základních knihovních funkcí (BCL)](https://nesfit.github.io/ICS/Lectures/Lecture_03/_site/)
   * dotazování za pomocí vestavěného nástroje LINQ nad datovými zdroji (kolekcemi, XML, MSSQL)
4. [Propojení aplikace s databází](https://nesfit.github.io/ICS/Lectures/Lecture_04/_site/)
   * zajištění persistence pomocí ORM rozšíření Entity Framework Core s návrhovými vzory UnitOfWork a Repository
5. Psaní čistého, udržovatelného kódu
   * respektováním Clean Code, S.O.L.I.D. zásad
   * ukázky refaktorizace a práce s legacy kódem
6. Návrhový vzor Model-View-ViewModel (MVVM)
   * architektura desktopových aplikací
   * mapování databázových entit na modelové třídy

+++

7. Continous Integration v prostředí Azure DevOps
   * testování aplikací - smoke, unit, integrační, UI a akceptační testy
8. [Základní koncepty tvorby uživatelského rozhraní](https://nesfit.github.io/ICS/Lectures/Lecture_08/_site/)
   * Windows Presentation Foundation (WPF)
9. Velikonoční pondělí
10. WPF za pomoci MVVM, tvorba komponenty a stylování aplikací.
11. [Paralelní a asynchronní programování](https://gitpitch.com/nesfit/ics/master?grs=github&t=white&p=Lectures%2FLecture_11#/)
    * proces, vlákno, úloha z pohledu C# a použitého .NET frameworku
12. Návrhové vzory
   * vytvářecí, strukturní a chování - Gang of Four (GoF) v kontextu C#
13. Multiplatformní programování
    * .NET Standard, .NET Core.
    * kontejnerizace aplikací pomocí Docker  

---

# Cvičení
Cvičení jsou demonstrační. Pokud možno, přineste si vlastní zařízení na kterém budete moct cvičení aktivně zúčastnit. Bude potřeba vývojové prostředí ideálně Visual Studio 2019 / Rider / VSCode.

| Typ                                  | Místnost | Čas            |
| ------------------------------------ |----------| -------------- |
| Dobrovolné demonstrační cvičení      | D0206    | Po 15:00-16:50 |

+++

| Datum  |                                                 Téma cvičení |
| ------ | ------------------------------------------------------------ |
| 08.02. | Práce s Visual Studio 2019, Azure DevOps                     |
| 15.02. | Objektově orientované programování, úvod do Entity Framework |
| 01.03. | Entity framework                                             |
| 29.03. | Základy WPF, návrhový vzor MVVM                              |
| 12.04. | WPF frontend, binding                                        |
| 19.04. | Takto můžete napsat projekt?!                                |

---

# Projekt
* Projekt bude vypracovaný v 4-5ti členném týmu.

| Fáze |            Deadline |                                   Obsah | Body |
| ---- | ------------------- | --------------------------------------- | ---- |
| 1    |              14.03. | Objektový návrh                         |   20 |
| 2    |              11.04. | Entity Framework, Repository, Tests     |   30 |
| 3    | Den před odevzdáním | Finalizace aplikace a následná obhajoba |   50 |

* Při obhajobě:
  * musí být přítomni všichni členové týmu,
  * obhajovat projekt bude náhodně vybraný člen týmu,
  * nemusíte chodit v obleku...,

---

# Nástroje použity ve cvičeních

| Nástroj  |  Typ   | Popis |
| -------- |  ------| -------|
|[Visual Studio 2019 Community](https://aka.ms/devtoolsforteaching) | Samostatný program | Hlavní vývojové prostředí pro .Net |
|[Resharper](https://www.jetbrains.com/resharper/) | Doplněk | Nástroje na lepší produktivitu, refaktorování. Studentská licence je k dispozici zdarma [zde](https://www.jetbrains.com/student/) |
|[Code metrices](https://visualstudiogallery.msdn.microsoft.com/369d38e1-53d3-4f5c-9351-a0560162a6d9) | Doplněk | Zobrazování složitosti jednotlivých metod |

+++

| Nástroj  |  Typ   | Popis |
| -------- |  ------| -------|
|[LinqPad](http://www.linqpad.net/) | Samostatný program  | Nástroj na přístup do databáze přes Linq, SQL… |
|[DotPeek](https://www.jetbrains.com/decompiler/) | Samostatný program  | Dekompilátor C# kódu |
|[MarkdownEditor](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor)| Doplněk| Handy Markdown editor for VS |

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

|      Typ výuky     | Maximální bodový zisk |
| ------------------ | --------------------- |
| Projekt            |                   100 |

---

# Vyučující
* [Martin Dybal](https://www.linkedin.com/in/martin-dybal)
* [Roman Jašek](https://www.linkedin.com/in/roman-jasek-16921839)
* [Tibor Jašek](https://www.linkedin.com/in/tibor-jašek-717a5761)
* [Michal Mrnuštík](https://www.linkedin.com/in/michal-mrnušt%C3%ADk-31050b60/)
* [Michal Tichý]()
* [Jan Pluskal](http://www.fit.vutbr.cz/~ipluskal/)

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
