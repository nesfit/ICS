# ICS projekt

## Důležité upozornění
Pro hodnocení projektu 49+ body je nutné dokončit všechny fáze a projekt úspěšně obhájit. Každá fáze projektu musí být hodnocena minimálně 1b. Při obhajobě projektu je vyžadována demonstrace **základní funkcionality**, jinak je obhajoba hodnocena 0b.

## Cíl
Cílem je vytvořit použitelnou a snadno rozšiřitelnou aplikaci, která splňuje požadavky zadání. Aplikace nesmí padat nebo zamrzávat. Pokud uživatel vyplní něco špatně, je upozorněn **validační hláškou**.

Zadání ponechává volnost, pro vlastní realizaci. Při hodnocení je kladen důraz na technické zpracování a kvalitu kódu, nicméně hodnotí se i uživatelská přívětivost a grafické zpracování. 

Pokud Vám přijde, že v zadání chybí nějaká funkcionalita, neváhejte ji doplnit a zdokumentovat v **README.md**. 

<!-- Project specific -->
# Téma projektu
Tématem letošního projektu je vytvoření "Správce playlistů multimédií".

Vytváříte aplikaci, která je schopna uchovávat informace o multimediálních souborech (hudba, video, audiobook), dle Vaší volby, tedy může to být jen jeden typ souboru, nebo všechny. Uživatel si je schopen zobrazit jaká multimédia má k dispozici, vytvořit si playlisty.

> :info: Zadání zvažuje pouze práci s metadaty, ne soubory samotnými. Pokud se rozhodnete pracovat se soubory, budeme to považovat za rozšíření. Doporučujeme nepracovat se soubory jako takovými, ale pouze URL na soubory, které jsou volně na internetu k dispozici. Pokud se rozhodnete pracovat se soubory samotnými, nebudeme bodově penalizovat chyby, které nespadají do vyučovaného rozsahu předmětu. Dostanete pouze zpětnou vazbu k implementaci funkcionality nad rámec řešení.

> Jako rozšíření můžete implementovat [přehrávání daných multimédií](https://devblogs.microsoft.com/dotnet/announcing-dotnet-maui-communitytoolkit-mediaelement/).

---

<!-- Project specific -->
## Data
V rámci dat, se kterými se bude pracovat budeme požadovat minimálně následující data.

Zamyslete se, zdali je třeba všechny informace ukládat do databáze anebo některé můžete dopočítat během dotazování.

### Multimediální soubor
- Název
- Popis
- Velikost
- Délka
- Autor (pokud dává smysl v tématu Vaší aplikace)
- Kategorie (pokud dává smysl v tématu Vaší aplikace)
- (Playlisty)

### Playlist
- Název
- Popis
- Počet obsažených multimédií
- Celková délka obsažených multimédií
- (Multimédia)


> () anotují možné/doporučené vazby mezi entitami

---

Další možné datové entity pro nepovinné rozšíření aplikace: uživatel, autor, metadata multimédií... 

---
## Základní funkcionalita
Aplikace bude obsahovat několik pohledů pro zobrazování přehledu, zobrazení detailu a vložení dat. 

Je požadováno **perzistentní** uložení. To znamená, že když se aplikace restartuje, tak nesmí přijít o data. Uložení dat musí být provedeno neprodleně po zadání operace uživatelem. 

Při demonstraci bude vyžadováno souběžné spuštění několika aplikací a změny v jedné aplikaci se musí projevit v ostatních instancích. **Znovu-načtení** dat může být inicializováno uživatelem. 

Pro uložení dat zvolte [SQLite](https://www.sqlite.org/index.html). Jako ORM framework použijte [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/).

<!-- Project specific -->
*Minimální* funkcionalita:
  - **Aplikace musí umožnit provést CRUD operace nad všemi daty.**
  - V aplikaci se dá **filtrovat** dle všech položek, které dávají smysl v kontextu aplikace.
  - V aplikaci se dá **vyhledávat** dle všech položek, které dávají smysl v kontextu aplikace.
  - V aplikaci se dá **řadit** v listových pohledech dle všech položek, které dávají smysl v kontextu aplikace.
  - Operace **filtrace, vyhledávání, řazení probíhají v databázi**. Aplikace si **nesmí** stáhnout všechna data / DB tabulku do paměti a provádět tyto operace nad objekty v paměti.
 
---
## Architektura projektu
Architektura aplikace je jeden z důležitých stavebních kamenů při vývoji SW. V rámci cvičení se seznámíte s vrstvenou architekturou demonstrující logickou separaci tříd do projektů (alespoň App, BL, DAL), kterou vřele doporučujeme využít i ve Vašich projektech (klidně 1:1).

> :warning: Pokud by měl někdo zájem využít jinou architekturu, např. Clean architecture (bonus body), tak je vhodné [předem konzultovat](pluskal@vut.cz).

V případě, kdy se rozhodnete použít jinou architekturu a rozdělení tříd do projektů musíte být schopni své rozhodnutí odůvodnit a flexibilně reagovat na dotazy při obhajobě.

Řešení obsahující nevhodné rozdělení tříd do projektů, které si nedokážete obhájit bude penalizováno značnou bodovou ztrátou.

> :warning: **Solution obsahující jediný projekt není akceptovatelné!**

---
## Správa projektu – Azure DevOps
Při řešení projektu využijte Azure DevOps a GIT na sdílení kódu. Do svého projektu přidělte přístup vyučujícím (způsob byl vysvětlen v rámci 1. cvičení (E01)); tj. do Vašeho týmového projektu si v části Members přidejte účet **uciteliw5@vutbr.cz**.

Účet **uciteliw5@vutbr.cz** budou používat vyučující pro přístup k odevzdávaným souborům. Bez přidání tohoto účtu není možné přistoupit k vašemu projektu, a tedy není možné jej ze strany vyučujících hodnotit.

Účet **uciteliw5@vutbr.cz** přidejte jako poslední a ověřte, že má nastavena oprávnění na **Stakeholder**. V opačném případě jeden ze členů týmu nebude vidět zdrojový kód. Azure DevOps umožňuje v bezplatné verzi pouze 5 aktivních vývojářů.

> :warning: **Je bezpodmínečně nutné**, abyste přidali účet **uciteliw5@vutbr.cz** do **Project Collection Administrator** v nastavení organizace – *https://dev.azure.com/ics-2025-xlogin00/_settings/groups*. Toto nastavení nám umožní během opravování projektu jednomu členu Vašeho týmu změnit **access level** z **Basic** na **Stakeholder** a dočasně tak přiřadit úroveň **Basic** našemu účtu **uciteliw5@vutbr.cz**. Po skončení opravování Vám nastavení uvedeme do původního stavu. Pokud by se tak nestalo, neváhejte si nastavení změnit sami. **Základní práce s Azure DevOps byla vysvětlena na 1. demonstračním cvičení (E01)**.

Návod na přidání člena projektu můžete najít zde: *https://docs.microsoft.com/en-us/vsts/accounts/add-team-members-vs*

Z GITu *musí být viditelná postupná práce na projektu a spolupráce týmu*. Pokud uvidíme, že existuje malé množství nelogických a nepřeložitelných commitů tak nás bude zajímat, jak jste spolupracovali a může to vést na snížení bodového hodnocení. Doporučujeme použít [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/).

Výrazně doporučujeme používat mechanismu **pull-request**ů ["GIT Branching strategy"](https://medium.com/@sreekanth.thummala/choosing-the-right-git-branching-strategy-a-comparative-analysis-f5e635443423) a dělat si vzájemně review kódu, který následně mergnete do master nebo main větve. Projekt vypracováváte jako tým a nesete tak **kolektivní odpovědnost** za kvalitu kódu, proto je dobré, aby kód před začleněním vidělo více párů očí a vzájemně jste si jej připomínkovali. 

Organizaci pojmenujte **ics-2025-xlogin00** dle pojmenování týmu v IS (login zakladatele) a projekt **project** tak, že výsledné URL pro přístup pro tento imaginární tým by bylo https://dev.azure.com/ics-2025-xlogin00/project. Nezapomeňte nastavit **Work item process** template na **Scrum** nebo **Basic** (pokud to UI nabízí).

Využijte možnost automatizovaných buildů spojených s otestováním Vámi provedených změn. Nastavte **Pipelines->Builds** tak, že při pushnutí do libovolné větve projektu se provede *build a spustí se veškeré přítomné testy*. Více informací na [Automate all things with Azure Pipelines – THR2101](https://www.youtube.com/watch?v=yr6PJxfACNc)

---
### Konvence
Pro zajištění konzistence kódu, který produkujete je závazné respektovat následující body:
* Angličtina je základním jazykem použitým pro pojmenování identifikátorů, tříd atd... Jiné národní jazyky nejsou povoleny.
* Angličtina je základním jazykem použitým pro psaní komentářů. Jiné národní jazyky nejsou povoleny.
* Dodržujte zásady CleanCode probírané na přednáškách. K zajištění konzistence můžete využít `.editorconfig` konfigurovaný dle domluvy ve Vašem týmu. Není vhodné, aby Vám IDE při odevzdání hlásilo nekonzistence s Vámi zvolenými politikami. 

---
### Doporučení – za bonusové body při závěrečné obhajobě

* Pro řízení projektu využijte metodologii **[Scrum](https://docs.microsoft.com/en-us/azure/devops/boards/work-items/guidance/scrum-process-workflow?view=azure-devops)**. 
* Plánujte sprinty na jednotlivé fáze odevzdání. Práci rozdělte minimálně na **Product Backlog Item (PBI), Tasks a Bugs**. Využijete záložky **Boards** pro vzájemnou synchronizaci a **[Burndown chart](https://docs.microsoft.com/en-us/azure/devops/report/sql-reports/sprint-burndown-scrum?view=azure-devops-2019&viewFallbackFrom=azure-devops)** bude na konci každého sprintu, tj. při každém odevzdání, reflektovat reálný stav projektu.
* Vaše vlastní rozšíření projektu zdokumentované v `README.md`.

# Odevzdávání
Odevzdávání projektu má **3 fáze**. V každé fázi se hodnotí jiné vlastnosti projektu. Nicméně, fáze na sebe navazují a v následující fázi pokračujete v práci na svém kódu.

**Kontroluje se kód, který je nahrán v GIT** ve větvi `master` nebo `main`. Vždy se kontroluje **poslední commit před časem odevzdávání** dané fáze projektu. Na commity nahrány po času odevzdávání nebo v jiných větvích nebude brán zřetel. Commit, který máme hodnotit otagujte (`review1, review2, review3`), čímž nám usnadníte orientaci při hodnocení.

> :warning: **Je povoleno použít libovolnou knihovnu získanou standardním způsobem z NuGet zdroje.**

> :warning: **Je povoleno převzít kód z libovolného zdroje vyjma kódu projektů ostatních týmů.** Převzatý kód vyznačte komentářem a uveďte zdroj, a to včetně zdrojů jako je ChatGPT, Copilot, či jiné LLM. **Kódu musíte rozumět a být schopni při obhajobě objasnit jeho funkci.**

> :warning: **Zkontrolujte, že převzatý kód i knihovny neporušují licence k nimž spřažené.**

Je silně doporučováno projekty v průběhu semestru konzultovat (ideálně po cvičení, nebo si dohodnout termín konzultace emailem), předejdete tak případným komplikacím při odevzdání.

Pokud se **týmově** rozhodnete, že všichni členové nepřispěli rovnoměrně k vypracování projektu. Přidejte do kořene repositáře textový soubor s názvem **ROZDELENI.txt**, ve kterém uveďte loginy všech členů týmu a poměrné rozdělení bodů v procentech (struktura není pevně daná). V případě, že soubor nepřiložíte nebo nebude srozumitelný tak implicitně uvažujeme rovnoměrné rozdělení bodů. Pro rovnoměrné rozložení bodů je tedy zbytečné soubor přikládat. **Tento soubor se bere v potaz až při finální obhajobě projektu, kdy je třeba na jeho existenci upozornit a okomentovat ono bodové rozdělení.**
 
---
### Fáze 1 – objektový návrh, databáze 
V téhle fázi se zaměříme na *datový návrh*. Vyžaduje se po Vás, aby datový návrh splňoval zadání a nevynechal žádnou podstatnou část. Zamyslete se nad vazbami mezi jednotlivými entitami v datovém modelu. V této fázi budeme chtít, abyste **odevzdali kód**, kde budete mít *entitní třídy*, které budou obsahovat všechny vlastnosti, které budete dále potřebovat a vazby mezi třídami. 

Abyste si vazby dokázali představit, vytvořte již v tuto chvíli DAL projekt obsahující `DbContext` s `DbSet`y Vašich entitních tříd. Přiložte **ER diagram** vygenerovaný z kódu např. doplňkem [EF Core Power Tools](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools), nebo generovaným v [Rider/Datagrip](https://www.jetbrains.com/help/rider/Creating_diagrams.html). 

> :warning: Ručně vytvořený ER diagram, který neodpovídá Vašemu kódu je neakceptovatelný.

Pro zajištění vzájemného pochopení všemi členy týmu je vyžadované vytvoření **wireframe** na všechny pohledy (opět libovolný nástroj či ručně kreslené), které ve vaší výsledné aplikaci chcete implementovat. Tyto wireframy nebudou závazné, ale umožní Vám ihned na začátku vzájemně komunikovat představy o výsledné podobě aplikace. TIP: Při tvorbě wireframe zjistíte, jaká data budete potřebovat a navrhnete korektně nejen vazby v Entitní vrstvě, ale také Modely BL vrstvy, jejichž rozmyšlení jistě oceníte v druhém odevzdání.

ER diagram a wireframy umístěte do kořene repositáře do adresáře **docs**. Formát souborů zvolte tak, aby se daly otevřít rozumným způsobem bez nutnosti instalace specifických nástrojů přímo v prostředí Azure DevOps (**ověřte**). Ideální je obrázek ve formátu png, jpeg, svg, pdf, ...

Hodnotíme:
-   logický návrh tříd (viz 2. přednáška (L02) a 2. demonstrační cvičení (E02))
-   využití abstrakce, zapouzdření, polymorfismu – kde to bude dávat smysl a eliminuje duplicity (viz 2. přednáška (L02) a 2. demonstrační cvičení (E02))
-   verzování v GITu po logických částech, nejsou commitnuty binární soubory, v ideálním případě používáte "nějakou" ["GIT Branching strategy"](https://medium.com/@sreekanth.thummala/choosing-the-right-git-branching-strategy-a-comparative-analysis-f5e635443423)
-   logické rozšíření datového návrhu nad rámec zadání (bonusové body) – toto rozšíření ovšem zvažte; často se stává, že si tím založíte na spoustu komplikací v pozdějších fázích; body za rozšíření dostanete až u obhajoby, pokud je naimplementujete kompletně do výsledné aplikace
-   generovaný ER diagram (logickou strukturu) (L04/E03)
-   wireframy (logickou strukturu, uživatelskou přívětivost, ne kvalitu grafického zpracování)
-   využití **Entity Framework Core – Code First** přístupu na vytvoření databáze z entitních tříd (viz 4. přednáška (L04) a 3. demonstrační cvičení (E03))
-   existenci databázových migrací (alespoň InitialMigration) (viz 4. přednáška (L04) a 3. demonstrační cvičení (E03))
-   **základní** DAL testy (viz 2. demonstrační cvičení (E02))
-   možné rozšíření:
    -   CI v Azure DevOps – build, spuštění testů (viz 6. přednáška (L06)) (nenechejte na poslední chvíli, může být třeba žádost o zpřístupnění CI)

---
### Fáze 2 – repositáře a mapování
Vytvořte napojení modelů/DTO tříd pomocí Entity Frameworku na databázi. 

Vytvořte repositářovou (Repository) vrstvu, která zapouzdří databázové entity a Fasádu, která zpřístupní pouze data přemapovaná do modelů/DTO. **Inspirujte se ve cvičeních anebo vytvořte vlastní infrastrukturu**.

Protože nemáte zatím UI, **funkčnost aplikace ověřte automatizovanými testy**! Kde to dává logický smysl tvořte **UnitTesty**, pro propojení s databází vytvářejte **Integrační testy**. Doporučujeme použití testovacího frameworku **xUnit**.

Dbejte kvality Vašeho kódu! Opravte si kód odevzdaný v předchozí fázi dle doporučení v review a zásad *Clean Code / SOLID*, které dále důsledně dodržujte. Můžete si dopomoct rozšířeními a analyzátory kódu.

Hodnotíme:
- opravení chyb a zapracování připomínek, které jsme vám dali v rámci hodnocení fáze 1
- návrh a funkčnost repositářů
- návrh a funkčnost fasád (včetně filtrování, řazení, vyhledávání)
- čistotu kódu
- pokrytí aplikace testy – ukážete tím, že abstrakce repositáře/facade opravdu funguje (hodnotí se testy BL vrstvy)
- *dejte pozor na zapouzdření databázových entit pod vrstvou fasád, která je nepropaguje výše, ale přemapovává na modely/DTO*
- funkční build v Azure DevOps (nenechejte na poslední chvíli, může být třeba žádost o zpřístupnění CI)
- výsledek testů v Azure DevOps po buildu

---
### Fáze 3 – MAUI frontend, data binding
V této fázi se od Vás již požaduje vytvoření MAUI aplikace. 

Napište backend aplikace (ViewModely), který napojíte na Vámi navržené datové modely z 2. fáze, které jsou zapouzdřeny za vrstvou fasád. 

A dále frontend (View), který bude zobrazovat data předpřipravená ve ViewModelech. Zamyslete se nad tím, jakým způsobem je vhodné jednotlivá data zobrazovat.

> :warning: **Použití aplikace by mělo být intuitivní.**

Využijte *binding* v XAML kódu (vyvarujte se code-behind). Účelem není jenom udělat aplikaci, která funguje, ale také aplikaci, která je správně navržena a může být dále jednoduše upravitelná a rozšířitelná. Dbejte tedy zásad probíraných ve cvičeních.

Za aplikace, jejichž vizuální návrh bude proveden dobře, a zároveň budou plně funkční, budeme udělovat bonusové body.

Hodnotíme:
- opravení chyb a zapracování připomínek, které jsme vám dali v rámci hodnocení fází 1 a 2
- funkčnost celé výsledné aplikace
- vytvoření View, ViewModelů
- zobrazení jednotlivých informací dle zadání – seznam, detail …
- správné využití data-bindingu v XAML
- čistotu kódu
- validaci vstupů
- funkčnost testů
- vyhledávání, filtrování, řazení (musí být v DB, v UI pouze, kde to dává smysl)
- veškeré CRUD operace

Doporučujeme (bonusové body):
- pokrytí ViewModelů testy
- vytvoření dobře vypadající a plně funkční aplikace
- plánování projektu (logická struktura rozložení práce)

---
## Obhajoba

Termíny obhajob budou vyhlášeny v průběhu semestru.

Na obhajobu se dostaví **celý tým**. Z členů týmu bude vybrán jeden, který obhajobu povede. Na obhajobu nevytvářejte žádnou prezentaci! Budete nám muset ukázat, jak funguje váš kód, a že je správně navržen. Připravte se na naše otázky k funkcionalitě jednotlivých tříd a k důvodům jejich členění. Na obhajobu bude mít tým 10-15 minut. **Prezentujete z vlastního zařízení s připojením k projektoru pomocí HDMI nebo USB-C**.
