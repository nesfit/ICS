> :warning: **Varování**  
> Zadání je prozatím DRAFT, finální podoba bude zveřejněna po druhém týdnu semestru.

# ICS projekt

## Tl;dr
- Téma: launcher her (Steam/Epic styl) se seznamem titulů a knihovnami uživatelů.
- Povinné entity: Herní titul, Knihovna, Uživatel.
- Povinné operace: CRUD nad všemi entitami.
- Filtrace, vyhledávání, řazení musí probíhat v databázi.
- Perzistence: SQLite + Entity Framework Core (Code First).
- Architektura: více projektů (např. App, BL, DAL). Jediný projekt je neakceptovatelný.
- Bez autentizace/autorizace. Uživatel se volí z UI, lze přepnout uživatele.
- Odevzdání má 3 fáze a hodnotí se poslední commit před deadlinem.
- Pro 49+ bodů musí být splněny všechny fáze a obhájena základní funkcionalita.

---

## Cíl
Cílem je vytvořit použitelnou a snadno rozšiřitelnou aplikaci, která splňuje požadavky zadání. Aplikace nesmí padat nebo zamrzávat. Pokud uživatel vyplní něco špatně, je upozorněn validační hláškou.

Zadání ponechává volnost pro vlastní realizaci. Při hodnocení je kladen důraz na technické zpracování a kvalitu kódu, hodnotí se ale i uživatelská přívětivost a grafické zpracování.

Pokud Vám přijde, že v zadání chybí nějaká funkcionalita, můžete ji doplnit a zdokumentovat v `README.md`.

---

## Téma projektu
Téma projektu bylo vybráno na základě zpětné vazby z dotazníku k předmětu: `"launcher" her (na způsob EA launcheru, Epic games, Steam atd.), kde si může uživatel procházet různé tituly, a případně si je přidat do knihovny ..`

Aplikace tedy uchovává informace o herních titulech. Uživatel si zobrazí, jaké hry na platformě existují, a může si je přidat do knihovny (oblíbené).

Možná rozšíření:
- uživatel může mít více knihoven
- statistické informace o herních titulech v knihovnách uživatelů
- bodové hodnocení titulů s komentáři a statistikami

---

## Data a entity
V rámci dat požadujeme minimálně následující položky. Zamyslete se, zda je třeba vše ukládat do databáze, nebo zda lze některá data dopočítat při dotazování.

### Herní titul
- Název
- Popis
- PEGI rating
- Herní studio (pokud dává smysl)
- Kategorie (pokud dává smysl)
- (Knihovny)

### Knihovna
- Název
- [Popis]
- Počet obsažených položek
- (Herní tituly)

### Uživatel
- [Jméno]
- [Příjmení]
- Username
- Email
- ...
- (Knihovna)

Poznámky:
- `()` označuje možné/doporučené vazby mezi entitami
- `[]` označuje volitelné položky

Další možné entity pro nepovinné rozšíření: herní studio, kategorie, ...

---

## Důležitá upozornění
- Pro hodnocení projektu 49+ body je nutné dokončit všechny fáze a projekt úspěšně obhájit. Každá fáze musí být hodnocena minimálně 1 bodem.
- Při obhajobě je vyžadována demonstrace základní funkcionality, jinak je obhajoba hodnocena 0 body.
- Důrazně nedoporučujeme implementovat autentizaci/autorizaci. Aplikace má na úvodní stránce zobrazit seznam uživatelů a umožnit „registraci“. Po zvolení uživatele aplikace pracuje v jeho kontextu. Během běhu lze uživatele přepnout.

---

## Základní funkcionalita
Aplikace bude obsahovat pohledy pro:
- přehled
- detail
- vložení dat

Minimální funkcionalita:
- Aplikace musí umožnit CRUD operace nad všemi daty.
- V aplikaci lze filtrovat dle všech položek, které dávají smysl v kontextu aplikace.
- V aplikaci lze vyhledávat dle všech položek, které dávají smysl v kontextu aplikace.
- V aplikaci lze řadit v listových pohledech dle všech položek, které dávají smysl v kontextu aplikace.
- Filtrace, vyhledávání, řazení probíhají v databázi. Aplikace nesmí stáhnout všechna data do paměti a provádět tyto operace nad objekty v paměti.

Perzistence:
- Je vyžadováno perzistentní uložení dat.
- Při demonstraci může být vyžadováno souběžné spuštění několika instancí aplikace a očekává se, že změny v jedné instanci se projeví v ostatních.
- Znovu-načtení dat může být iniciováno uživatelem.

Technologie:
- SQLite a Entity Framework Core (ORM).

---

## Architektura projektu
Architektura je důležitým stavebním kamenem. Doporučujeme vrstvenou architekturu (alespoň App, BL, DAL). Řešení obsahující jediný projekt není akceptovatelné.

Pokud se rozhodnete pro jinou architekturu (např. Clean Architecture), je vhodné to [předem konzultovat](pluskal@vut.cz) a být schopni své rozhodnutí obhájit.

---

## Odevzdávání
Odevzdávání má 3 fáze. V každé fázi se hodnotí jiné vlastnosti, ale fáze na sebe navazují.

Kontroluje se kód nahraný v GIT ve větvi `main` nebo `master`. Vždy se kontroluje poslední commit před časem odevzdávání. Commity nahrané po času odevzdávání nebo v jiných větvích nebudou brány v potaz.

Commit, který máme hodnotit, otagujte (`review1`, `review2`, `review3`).

Je povoleno:
- použít libovolnou knihovnu z NuGet
- převzít kód z libovolného zdroje vyjma projektů ostatních týmů (včetně ChatGPT, Copilot a jiných LLM), pokud je řádně označen a zdroj uveden

Poznámka:
- Převzatému kódu musíte rozumět a být schopni při obhajobě objasnit jeho funkci.
- Zkontrolujte, že převzatý kód i knihovny neporušují licence.

Týmová spolupráce:
- Z GITu musí být viditelná postupná práce na projektu a spolupráce týmu.
- Doporučujeme Conventional Commits a ["GIT Branching strategy"](https://medium.com/@sreekanth.thummala/choosing-the-right-git-branching-strategy-a-comparative-analysis-f5e635443423).

ROZDELENI.txt:
- Pokud členové týmu nepřispěli rovnoměrně, přidejte do kořene soubor `ROZDELENI.txt` s loginy a poměrným rozdělením bodů.
- Pokud soubor nepřiložíte, bere se rovnoměrné rozdělení bodů.

---

## Fáze 1 – objektový návrh, databáze
V této fázi se zaměřte na datový návrh. Vyžaduje se, aby datový návrh splňoval zadání a nevynechal žádnou podstatnou část. Zamyslete se nad vazbami mezi entitami v datovém modelu. V této fázi odevzdáváte kód s entitními třídami, které obsahují všechny vlastnosti potřebné pro další fáze, včetně vazeb mezi třídami.

Abyste si vazby dokázali představit, vytvořte DAL projekt obsahující `DbContext` s `DbSet`y entitních tříd. Přiložte ER diagram vygenerovaný z kódu. Ručně vytvořený ER diagram, který neodpovídá kódu, je neakceptovatelný.

Pro zajištění pochopení v týmu vytvořte wireframy všech pohledů. Wireframy nejsou závazné, ale pomohou sladit představy o výsledné aplikaci a včas odhalit potřebná data.

Požadavky:
- Entitní třídy s vlastnostmi a vazbami.
- DAL projekt s `DbContext` a `DbSet`y.
- ER diagram vygenerovaný z kódu (např. [EF Core Power Tools](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools) nebo [Rider/Datagrip](https://www.jetbrains.com/help/rider/Creating_diagrams.html)).
- Wireframy všech pohledů.
- Použití EF Core Code First.
- Existující databázové migrace (alespoň InitialMigration).
- Základní DAL testy.

Umístění výstupů:
- ER diagram a wireframy do `./docs`.
- Formát souborů musí jít otevřít bez speciálních nástrojů (png, jpeg, svg, pdf...).

> :warning: **Důležité**  
> V sekci [Správa projektu – Azure DevOps](#správa-projektu--azure-devops) jsou zásadní informace k nastavení přístupů.

Hodnotíme:
- logický návrh tříd (viz 2. přednáška L02 a 2. demonstrační cvičení E02)
- využití abstrakce, zapouzdření, polymorfismu – kde to bude dávat smysl a eliminuje duplicity (viz 2. přednáška L02 a 2. demonstrační cvičení E02)
- verzování v GITu po logických částech, nejsou commitnuty binární soubory, v ideálním případě používáte „nějakou“ branching strategy
- logické rozšíření datového návrhu nad rámec zadání (bonusové body) – rozšíření dostane body až u obhajoby, pokud je kompletně implementováno
- v `./docs` existuje generovaný ER diagram (logickou strukturu) (L04/E03)
- v `./docs` existují wireframy (logickou strukturu, uživatelskou přívětivost, ne kvalitu grafického zpracování)
- využití Entity Framework Core – Code First přístupu na vytvoření databáze z entitních tříd (viz 4. přednáška L04 a 3. demonstrační cvičení E03)
- existenci databázových migrací (alespoň InitialMigration) (viz 4. přednáška L04 a 3. demonstrační cvičení E03)
- základní DAL testy (viz 2. demonstrační cvičení E02)
- možné rozšíření: CI v Azure DevOps – build, spuštění testů (viz 6. přednáška L06)

---

## Fáze 2 – repositáře a mapování
V této fázi vytvořte napojení modelů/DTO tříd na databázi pomocí Entity Frameworku. Vytvořte repository vrstvu, která zapouzdří databázové entity, a fasádu, která zpřístupní data přemapovaná do modelů/DTO. Inspirujte se ve cvičeních, nebo vytvořte vlastní infrastrukturu.

Protože ještě nemáte UI, ověřte funkčnost aplikace automatizovanými testy. Kde to dává smysl, pište unit testy; pro propojení s databází používejte integrační testy.

Požadavky:
- Napojení modelů/DTO tříd na DB přes Entity Framework.
- Repository vrstva zapouzdřující DB entity.
- Fasáda zpřístupňující pouze data přemapovaná do modelů/DTO.
- Filtrace, řazení, vyhledávání implementované přes DB.
- Automatizované testy (unit + integrační). Doporučen xUnit.
- Oprava chyb a připomínek z fáze 1.

Hodnotíme:
- opravení chyb a zapracování připomínek z hodnocení fáze 1
- návrh a funkčnost repositářů
- návrh a funkčnost fasád (včetně filtrování, řazení, vyhledávání)
- čistotu kódu
- pokrytí aplikace testy – ověřuje se funkčnost repositáře/facade (hodnotí se testy BL vrstvy)
- zapouzdření databázových entit pod vrstvou fasád, které je nepropagují výše a přemapovávají na modely/DTO
- funkční build v Azure DevOps (nenechávejte na poslední chvíli, může být třeba žádost o zpřístupnění CI)
- výsledek testů v Azure DevOps po buildu

---

## Fáze 3 – MAUI frontend, data binding
V této fázi již vytváříte MAUI aplikaci. Napište backend (ViewModely) napojený na datové modely z 2. fáze (přes fasády) a frontend (View), který zobrazí data připravená ve ViewModelech. Zamyslete se, jaká data a kde zobrazovat.

Požadavky:
- MAUI aplikace.
- Backend (ViewModely) napojený na datové modely z 2. fáze (přes fasády).
- Frontend (View) zobrazující data z ViewModelů.

Poznámka:
- Použití aplikace by mělo být intuitivní.

Hodnotíme:
- opravení chyb a zapracování připomínek, které jsme Vám dali v rámci hodnocení fází 1 a 2
- funkčnost celé výsledné aplikace
- vytvoření View a ViewModelů
- zobrazení jednotlivých informací dle zadání – seznam, detail, ...
- správné využití data-bindingu v XAML
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

## Správa projektu – Azure DevOps
Využijte Azure DevOps a GIT pro sdílení kódu. Přidejte do projektu vyučující účet **uciteliw5@vutbr.cz**.

> :warning: **Velmi důležité upozornění**  
> Účet **uciteliw5@vutbr.cz** musí být přidán jako poslední a mít oprávnění **Stakeholder**.  
> Zároveň je nutné tento účet přidat do **Project Collection Administrator** v nastavení organizace.  
> Bez splnění obou bodů není možné korektně hodnotit projekt.

Důležité:
- Účet přidejte jako poslední a ověřte, že má oprávnění **Stakeholder**.
- Je nutné přidat účet do **Project Collection Administrator** v nastavení organizace.
- Organizaci pojmenujte `ics-2026-xlogin00` a projekt `project` (příklad URL: `https://dev.azure.com/ics-2026-xlogin00/project`).
- Nastavte **Work item process** template na **Scrum** nebo **Basic**.

CI doporučení:
- Nastavte Pipelines->Builds tak, aby při pushnutí do libovolné větve proběhl build a testy.
> :warning: **Upozornění k CI**  
> Nenechte nastavení CI na poslední chvíli. Aktivace CI runnerů může vyžadovat vyplnění formuláře a může nějakou dobu trvat.

Návody a odkazy:
- Přidání člena projektu: `https://docs.microsoft.com/en-us/vsts/accounts/add-team-members-vs`
- Scrum workflow: `https://docs.microsoft.com/en-us/azure/devops/boards/work-items/guidance/scrum-process-workflow?view=azure-devops`
- Burndown chart: `https://docs.microsoft.com/en-us/azure/devops/report/sql-reports/sprint-burndown-scrum?view=azure-devops-2019&viewFallbackFrom=azure-devops-2019`
- Azure Pipelines video: `https://www.youtube.com/watch?v=yr6PJxfACNc`

---

## Konvence
- Angličtina je povinný jazyk pro pojmenování identifikátorů, tříd a komentářů.
- Dodržujte zásady Clean Code.
- Pro konzistenci použijte `.editorconfig` dle domluvy v týmu.

---

## Doporučení (bonusové body)
- Využijte Scrum v Azure DevOps.
- Plánujte sprinty na jednotlivé fáze odevzdání.
- Práci rozdělte na PBI, Tasks a Bugs.
- Využijte Boards a Burndown chart.
- Vaše rozšíření projektu dokumentujte v `README.md`.
