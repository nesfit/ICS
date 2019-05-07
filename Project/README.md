# ICS projekt

## Důležité upozornění

Pro hodnocení projektu (a úspěšné absolvování předmětu) je nutno dokončit **všechny 3 fáze projektu** a projekt **obhájit**. Pokud projekt nebude při obhajobě obsahovat základní funkcionalitu uvedenou v zadání, bude hodnocen 0 body. **Nespokojíme se tedy s nedokončeným projektem**. Tuhle poznámku sem dáváme proto, že se v předchozích  ročnících vyskytly týmy, které po dosáhnutí součtu 50 bodů za předmět po 2. fázi rozhodly nedokončit projekt a poté byly nemile překvapeni, když se po nich vyžadovala plná funkcionalita při obhajobě. Dejte si na to tedy prosím pozor.


## Cíl

Cílem je vytvořit použitelnou a snadno rozšiřitelnou aplikaci, která splňuje požadavky zadání. Aplikace nemá padat nebo zamrzávat, pokud uživatel vyplní něco špatně, upozorní ho validační hláškou.

---

Zadání úmyslně není striktní, je Vám ponechána volnost, pro vlastní realizaci. Při hodnocení je kladen důraz na technické zpracování a kvalitu kódu, ale hodnotíme i na použitelnost a grafické zpracování aplikace. Pokud Vám přijde, že v zadání chybí nějaká funkcionalita, neváhejte ji doplnit. Pište aplikaci tak, aby jste ji sami chtěli používat.

---

## Zadání - Aplikace pro týmovou komunikaci

Výsledná aplikace má sloužit studentům k usnadnění komunikace na týmových projektech. Uživatel (Student) může být součástí více týmů. Členové týmu komunikují pomocí příspěvků a odpovědí na ně. Pro lepší představu si představte zjednodušeně Microsoft Teams nebo Facebook skupinu. 

### Přihlášení
Uživatel se hlásí na základě emailu a hesla. **Hesla ukládejte v bezpečné podobě!**

### Seznam týmů
Po přihlášení vidí uživatel seznam svých týmů a může si je kdykoliv zobrazit. 

### Příspěvky týmu
Zde každý člen týmu vidí všechny příspěvky a odpovědi na ně; může přidávat příspěvek nebo komentář k jinému příspěvku. Ostatní uživatelé sem nemají přístup.

Příspěvky v týmu jsou zobrazeny i s komentáři a seřazeny dle data vytvoření posledního komentáře, ne data zveřejnění příspěvku. Komentáře se řadí chronologicky.

 - Příspěvek č. 1
    - odpověď č. 1 na příspěvek č. 1
    - odpověď č. N na příspěvek č. 1
 - Příspěvek č. 2
    - odpověď č. 1 na příspěvek č. 2
    - odpověď č. N na příspěvek č. 2

Zobrazený příspěvek obsahuje *zvýrazněný titulek, formátovaný text, autora a datum zveřejnění*. Můžete přidat i vlastní **rozšíření**, např. možnost odpovědět na příspěvek.

Odpověď na příspěvek obsahuje formátovaný text, autora a datum zveřejnění; opět je zde prostor pro **rozšíření**.

Při vytváření příspěvku nebo komentáře *uživatel nevyplňuje datum zveřejnění ani autora*, aplikace si je doplní sama. 

Pokud se aplikace neaktualizuje sama, obsahuje tlačítko pro *aktualizaci příspěvků*.

### Vyhledávání
Aplikace umožňuje vyhledávání v příspěvcích a komentářích.

### Přehled týmu
Zde uživatel vidí popis týmu a výpis jeho členů. Je zde možnost přidat do týmu další členy a nebo odstranit stávající. 

#### Přidání člena do týmu
Uživatel má na výběr ze všech uživatelů aplikace, kteří nejsou členy týmu. Má také možnost vytvořit nového uživatele. 

### Profil uživatele
Zde je vidět jméno uživatele, jeho poslední aktivita a jeho týmy.

## Management projektu - Azure DevOps

Projekt řeší studenti v týmech. V každém týmu je **4-5 studentů**. *Tým o méně studentech není přípustný.*

Při řešení projektu týmy využívají Azure DevOps a využívají GIT na sdílení kódu. Do svého projektu přidělte přístup vyučujícím (způsob bude vysvětlen v rámci 1. cvičení); tj. do Vašeho týmového projektu si v části Members přidejte účet **uciteliw5@vutbr.cz**

Účet **uciteliw5@vutbr.cz** budou používat vyučující pro přístup k odevzdávaným souborům. Bez přidání tohoto účtu není možné přistoupit k vašemu projektu a tedy není možné jej ze strany vyučujících hodnotit.

Návod na přidání člena projektu můžete najít zde: *https://docs.microsoft.com/en-us/vsts/accounts/add-team-members-vs*

Z GITu *musí být viditelná postupná práce na projektu a spolupráce týmu*. Pokud uvidíme, že existuje malé množství nelogických a nepřeložitelných commitů tak nás bude zajímat, jak jste spolupracovali a může to vést na snížení bodového hodnocení. Organizaci pojmenujte **ics-2019-team<0000>** dle Vašeho čísla týmu a projekt **project** tak, že výsledné URL pro přístup pro tento imaginární tým by bylo https://dev.azure.com/ics-2019-team0000/project. Nezapomeňte nastavit **Work item process** template na **Scrum**.

Pokud projekt vypracováváte pro oba předměty ICS/IW5, zvolte jméno organizace **ics-iw5-2019-team<0000>**, viz [#6](https://github.com/FitIW/5/issues/6).

### Řízení projektu

Pro řízení projektu využijte metodologii **[Scrum](https://docs.microsoft.com/en-us/azure/devops/boards/work-items/guidance/scrum-process-workflow?view=azure-devops)**. Budeme chtít vidět, že máte naplánované sprinty na jednotlivé fáze odevzdání. Práci rozdělte minimálně na **Product Backlog Item (PBI), Tasks a Bugs**. Očekáváme, že využijete záložky **Boards** pro vzájemnou synchronizaci a **[Burndown chart](https://docs.microsoft.com/en-us/azure/devops/report/sql-reports/sprint-burndown-scrum?view=azure-devops-2019&viewFallbackFrom=azure-devops)** bude na konci každého sprintu, tj. při každém odevzdání, reflektovat reálný stav projektu. Nebudete přeci nám jakožto Vašim **Stakeholderům** lhát!

### Automatizované testování
Využijte možnost automatizovaných buildů spojených s otestováním Vámi provedených změn. Nastavte **Pipelines->Builds** tak, že při pushnutí do libovolné větve projektu se provede *build a spustí se veškeré přítomné testy*. Více informací na [Automate all things with Azure Pipelines - THR2101](https://www.youtube.com/watch?v=yr6PJxfACNc) (note: vyžadujeme pouze fragment konfigurace, které najdete na tomto videu)

## Odevzdávání

Odevzdávání projektu má **3 fáze**. V každé fázi se hodnotí jiné vlastnosti projektu. Nicméně fáze na sebe navzájem následují a studenti pokračují v práci na svém kódu i po jeho odevzdání v rámci následující fáze.

**Kontroluje se kód, který je nahrán v GIT** ve větvi `master`. Vždy se kontroluje **poslední commit před časem odevzdávání** dané fáze projektu. Na commity nahrány po času odevzdávání nebo v jiných větvích nebude brán zřetel. Pokud commit, který máme hodnotit otagujete, např. `v1, v2, v3`, usnadníte nám orietaci při hodnocení.

Je silně doporučováno projekty v průběhu semestru konzultovat po přednášce/cvičení, předejdete tak případným komplikacím při odevzdání.

### Fáze 1 – objektový návrh (20 bodů) – odevzdání 10. 3. 2018 23:59:59

V téhle fázi se zaměříme na *datový návrh*. Vyžaduje se po Vás, aby datový návrh splňoval zadání a nevynechal žádnou podstatnou část. Zamyslete se nad vazbami mezi jednotlivými entitami v datovém modelu. V následující fázi budete entity nahrávat do databáze, takže myslete na jejich propojení již nyní. V této fázi budeme chtít, abyste **odevzdali kód**, kde budete mít *entitní třídy*, které budou obsahovat všechny vlastnosti, které budete dále potřebovat a vazby mezi třídami. **Nestačí tedy odevzdat diagram tříd, nebo nějakou jinou reprezentaci.** Budeme požadovat kód v jazyce C\#.

Hodnotíme:

-   logický návrh tříd

-   využití abstrakce, zapouzdření, polymorfismu

-   verzování v GITu po logických částech

-   logické rozšíření datového návrhu nad rámec zadání
    (bonusové body)
    
-   plánování projektu (nastavení sprintů, vytvoření alespoň 1 PBI a 1 task)

-   nastavení automatizovaného buildu (kód je přeložitelný, pipeline nekončí chybou)


### Fáze 2 – databáze, repozitáře a mapování (30 bodů) – 7. 4. 2018 23:59:59

Aplikace již nepracuje jen s daty uvedenými ve zdrojových souborech. Je napojena na databázi a pracuje s ní. Vytvořte napojení datových tříd pomocí Entity Frameworku na databázi. 

Vytvořte tedy repozitářovou (Repository) vrstvu, která zapouzdří databázové entity a zpřístupní pouze data přemapovaná do modelů/DTO. (Jedná se o špatné použití repository, čtěte dále!)

Pokud chcete Vaši aplikaci rozšířit, můžete nechat repozitářovou vrstvu pracovat s entitami a postavit nad ní ještě fasádu (Facade), která bude využívat repositář a entity přemapovávat do modelů/DTO v podobě listového model (obsahuje pouze data, která se hodí pro zobrazení v seznamu) nebo detailu.

Protože nemáte zatím UI, funkčnost aplikace ověřte automatizovanými testy! Kde to dává logický smysl tvořte **UnitTesty**, pro propojení s databází vytvářejte **Integrační testy**. Pro všechny typy testů využijte libovolný framework, doporučujeme **xUnit**.

Dbejte také kvality Vašeho kódu. Od této fáze se hodnotí i tenhle atribut. Opravte si tedy předchozí kód dle zásad Clean Code a S.O.L.I.D. probíraných na přednášce/cvičení a důsledně je dodržujte. Můžete si dopomoct např. rozšířením **Code Metrices**.

Hodnotíme:

-   využití **Entity Framework (EF) Code First** na vytvoření databáze
    z tříd navržených ve fázi 1

-   návrh WPF aplikace dle návrhového vzoru **Model View ViewModel (MVVM)**

-   čistotu kódu

-   pokrytí aplikace testy

-   plánování projektu (logická struktura rozložení práce)

-   nastavení automatizovaného buildu (kód je přeložitelný, spouští se automatizované testy, pipeline nekončí chybou)

-   zapouzdření databázových entit pod vrstvou repozitáře (fasády), který je nepropaguje výše, ale přemapovává na modely/DTO

<!-- -->

-   -   -   

### Fáze 3 – WPF frontend, data binding (50 bodů) – 24 hodin před obhajobou
V této fázi se od Vás již požaduje vytvoření WPF aplikace. Napište backend aplikace (vytvoření View-Modelů), která bude napojena na Vámi navržené datové modely z 2. fáze, které jsou zapouzdřeny v repozitáři/fasádě. A dále frontend (View), která bude zobrazovat data předpřipravená ve view-modelech. Zamyslete se nad tím, jakým způsobem je vhodné jednotlivá data zobrazovat.

Využijte *binding* v XAML kódu (vyvarujte se code-behind). Účelem není jenom udělat aplikaci, která funguje, ale také aplikaci, která je správně navržena a může být dále jednoduše upravitelná a rozšířitelná. Dbejte tedy zásad probíraných ve cvičeních.

Za aplikace, jejichž vizuální návrh bude proveden dobře, a zároveň budou plně funkční, budeme udělovat také bonusové body.

Hodnotíme:

-   funkčnost celé výsledné aplikace

-   vytvoření View k příslušným View-Modelům z fáze 2

-   zobrazení jednotlivých informací dle zadání – seznam, detail…

-   správné využití data-bindingu v XAML

-   čistotu kódu

-   pokrytí aplikace testy

-   vytvoření dobře vypadající a plně funkční aplikace (bonusové body)

-   plánování projektu (logická struktura rozložení práce)

-   nastavení automatizovaného buildu (kód je přeložitelný, spouští se automatizované testy, pipeline nekončí chybou)


### Rozšíření pro týmy složené z studentů kombinujících ICS/IW5

Místo přímého přístupu do databáze z backendu WPF aplikace využijte přístup pomocí RESTu. Vytvořte tedy serverovou část aplikace (hostujte v konzoli), která bude nabízet [**OpenAPI**](https://swagger.io/docs/specification/about/) rozhraní pro manipulaci dat z klientské aplikace (WPF).  Jak na to zjistíte studiem dokumentace [Swagger / OpenAPI](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-2.2). Využít můžete Swashbuckle nebo NSwag dle libosti. Klientský kód generujte z OpenAPI definice.

### Bonusové body

Za projevenou iniciativu je možné získat bonusové body. Nápady na možná
rozšíření:

-   Příspěvky a komentáře budou moci obsahovat i obrázky, soubory a videa

-   U příspěvků a komentářů půjde označit členy týmu. Označení členové uvidí příspěvek zvýrazněně

-   Uživatel si bude moci zobrazit příspěvky u kterých byl označen napříč týmy

-   Přihlášení pomocí externích služeb (Google, Facebook, Microsoft)
  
-   Rozšíření o OpenAPI, pokud je pro Vás nepovinné


-   -   -   -   -   -   

## Obhajoba

Obhajoby projektů budou probíhat v **posledních 2 týdnech** semestru. Termíny obhajob budou vyhlášeny v průběhu semestru.

Na obhajobu se dostaví **celý tým**. Z členů týmu bude cvičícími vybrán 1 student, který obhajobu povede. Na obhajobu **není nutné** mít prezentaci (Powerpoint nebo pdf). Budete nám muset ukázat, jak funguje váš kód, že je správně navržen. Připravte se na naše otázky
k funkcionalitě jednotlivých tříd a k důvodům jejich členění. Na obhajobu bude mít tým 10-15 minut.

## Základní funkcionalita

**Pokud aplikace nesplňuje následující podmínky je projekt hodnocen 0 body!**

Aplikace musí splňovat
 - Přihlašování
    - Bezpečné ukládání hesel
 - Seznam týmů
    - Zobrazení týmů přihlášeného uživatele
 - Zobrazení příspěvků týmu
    - Zobrazení všech příspěvků v týmu řazené dle poslední aktivity u příspěvku
    - Komentáře pod jednotlivými příspěvky
    - Texty příspěvku i komentáře jsou formátovány
    - Možnost vložení příspěvku s titulkem a formátovaným textem
    - Možnost komentovat příspěvek
 - Vytvoření uživatele
 - Správa členů týmu
    - Možnost přidat a odebrat člena 
