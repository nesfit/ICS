# ICS projekt

## Důležité upozornění
Pro hodnocení projektu 49+ body je nutné dokončit všechny fáze a projekt úspěšně obhájit. Každá fáze projektu musí být hodnocena minimálně 1b. Při obhajobě projektu je vyžadována demonstrace **základní funkcionality**, jinak je obhajoba hodnocena 0b.

## Cíl
Cílem je vytvořit použitelnou a snadno rozšiřitelnou aplikaci, která splňuje požadavky zadání. Aplikace nesmí padat nebo zamrzávat. Pokud uživatel vyplní něco špatně, je upozorněn validační hláškou.

Zadání ponechává volnost, pro vlastní realizaci. Při hodnocení je kladen důraz na technické zpracování a kvalitu kódu, nicméně se hodnotí i použitelnost a grafické zpracování. 

Pokud Vám přijde, že v zadání chybí nějaká funkcionalita, neváhejte ji doplnit. 
Cílem je vytvořit intuitivní aplikaci, kterou bude radost používat.

# Téma projektu - Spolujízda
Tématem letošního projektu bude vytvoření aplikace umožňující jejím uživatelů realizovat spolujízdy. 

---
## Data
V rámci dat, se kterými se bude pracovat budeme požadovat minimálně následující data.

### Uživatel
- Jméno
- Příjmení
- Fotografie
- (Vlastněná auta)
- (Spolujízdy z pohledu řidiče)
- (Spolujízdy z pohledu spolujezdce)

### Jízda
- Start (místo, poloha)
- Cíl (místo, poloha)
- Čas začátku
- Předpokládaný čas konce, nebo předpokládaná doba cesty
- (Řidič)
- (Spolujezdci)
- (Automobil)
  
### Auto
- Výrobce
- Typ
- Datum první registrace
- Fotografie
- Počet míst k sezení
- (Majitel, tj. uživatel)

---
## Základní funkcionalita
Aplikace bude obsahovat několik pohledů pro zobrazování přehledu, zobrazení detailu a vložení dat. 

Je požadováno **perzistentní** uložení. To znamená, že když se aplikace restartuje, tak nesmí přijít o data. Uložení dat musí být provedeno neprodleně po zadání operace uživatelem. 

Při demonstraci bude vyžadováno souběžné spuštění několika aplikací a změny v jedné aplikaci se musí projevit v ostatních instancích. Znovu-načtení dat může být inicializováno uživatelem. 

Pro uložení zvolte [SQL Server Express LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb), která je nainstalována jako součást Visual Studio - Data storage and processing workloadu. Jako ORM framework použijte [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/).

*Minimální* funkcionalita:
  - **Aplikace musí umožnit provést CRUD operace nad všemi daty.**
  - **Aplikace se ovládá z pohledu vybraného uživatele při spuštění aplikace.**
  - Uživatel může vytvořit jiné uživatele.
  - Uživatel může upravit informace o sobě.
  - Uživatel může přidat spolujízdu (bude u ní uveden jako řidič).
  - Řidič může odebrat spolujezdce a zrušit spolujízdu.
  - Uživatel může přidat svá auta a upravovat informace o nich.
  - Uživatel vidí seznam spolujízd a může se přihlásit do neobsazené spolujízdy.
  - Uživatel může **filtrovat** spolujízdy podle času, začátku a konce.

> :warning: **Dobře se zamyslete jak budete implementovat jízdy!**: Uvědomte si, že uživatelé nemohou současně jet ve více spolujízdách. Při vytváření/editaci je nutné ověřit, že nově přidaný záznam je nekolizní.

> :warning: **Důrazně doporučujeme vyhnout se autentizaci/autorizaci** Bude postačovat, když při spuštění aplikace nabídnete možnost zvolit si identitu ze seznamu uživatelů.


---
## Architektura projektu
Architektura aplikace je jeden z důležitých stavebních kamenů při vývoji SW. V rámci cvičení se seznámíte s vrstvenou architekturou demonstrující logickou separaci tříd do projektů (alespoň App, BL, DAL), kterou vřele doporučujeme využít i ve Vašich projektech (klidně 1:1). 

V případě, kdy se rozhodnete použít jinou architekturu a rozdělení tříd do projektů musíte být schopni své rozhodnutí obhájit.

Řešení obsahující nevhodné rozdělení tříd do projektů, které si nedokážete obhájit bude penalizováno značnou bodovou ztrátou.

> :warning: **Solution obsahující jediný projekt není akceptovatelné!**

---
## Správa projektu - Azure DevOps
Při řešení projektu využijte Azure DevOps a GIT na sdílení kódu. Do svého projektu přidělte přístup vyučujícím (způsob bude vysvětlen v rámci 1. cvičení); tj. do Vašeho týmového projektu si v části Members přidejte účet **uciteliw5@vutbr.cz**.

Účet **uciteliw5@vutbr.cz** budou používat vyučující pro přístup k odevzdávaným souborům. Bez přidání tohoto účtu není možné přistoupit k vašemu projektu, a tedy není možné jej ze strany vyučujících hodnotit.

Účet **uciteliw5@vutbr.cz** přidejte jako poslední a ověřte, že má nastavena oprávnění na **Stakeholder**. V opačném případě jeden ze členů týmu nebude vidět zdrojový kód. Azure DevOps umožňuje v bezplatné verzi pouze 5 aktivních vývojářů.

> :warning: **Je bezpodmínečně nutné** nastavit účtu **uciteliw5@vutbr.cz** **access level** na **Visual Studio Subsriber** vždy po deadline odevzdání jednotlivých fází a den před obhajobou projektu. Tato změna současně vyžaduje, aby jednomu členu týmu byl na tuto nezbytnou dobu odebrán přístup ke kódu. Tento **access level** nám ponechte do doby, než dostanete hodnocení dané fáze.

Bez této změny bychom neměli přístup k vašemu kódu a nemohli bychom jej hodnotit. Tato změna se provede v nastavení organizace https://dev.azure.com/ics-2022-team0000/_settings/users.

Návod na přidání člena projektu můžete najít zde: *https://docs.microsoft.com/en-us/vsts/accounts/add-team-members-vs*

Z GITu *musí být viditelná postupná práce na projektu a spolupráce týmu*. Pokud uvidíme, že existuje malé množství nelogických a nepřeložitelných commitů tak nás bude zajímat, jak jste spolupracovali a může to vést na snížení bodového hodnocení. 

Výrazně doporučujeme používat mechanismu **pull-request**ů a dělat si vzájemně review kódu, který následně mergnete do master nebo main větve. Projekt vypracováváte jako tým a nesete tak **kolektivní odpovědnost** za kvalitu kódu, proto je dobré, aby kód před začleněním vidělo více párů očí a vzájemně jste si jej připomínkovali. 

Organizaci pojmenujte **ics-2022-team<0000>** dle Vašeho čísla týmu a projekt **project** tak, že výsledné URL pro přístup pro tento imaginární tým by bylo https://dev.azure.com/ics-2022-team0000/project. Nezapomeňte nastavit **Work item process** template na **Scrum** nebo **Basic**.

Využijte možnost automatizovaných buildů spojených s otestováním Vámi provedených změn. Nastavte **Pipelines->Builds** tak, že při pushnutí do libovolné větve projektu se provede *build a spustí se veškeré přítomné testy*. Více informací na [Automate all things with Azure Pipelines - THR2101](https://www.youtube.com/watch?v=yr6PJxfACNc)

---
### Doporučení - za bonusové body při závěrečné obhajobě

* Pro řízení projektu využijte metodologii **[Scrum](https://docs.microsoft.com/en-us/azure/devops/boards/work-items/guidance/scrum-process-workflow?view=azure-devops)**. 
* Plánujte sprinty na jednotlivé fáze odevzdání. Práci rozdělte minimálně na **Product Backlog Item (PBI), Tasks a Bugs**. Využijete záložky **Boards** pro vzájemnou synchronizaci a **[Burndown chart](https://docs.microsoft.com/en-us/azure/devops/report/sql-reports/sprint-burndown-scrum?view=azure-devops-2019&viewFallbackFrom=azure-devops)** bude na konci každého sprintu, tj. při každém odevzdání, reflektovat reálný stav projektu.
* Vaše vlastní rozšíření projektu zdokumentované v `README.md`

# Odevzdávání
Odevzdávání projektu má **3 fáze**. V každé fázi se hodnotí jiné vlastnosti projektu. Nicméně, fáze na sebe navazují a v následující fázi pokračujete v práci na svém kódu.

**Kontroluje se kód, který je nahrán v GIT** ve větvi `master` nebo `main`. Vždy se kontroluje **poslední commit před časem odevzdávání** dané fáze projektu. Na commity nahrány po času odevzdávání nebo v jiných větvích nebude brán zřetel. Commit, který máme hodnotit otagujte (`review1, review2, review3`), čímž nám usnadníte orietaci při hodnocení.

> :warning: **Je povoleno převzít kód z libovolného zdroje vyjma kódu projektů ostatních týmů**. Převzatý kód vyznačte komentářem a uveďte zdroj. Kódu musíte rozumět a být schopni při obhajobě objasnit jeho funkci.

Je silně doporučováno projekty v průběhu semestru konzultovat (můžete po cvičení nebo se ozvat přes Discord či email), předejdete tak případným komplikacím při odevzdání.

Pokud se **týmově** rozhodnete, že všichni členové nepřispěli rovnoměrně k vypracování projektu. Přidejte do kořene repozitáře textový soubor s názvem **ROZDELENI.txt**, ve kterém uveďte loginy všech členů týmu a poměrné rozdělení bodů v procentech (struktura není pevně daná). V případě, že soubor nepřiložíte nebo nebude srozumitelný tak implicitně uvažujeme rovnoměrné rozdělení bodů. Pro rovnoměrné rozložení bodů je tedy zbytečné soubor přikládat.
 
---
### Fáze 1 – objektový návrh 
V téhle fázi se zaměříme na *datový návrh*. Vyžaduje se po Vás, aby datový návrh splňoval zadání a nevynechal žádnou podstatnou část. Zamyslete se nad vazbami mezi jednotlivými entitami v datovém modelu. V následující fázi budete entity nahrávat do databáze, takže myslete na jejich propojení již nyní. V této fázi budeme chtít, abyste **odevzdali kód**, kde budete mít *entitní třídy*, které budou obsahovat všechny vlastnosti, které budete dále potřebovat a vazby mezi třídami.

Abyste si vazby dokázaly představit, přiložte **ER diagram** tříd vytvořený v libovolném nástroji (i rukou) nebo vygenerovaný z kódu. Pro zajištění vzájemného pochopení všemi členy týmu budeme nově také požadovat vytvoření **wirefame** na všechny pohledy (opět libovolný nástroj či ručně kreslené), které ve vaší výsledné aplikaci chcete implementovat. Tyto wireframy nebudou závazné, ale umožní Vám ihned na začátku vzájemně komunikovat představy o výsledné podobě aplikace. TIP: Při tvorbě wireframe zjistíte, jaká data budete potřebovat a navrhnete korektně nejen vazby v Entitní vrstvě, ale také Modely BL vrstvy, jejichž rozmyšlení jistě oceníte v druhém odevzdání.

ER diagram a wireframy umístěte do kořene repozitáře do adresáře **docs**. Formát souborů zvolte tak, aby se daly otevřít rozumným způsobem bez nutnosti instalace specifických nástrojů. Ideální je obrázek ve formátu png, jpeg, svg atd... případně PDF.

Hodnotíme:
-   logický návrh tříd
-   využití abstrakce, zapouzdření, polymorfismu - kde to bude dávat smysl a eliminuje duplicity
-   verzování v GITu po logických částech
-   logické rozšíření datového návrhu nad rámec zadání (bonusové body) - toto rozšíření ovšem zvažte; často se stává, že si tím založíte na spoustu komplikací v pozdějších fázích
-   ER diagram (strukturu, ne formální zápis)
-   Wireframy (logickou strukturu, uživatelskou přívětivost, ne kvalitu grafického zpracování)

---
### Fáze 2 – databáze, repozitáře a mapování
Vytvořte napojení datových tříd pomocí Entity Frameworku na databázi. 

Vytvořte tedy repozitářovou (Repository) vrstvu, která zapouzdří databázové entity a Fasádu, která zpřístupní pouze data přemapovaná do modelů/DTO. **Inspirujte se ve cvičeních anebo vytvořte vlastní infrastrukturu**.

Protože nemáte zatím UI, funkčnost aplikace ověřte automatizovanými testy! Kde to dává logický smysl tvořte **UnitTesty**, pro propojení s databází vytvářejte **Integrační testy**. Pro všechny typy testů využijte libovolný framework, doporučujeme **xUnit**.

Dbejte kvality Vašeho kódu! Opravte si kód odevzdaný v předchozí fázi dle doporučení v review a zásad Clean Code / SOLID, které dále důsledně dodržujte. Můžete si dopomoct např. rozšířením **Code Metrices** a analyzátory kódu.

Hodnotíme:
- opravení chyb a zapracování připomínek, které jsme vám dali v rámci hodnocení fáze 1
- využití **Entity Framework Core - Code First** přístupu na vytvoření databáze z tříd navržených ve fázi 1
- existující databázové migrace (alespoň InitialMigration)
- návrh a funkčnost repozitářů
- návrh a funkčnost fasád
- čistotu kódu
- pokrytí aplikace testy - ukážete tím, že repozitáře opravdu fungují
- dejte pozor na zapouzdření databázových entit pod vrstvou fasád, která je nepropaguje výše, ale přemapovává na modely/DTO
- funkční build v Azure DevOps
- výsledek testů v Azure DevOps po buildu

---
### Fáze 3 – WPF frontend, data binding
V této fázi se od Vás již požaduje vytvoření WPF aplikace. 

Napište backend aplikace (ViewModely), který napojíte na Vámi navržené datové modely z 2. fáze, které jsou zapouzdřeny za vrstvou fasád. 

A dále frontend (View), který bude zobrazovat data předpřipravená ve ViewModelech. Zamyslete se nad tím, jakým způsobem je vhodné jednotlivá data zobrazovat.

> :warning: **Použití aplikace by mělo být intuitivní.**

Využijte *binding* v XAML kódu (vyvarujte se code-behind). Účelem není jenom udělat aplikaci, která funguje, ale také aplikaci, která je správně navržena a může být dále jednoduše upravitelná a rozšířitelná. Dbejte tedy zásad probíraných ve cvičeních.

Za aplikace, jejichž vizuální návrh bude proveden dobře, a zároveň budou plně funkční, budeme udělovat bonusové body.

Hodnotíme:
- opravení chyb a zapracování připomínek, které jsme vám dali v rámci hodnocení fází 1 a 2
- funkčnost celé výsledné aplikace
- vytvoření View, ViewModelů
- zobrazení jednotlivých informací dle zadání – seznam, detail…
- správné využití data-bindingu v XAML
- čistotu kódu

Doporučujeme (bonusové body):
- pokrytí ViewModelů testy
- vytvoření dobře vypadající a plně funkční aplikace
- plánování projektu (logická struktura rozložení práce)

---
## Obhajoba

Termíny obhajob budou vyhlášeny v průběhu semestru.

Na obhajobu se dostaví **celý tým**. Z členů týmu bude cvičícími vybrán jeden, který obhajobu povede. Na obhajobu nevytvářejte žádnou prezentaci! Budete nám muset ukázat, jak funguje váš kód, a že je správně navržen. Připravte se na naše otázky k funkcionalitě jednotlivých tříd a k důvodům jejich členění. Na obhajobu bude mít tým 10-15 minut.
