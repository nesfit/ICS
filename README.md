# Seminář C# - ICS, Organizational Details

---

# Aktuality k předmětu
 - **01.02.2019** | *Jan Pluskal* | [Visual Studio 2019 Enterprise](https://aka.ms/devtoolsforteaching) je nově dostupné v Azure Dev Tools for Teaching. Přihlášení je nutné s loginem z domény VUT, tj xlogin00@vutbr.cz
 - **01.01.2019** | *Jan Pluskal* | Při vytváření repozitáře respektujte schéma ze [zadání](/Project/README.md) *https://dev.azure.com/ics-2019-team0000/project*. Je nezbytně nutné použít Vaše účty z doménu *vutbr.cz*. Do Vašich repozitářů pro projekt přidejte účet **uciteliw5@vutbr.cz**. Pokud uděláte chybu a pouze nesedí url, dá se v nastavení změnit.
    * Pokud máte vytvořeno pod soukromými účty, je třeba vytvořit projekt znovu pod univerzitními a pushnout existující repozitář tak, aby Vám zůstala historie včetně správných časů commitů.
    * Pokud bude kolize s existující organizací, použijte suffix *team0000-01*.

---

# Přednášky

| Typ                                  | Místnost | Čas            |
| ------------------------------------ |----------| -------------- |
| Přednáška                            | D0206    | Po 13:00-14:50 |

+++

0. [Organizace kurzu](https://gitpitch.com/nesfit/ics?grs=github&t=white&p=Lectures%2FLecture_00#/)
1. [Úvod do jazyka C# a platformy .NET](https://gitpitch.com/nesfit/ics?grs=github&t=white&p=Lectures%2FLecture_01#/)
   * základní syntaxe jazyka, instalace a představení Visual Studia
2. [Úvod do Objektově Orientované Programování](https://gitpitch.com/nesfit/ics?grs=github&t=white&p=Lectures%2FLecture_02#/)
   * pokročilé konstrukce v jazyce C# - výjimky, události, delegáty, lambda výrazy a generika
3. [Představení základních knihovních funkcí (BCL)](https://gitpitch.com/nesfit/ics?grs=github&t=white&p=Lectures%2FLecture_03#/)
   * dotazování za pomocí vestavěného nástroje LINQ nad datovými zdroji (kolekcemi, XML, MSSQL)
4. [Propojení aplikace s databází](https://gitpitch.com/nesfit/ics?grs=github&t=white&p=Lectures%2FLecture_04#/)
   * zajištění persistence pomocí ORM rozšíření Entity Framework s návrhovými vzory UnitOfWork a Repository
5. Psaní čistého, udržovatelného kódu
   * respektováním Clean Code, S.O.L.I.D. zásad
   * ukázky refaktorizace a práce s legacy kódem
6. Návrhový vzor Model-View-ViewModel (MVVM)
   * architektura desktopových aplikací
   * mapování databázových entit na modelové třídy

+++

7. Continous Integration v prostředí Azure DevOps
   * testování aplikací - smoke, unit, integrační, UI a akceptační testy
8. [Základní koncepty tvorby uživatelského rozhraní](https://gitpitch.com/nesfit/ics?grs=github&t=white&p=Lectures%2FLecture_08#/)
   * Windows Presentation Foundation (WPF)
9. Návrhové vzory
   * vytvářecí, strukturní a chování - Gang of Four (GoF) v kontextu C#
10. WPF za pomoci MVVM, tvorba komponenty a stylování aplikací.
11. Velikonoční pondělí
11. [Paralelní a asynchronní programování](https://gitpitch.com/nesfit/ics?grs=github&t=white&p=Lectures%2FLecture_11#/)
    * proces, vlákno, úloha z pohledu C# a použitého .NET frameworku
12. Multiplatformní programování
    * .NET Standard, .NET Core.
    * kontejnerizace aplikací pomocí Docker a jejich orchestrace Kubernetes, Docker Swarm

---

# Cvičení
Cvičení jsou demonstrační. Pokud možno, přineste si vlastní zařízení na kterém budete moct cvičení aktivně zúčastnit. Bude potřeba vývojové prostředí ideálně Visual Studio 2019 / Rider / VSCode.

| Typ                                  | Místnost | Čas            |
| ------------------------------------ |----------| -------------- |
| Dobrovolné demonstrační cvičení      | D0206    | Po 15:00-16:50 |

+++

| Datum  |                                                 Téma cvičení |
| ------ | ------------------------------------------------------------ |
| 03.02. | Práce s Visual Studio 2019, Azure DevOps                     |
| 10.02. | Objektově orientované programování, úvod do Entity Framework |
| 24.02. | Entity framework                                             |
| 23.03. | Základy WPF, návrhový vzor MVVM                              |
| 06.04. | WPF frontend, binding                                        |
| 20.04. | Takto můžete napsat projekt?!                                |

---

# Projekt
* Projekt bude vypracovaný v 3-5ti členném týmu.

| Fáze |            Deadline |                                   Obsah | Body |
| ---- | ------------------- | --------------------------------------- | ---- |
| 1    |              08.03. | Objektový návrh                         |   20 |
| 2    |              05.04. | Entity Framework, Repository, Tests     |   30 |
| 3    | Den před odevzdáním | Finalizace aplikace a následná obhajoba |   50 |

* Při obhajobě:
  * musí být přítomni všichni členové týmu,
  * obhajovat projekt bude náhodně vybraný člen týmu,
  * nemusíte chodit v obleku...,
  * projekt musí bezpodmínečně obsahovat **Must have features!**

---

# Nástroje použity ve cvičeních

| Nástroj  |  Typ   | Popis |
| -------- |  ------| -------|
|[Visual Studio 2019 Enterprise](https://aka.ms/devtoolsforteaching) | Samostatný program | Hlavní vývojové prostředí pro .Net |
|[Resharper](https://www.jetbrains.com/resharper/) | Doplněk | Nástroje na lepší produktivitu, refaktorování. Studentská licence je k dispozici zdarma [zde](https://www.jetbrains.com/student/) |
|[Code metrices](https://visualstudiogallery.msdn.microsoft.com/369d38e1-53d3-4f5c-9351-a0560162a6d9) | Doplněk | Zobrazování složitosti jednotlivých metod |

+++

| Nástroj  |  Typ   | Popis |
| -------- |  ------| -------|
|[Postifx templates](https://github.com/controlflow/resharper-postfix) | Doplněk | Plynulé doplňování částí kódu bez nutnosti vracení se |
|[Mnemonic Live Templates](https://github.com/JetBrains/mnemonics) | Doplněk | Doplňování částí kódu |
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
* [Martin Dybal](https://www.dybal.it/)
* [Roman Jašek]()
* [Tibor Jašek]()
* [Adam Jež]()
* [Viliam Letavay]()
* [Michal Mrnušťík]()
* [Jan Pluskal](http://www.fit.vutbr.cz/~ipluskal/)
* [Jiří Pokorný]()
* [Patrik Švikruha]()

---

# Užitečné odkazy
* [WPF-Tutorial](https://wpf-tutorial.com/)
* [Entity framework tutorial](http://www.entityframeworktutorial.net/code-first/entity-framework-code-first.aspx)
* [R. C. Martin SOLID](https://youtu.be/TMuno5RZNeE?t=757) Bob Martin SOLID Principles of Object Oriented and Agile Design
* [Resharper features](https://www.jetbrains.com/resharper/features/) and how to use them.
* [Pro Git book](https://git-scm.com/book/en/v2)

---

# Užitečná literatura
* [C# 8.0 in a Nutshell](https://books.google.cz/books/about/C_8_0_in_a_Nutshell.html?id=Y1tLwwEACAAJ&redir_esc=y), Ben Albahari, Joseph Albahari
* [Clean Code: A Handbook of Agile Software Craftsmanship](https://books.google.cz/books?id=hjEFCAAAQBAJ), Robert C. Martin
* [Agile Principles, Patterns, and Practices in C#](https://books.google.cz/books?id=hckt7v6g09oC), Robert C. Martin
* [C# 3.0 Design Patterns](https://books.google.cz/books?id=pD2XMZLGUAYC), Judith Bishop
* [The Art of Unit Testing](https://books.google.cz/books?id=2GRRmgEACAAJ&dq=the+art+of+unit+testing&hl=en&sa=X&ved=0ahUKEwjLhJeRx7DnAhU3AGMBHeScBisQ6AEILDAA), Roy Osherove
