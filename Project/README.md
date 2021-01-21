# ICS projekt

## Důležité upozornění
Pro hodnocení projektu (a úspěšné absolvování předmětu) je nutno dokončit **všechny 3 fáze projektu** a projekt **obhájit**. Pokud projekt nebude při obhajobě obsahovat základní funkcionalitu uvedenou v zadání, bude hodnocen 0 body. **Nespokojíme se tedy s nedokončeným projektem**. Tuhle poznámku sem dáváme proto, že se v předchozích  ročnících vyskytly týmy, které po dosáhnutí součtu 50 bodů za předmět po 2. fázi rozhodly nedokončit projekt a poté byly nemile překvapeni, když se po nich vyžadovala plná funkcionalita při obhajobě. Dejte si na to tedy prosím pozor.

# Cíl
Cílem je vytvořit použitelnou a snadno rozšiřitelnou aplikaci, která splňuje požadavky zadání. Aplikace nemá padat nebo zamrzávat, pokud uživatel vyplní něco špatně, upozorní ho validační hláškou.

Zadání úmyslně není striktní, je Vám ponechána volnost, pro vlastní realizaci. Při hodnocení je kladen důraz na technické zpracování a kvalitu kódu, ale hodnotíme i použitelnost a grafické zpracování aplikace. Pokud Vám přijde, že v zadání chybí nějaká funkcionalita, neváhejte ji doplnit. Pište aplikaci tak, aby jste ji sami chtěli používat.

# Zadání - Aplikace pro správu festivalu
Výsledná aplikace má sloužit pro správu festivalu. Pro zjednodušení si můžete představit, že vytváříte jednodušší desktopovou verzi aplikace k festivalu jako Colors of Ostrava (nebo si dosaďte váš oblíbený).

---
## Data
V rámci dat, se kterými se bude pracovat budeme požadovat minimálně následující data.

### Hudební skupina
- Originální název
- Název česky
- Žánr
- Fotografie
- Země původu
- Dlouhý textový popis skupiny
- Krátký popis do programu
- Seznam vystoupení na festivalu

### Stage
- Název
- Textový popis dle kterého jej návštěvníci najdou
- Fotografie
- Seznam skupin, které na něm hrají

### Program festivalu
- Časové sloty pro jednotlivá vystoupení na jednotlivých stagích

---
## Funkcionalita
Aplikace bude obsahovat několik pohledů pro zobrazování a zadávání dat. 

Je požadováno **perzistentní** uložení dat. To znamená, že když se aplikace restartuje, tak nesmí o data přijít. Je nutno data ukládat za běhu aplikace, aby bylo možno demonstrovat, že když se například pomocí aplikace přidá nová skupina, tak se zobrazí v seznamu skupin (a podobně pro ostatní data).

Pro uložení zvolte (SQL databázi), kterou zpřístupníte pomocí Entity Framework Core.

Minimální rozsah, který je požadován v rámci projektu je popsán v této kapitole.

### Seznam skupin
Seznam bude obsahovat všechny skupiny dostupné v aplikaci. Bude možno se z něj překliknout na detail skupiny a na pohled pro přidání nové skupiny.

### Detail skupiny
Pohled zobrazuje detail jednotlivé skupiny se všemi informacemi o skupině (viz kapitolu Data).

### Editace skupiny
Pohled, který slouží na editaci skupiny. Může se využít na vytvoření nové skupiny nebo na editaci existující. Bude obsahovat všechny informace o skupině (viz kapitola Data).

### Seznam stagí
Pohled obsahuje všechny stage. Bude možno se z něj překliknout na detail stage a na pohled pro přidání nové stage.

### Detail stage
Detail stage - stránka zobrazuje všechny informace o konkrétní stage včetně seznamu skupinu, které na ni hrají (viz kapitola Data).

### Editace stage
Pohled, který slouží na editaci stage. Může se využít na vytvoření nové stage nebo na editaci existující. Bude obsahovat všechny informace o stage (viz kapitola Data).

### Program festivalu
Pohled na program festivalu s jednotlivými časovými sloty pro jednotlivé stage. Bude na něm vidět všechny vystoupení všech skupin v průběhu festivalu. Jedna skupina může na festivalu vystupovat i vícekrát. Časové sloty můžou být různě dlouhé a můžou být mezi nimi přestávky.

### Editace programu
Bude možné editovat jednotlivé časové sloty pro jednotlivé stage a přiřazovat skupiny do časových slotů.

---
## Architektura projektu
Na přednáškách a cvičeních Vám ukazujeme nějakou strukturu organizace kódu do logických vrstev a projektů se zapojením návrhových vzorů. Pokoušíme se vysvětlit proč je vzorový projekt takhle organizovaný a proč jsou zvoleny jednotlivé rozhodnutí.

Budeme tedy i po Vás chtít logické rozvržení projektu. Můžete využít to, jak je organizovaný vzorový projekt probíraný na přednáškách a inspirovat se tímto uspořádáním (můžete ho mít stejné, za to Vám rozhodně body nestrhnem). Nebo můžete využít i vlastní uspořádání - v tom případě ale po Vás budeme chtít vysvěltit proč jste němu přistoupili a čím se jeho jednotlivé aspekty řídí.

V každém případě ale budeme chtít aby výsledné řešení obsahovalo víc projektů a vrstev. Snažíme se Vám na tomto projektu ukázat aj nějakou základní architekturu SW projektu, aby jste si z toho odnesli i něco víc než jen to, že budete znát syntax jazyka C#. Na tenhle aspket tedy rozhodně bude brán zřetel ve všech fázích hodnocení projektu.

---
## Správa projektu - Azure DevOps
Při řešení projektu týmy využívají Azure DevOps a využívají GIT na sdílení kódu. Do svého projektu přidělte přístup vyučujícím (způsob bude vysvětlen v rámci 1. cvičení); tj. do Vašeho týmového projektu si v části Members přidejte účet **uciteliw5@vutbr.cz**

Účet **uciteliw5@vutbr.cz** budou používat vyučující pro přístup k odevzdávaným souborům. Bez přidání tohoto účtu není možné přistoupit k vašemu projektu a tedy není možné jej ze strany vyučujících hodnotit.

Návod na přidání člena projektu můžete najít zde: *https://docs.microsoft.com/en-us/vsts/accounts/add-team-members-vs*

Z GITu *musí být viditelná postupná práce na projektu a spolupráce týmu*. Pokud uvidíme, že existuje malé množství nelogických a nepřeložitelných commitů tak nás bude zajímat, jak jste spolupracovali a může to vést na snížení bodového hodnocení. Organizaci pojmenujte **ics-2021-team<0000>** dle Vašeho čísla týmu a projekt **project** tak, že výsledné URL pro přístup pro tento imaginární tým by bylo https://dev.azure.com/ics-2021-team0000/project. Nezapomeňte nastavit **Work item process** template na **Scrum**.

---
### Doporučení - za bonusové body při závěrečné obhajobě

* Pro řízení projektu využijte metodologii **[Scrum](https://docs.microsoft.com/en-us/azure/devops/boards/work-items/guidance/scrum-process-workflow?view=azure-devops)**. 
* Plánujte sprinty na jednotlivé fáze odevzdání. Práci rozdělte minimálně na **Product Backlog Item (PBI), Tasks a Bugs**. Využijete záložky **Boards** pro vzájemnou synchronizaci a **[Burndown chart](https://docs.microsoft.com/en-us/azure/devops/report/sql-reports/sprint-burndown-scrum?view=azure-devops-2019&viewFallbackFrom=azure-devops)** bude na konci každého sprintu, tj. při každém odevzdání, reflektovat reálný stav projektu.
* Využijte možnost automatizovaných buildů spojených s otestováním Vámi provedených změn. Nastavte **Pipelines->Builds** tak, že při pushnutí do libovolné větve projektu se provede *build a spustí se veškeré přítomné testy*. Více informací na [Automate all things with Azure Pipelines - THR2101](https://www.youtube.com/watch?v=yr6PJxfACNc)

# Odevzdávání
Odevzdávání projektu má **3 fáze**. V každé fázi se hodnotí jiné vlastnosti projektu. Nicméně fáze na sebe navazují a studenti pokračují v práci na svém kódu i po jeho odevzdání v rámci následující fáze.

**Kontroluje se kód, který je nahrán v GIT** ve větvi `master`. Vždy se kontroluje **poslední commit před časem odevzdávání** dané fáze projektu. Na commity nahrány po času odevzdávání nebo v jiných větvích nebude brán zřetel. Pokud commit, který máme hodnotit otagujete, např. `v1, v2, v3`, usnadníte nám orietaci při hodnocení.

Je silně doporučováno projekty v průběhu semestru konzultovat (můžete po přednášce/cvičení nebo se ozvat přes Discord nebo email), předejdete tak případným komplikacím při odevzdání.
 
---
### Fáze 1 – objektový návrh 
V téhle fázi se zaměříme na *datový návrh*. Vyžaduje se po Vás, aby datový návrh splňoval zadání a nevynechal žádnou podstatnou část. Zamyslete se nad vazbami mezi jednotlivými entitami v datovém modelu. V následující fázi budete entity nahrávat do databáze, takže myslete na jejich propojení již nyní. V této fázi budeme chtít, abyste **odevzdali kód**, kde budete mít *entitní třídy*, které budou obsahovat všechny vlastnosti, které budete dále potřebovat a vazby mezi třídami. **Nestačí tedy odevzdat diagram tříd, nebo nějakou jinou reprezentaci.** Budeme požadovat kód v jazyce C\#.

Hodnotíme:
-   logický návrh tříd
-   využití abstrakce, zapouzdření, polymorfismu - kde to bude dávat smysl a eliminovat duplicity
-   verzování v GITu po logických částech
-   logické rozšíření datového návrhu nad rámec zadání
    (bonusové body)

---
### Fáze 2 – databáze, repozitáře a mapování

Vytvořte napojení datových tříd pomocí Entity Frameworku na databázi. 

Vytvořte tedy repozitářovou (Repository) vrstvu, která zapouzdří databázové entity a zpřístupní pouze data přemapovaná do modelů/DTO.

> Pokud chcete Vaši aplikaci rozšířit, můžete nechat repozitářovou vrstvu pracovat s entitami a postavit nad ní ještě fasádu (Facade), která bude využívat repositář a entity přemapovávat do modelů/DTO v podobě listového modelu (obsahuje pouze data, která se hodí pro zobrazení v seznamu) nebo detailu.

Protože nemáte zatím UI, funkčnost aplikace ověřte automatizovanými testy! Kde to dává logický smysl tvořte **UnitTesty**, pro propojení s databází vytvářejte **Integrační testy**. Pro všechny typy testů využijte libovolný framework, doporučujeme **xUnit**.

Dbejte také kvality Vašeho kódu. Od této fáze se hodnotí i tenhle atribut. Opravte si tedy předchozí kód dle zásad Clean Code a SOLID probíraných na přednášce/cvičení a důsledně je dodržujte. Můžete si dopomoct např. rozšířením **Code Metrices**.

Hodnotíme:
- opravení chyb a zapracování připomínek, které jsme vám dali v rámci hodnocení fáze 1
- využití **Entity Framework Core (EF) Code First** na vytvoření databáze z tříd navržených ve fázi 1
- existující databázové migrace (alespoň InitialMigration)
- návrh a funkčnost repozitářů
- čistotu kódu
- pokrytí aplikace testy - ukážete tím, že repozitáře opravdu fungují
- dejte pozor na zapouzdření databázových entit pod vrstvou repozitáře (resp. fasády), který je nepropaguje výše, ale přemapovává na modely/DTO

---
### Fáze 3 – WPF frontend, data binding
V této fázi se od Vás již požaduje vytvoření WPF aplikace. Napište backend aplikace (vytvoření ViewModelů), která bude napojena na Vámi navržené datové modely z 2. fáze, které jsou zapouzdřeny v repozitáři (resp. fasádě). A dále frontend (View), která bude zobrazovat data předpřipravená ve ViewModelech. Zamyslete se nad tím, jakým způsobem je vhodné jednotlivá data zobrazovat.

Využijte *binding* v XAML kódu (vyvarujte se code-behind). Účelem není jenom udělat aplikaci, která funguje, ale také aplikaci, která je správně navržena a může být dále jednoduše upravitelná a rozšířitelná. Dbejte tedy zásad probíraných na přednáškách a ve cvičeních.

Za aplikace, jejichž vizuální návrh bude proveden dobře, a zároveň budou plně funkční, budeme udělovat také bonusové body.

Hodnotíme:
- opravení chyb a zapracování připomínek, které jsme vám dali v rámci hodnocení fází 1 a 2
- funkčnost celé výsledné aplikace
- vytvoření View, View-Modely
- zobrazení jednotlivých informací dle zadání – seznam, detail…
- správné využití data-bindingu v XAML
- čistotu kódu

Doporučujeme (bonusové body):
- pokrytí ViewModelů testy
- vytvoření dobře vypadající a plně funkční aplikace
- plánování projektu (logická struktura rozložení práce)
- nastavení automatizovaného buildu (kód je přeložitelný, spouští se automatizované testy, pipeline nekončí chybou)

---
## Obhajoba

Termíny obhajob budou vyhlášeny v průběhu semestru.

Na obhajobu se dostaví **celý tým**. Z členů týmu bude cvičícími vybrán 1 student, který obhajobu povede. Na obhajobu **není nutné** mít prezentaci (Powerpoint nebo pdf). Budete nám muset ukázat, jak funguje váš kód, že je správně navržen. Připravte se na naše otázky k funkcionalitě jednotlivých tříd a k důvodům jejich členění. Na obhajobu bude mít tým 10-15 minut.
