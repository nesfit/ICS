# Seminář C# - ICS

# Aktuality k předmětu 
  - **08.01.2019** | *Jan Pluskal* | Při vytváření repozitáře respektujte shéma ze [zadání](/Project/README.md) *https://ics-2019-team00.visualstudio.com*, https://ics-iw5-2019-team00.visualstudio.com. Je nezbytně nutné použít Vaše účty z doménu *vutbr.cz*. Do Vašich repozitářů pro projekt přidejte účet **uciteliw5@vutbr.cz**. Pokud uděláte chybu a pouze nesedí url, dá se v nastavení změnit. Pokud máte vytvořeno pod soukromými účty, je třeba vytvořit projekt znovu pod univerzitními a pushnout existující repozitář tak, aby Vám zůstala historie včetně správných časů commitů. Pokud bude kolize s existujícím účtem, použijte url *https://ics-2019-team00-01.visualstudio.com*.
  - **03.12.2018** | *Jan Pluskal* | Byl vytvořen repozitář.

# Rozvrh
| Typ                                  | Místnost | Čas            |
| ------------------------------------ |----------| -------------- |
| Přednáška                            | D105     | Po 15:00-16:50 |
| Demonstrační cvičení (dobrovolné)    | D105     | Čt 18:00-19:50 |

| Datum |                                                 Téma cvičení | 
| ----- | ------------------------------------------------------------ | 
| 7.2.  | Práce s Visual Studio 2017, Azure DevOps                     | 
| 21.2. | Objektově orientované programování, úvod do Entity Framework | 
| 7.3.  | Entity framework, zásady Clean Code, SOLID                   | 
| 21.3. | Základy WPF, návrhový vzor MVVM                              | 
| 4.4.  | WPF frontend, binding                                        | 
| 18.4. | Bonusové cvičení                                             | 

# Přednášky
1. Úvod do jazyka C# a platformy .NET, základní syntaxe jazyka, instalace a představení Visual Studia.
2. Úvod do Objektově Orientované Programování a pokročilé konstrukce v jazyce C# - výjimky, události, delegáty, lambda výrazy a generika.
3. Představení základních knihovních funkcí (BCL) a dotazování za pomocí vestavěního nástroje LINQ nad datovými zdroji (kolekcemi, XML, MSSQL).
4. Propojení aplikace s databází pro zajištění persistence pomocí ORM rozšíření Entity Framework s návrhovými vzory UnitOfWork a Repository.
5. Psaní čistého, udržovatelného kódu s respektováním Clean Code, S.O.L.I.D. zásad. Ukázky refaktorizace a práce s legacy kódem.
6. Návrhový vzor Model-View-ViewModel (MVVM) a architektura desktopových aplikací. Mapování databázových entit na modelové třídy.
7. Continous Integration v prostředí Azure DevOps a testování aplikací - smoke, unit, integrační, UI a akceptační testy.
8. Základní koncepty tvorby uživatelského rozhraní pomocí Windows Presentation Foundation (WPF).
9. Návrhové vzory pro práci s vytvářením, strukturováním a chováním - Gang of Four (GoF) v kontextu C#.
10. WPF za pomoci MVVM, tvorba komponenty a stylování aplikací.
11. Paralelní a asynchroní programování proces, vlákno, úloha z pohledu C# a použitého .NET frameworku.
12. Multiplatformní programování .NET Standard, .NET Core. Konteinerizace aplikací pomocí Docker a jejich orchestrace Kubernetes, Docker Swarm.
12. *Dobrovolná přednáška* **D0206 13:00-14:50 29.4.2019** -- Nástroje pro správu paměti a profilaci výkonu.


# Demonstrační Cvičení 
Dobrovolné demonstrační cvičení se koná každý sudý týden. Cvičení bude probíhat od prvního týdne semestru. Značení týdne sudý/lichý je podle kalendáře (ISO 8601). [Jaky je tyden?](https://jakyjetyden.cz/)

# Nástroje použity ve cvičeních

| Nástroj  |  Typ   | Popis |
| -------- |  ------| -------|
| [Visual Studio 2017 FIT](https://e5.onthehub.com/WebStore/OfferingsOfMajorVersionList.aspx?pmv=4fec9f1d-6d0a-e711-9427-b8ca3a5db7a1&cmi_mnuMain=bdba23cf-e05e-e011-971f-0030487d8897&ws=95f320d0-826f-e011-971f-0030487d8897&vsro=8) <br /> [Visual Studio 2017 FEKT](https://e5.onthehub.com/WebStore/OfferingDetails.aspx?o=0e34bbfd-e242-e611-941e-b8ca3a5db7a1&pmv=00000000-0000-0000-0000-000000000000&ws=7817c804-8b6f-e011-971f-0030487d8897&vsro=8)| Samostatný program | Hlavní vývojové prostředí pro .Net |
|[Resharper](https://www.jetbrains.com/resharper/) | Doplněk | Nástroje na lepší produktivitu, refaktorování. Studentská licence je k dispozici zdarma [zde](https://www.jetbrains.com/student/) |
|[Code metrices](https://visualstudiogallery.msdn.microsoft.com/369d38e1-53d3-4f5c-9351-a0560162a6d9) | Doplněk | Zobrazování složitosti jednotlivých metod |
|[Postifx templates](https://github.com/controlflow/resharper-postfix) | Doplněk | Plynulé doplňování částí kódu bez nutnosti vracení se |
|[Mnemonic Live Templates](https://github.com/JetBrains/mnemonics) | Doplněk | Doplňování částí kódu |
|[LinqPad](http://www.linqpad.net/) | Samostatný program  | Nástroj na přístup do databáze přes Linq, SQL… |
|[DotPeek](https://www.jetbrains.com/decompiler/) | Samostatný program  | Dekompilátor C# kódu |
|[MarkdownEditor](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor)| Doplněk| Handy Markdown editor for VS |
|[Entity Framework 6 Power Tools](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EntityFramework6PowerToolsCommunityEdition)| Doplněk| View Entity Data Model|
|[OzCode](https://www.oz-code.com/)| Doplněk| Advanced debugging tools |
|[GitFlow](https://marketplace.visualstudio.com/items?itemName=vs-publisher-57624.GitFlowforVisualStudio2017)| Doplněk| GitFlow|


# Q&A
* Q: Je možné vypracovat projekt v menším počtu členů?
* A: Bohužel, v rámci zachování kvality nejsme schopni opravit takové množství projektů jako by povolení dvou-členných týmů přinášelo. Projek je navržený tak, aby vyhovoval náročností 5-ti členému týmu a některé koncepty by v případě menšího množství členů postrádaly smysl.
* Q: Connection string pouzivany v cvicenich.
* A: ```<connectionStrings> 
      <add name="TasksContext" connectionString="Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=TasksDB;MultipleActiveResultSets=True;Integrated Security=True;" providerName="System.Data.SqlClient" />
      </connectionStrings>```
      
# Výuka - bodové rozdělení
|      Typ výuky     | Maximální bodový zisk |
| ------------------ | --------------------- |
| Projekt            |                   100 |

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

# Užitečné odkazy
* [Entity framework tutorial](http://www.entityframeworktutorial.net/code-first/entity-framework-code-first.aspx)
* [R. C. Martin SOLID](https://youtu.be/TMuno5RZNeE?t=757) Bob Martin SOLID Principles of Object Oriented and Agile Design 
* [Resharper features](https://www.jetbrains.com/resharper/features/) and how to use them.
* [Pro Git book](https://git-scm.com/book/en/v2)

# Užitečná literatura
* [C# 7.0 in a Nutshell](http://www.albahari.com/nutshell/about.aspx), Ben Albahari, Joseph Albahari
* [Clean Code: A Handbook of Agile Software Craftsmanship](https://books.google.cz/books?id=hjEFCAAAQBAJ), Robert C. Martin
* [Agile Principles, Patterns, and Practices in C#](https://books.google.cz/books?id=hckt7v6g09oC), Robert C. Martin
* [C# 3.0 Design Patterns](https://books.google.cz/books?id=pD2XMZLGUAYC), Judith Bishop
