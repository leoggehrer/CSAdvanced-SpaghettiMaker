Lernzielkontrolle:
------

**�berpr�fung der Lerninhalte:** 
- Die Programmierkonzepte **async** und **await** anwenden k�nnen.
- Die Anwendung von Task.WhenAny(...) anwenden k�nnen.
- Die Anwendung von Task.WhenAll(...) anwenden k�nnen.

## Spaghetti Kochen
### Grundsystem

**SpaghettiMaker** Erstellen Sie die Projektstruktur von *SpaghettiMaker* und fassen Sie die einzelnen Projekte zu einer Solution zusammen. Die Struktur besteht aus den Projekten:

|Name|Beschreibung|
|---|---|
|SpaghettiMaker.Common|In diesem Projekt sind die gemeinsamen Klassen wie Pot, Water, Redwine usw. implementiert.|
|SpaghettiMaker.Logic|In diesem Projekt befinden sich die Klasse Spaghetti f�r die asynchrone Zubereitung des Essens.|
|SpaghettiMaker.ConApp|Eine Konsolen-Anwendung zum Starten f�r die Zubereitung der Spaghetti.|

Verbinden Sie die Abh�ngigkeiten der einzelnen Projekte untereinander.

**Zubereitung der Spaghetti** 

In der folgenden Tabelle sind die einzelnen Schritte f�r die Zubereitung des Abendessens (350g Spaghetti und 200g Tomatensauce) beschrieben. Beachten Sie folgende Rahmenbedingungen:

* In einem Kochtopf k�nnen zu einem Zeitpunkt nicht mehr als 200g Spaghetti zubereitet (Kochzeit 20 sec.) werden.
* In einem Kochtopf k�nnen zu einem Zeitpunkt nicht mehr als 150g Tomatensauce zubereitet (Kochzeit 15 sec.) werden.
* Es stehen max. 3 gleiche Kocht�pfe zur Verf�gung.  
* Es steht ein Kochfeld mit 4  einzelnen Feldern zur Verf�gung.  

|Nr.|Name|Beschreibung|Ausgabe|Anmerkung|
|---|---|---|---|---|
|1.|*Task&lt;Redwine&gt; PourRedwineAsync()*|Gie�t den Rotwein in ein Glas ein.|Pouring redwine...Redwine is already|1 sec.|
|2.|*Task&lt;Pot&gt; HeatThePotAsync()*|Erhitzt einen Topf.|Heating pop...Pot is already|10 sec.|
|3.|*Task&lt;Spaghetti&gt; CookSpaghettiAsync(Pot pot, int amount)*|Kochen der Spaghetti. 'amount' gibt die Menge in g an.|Cook spaghetti...Spaghetti are already|max. 200g|
|4.|*Task&lt;TomatoSauce&gt; CookTomatosauceAsync(Pot pot, int amount)*|Kochen der Sauce. 'amount' gibt die Menge in g an..|Cook sauce...Sauce are already|max. 150g|
|5.|*Task&lt;Toast[]&gt; ToastBreadAsync(int count)*|Toasten von Brot z.B.: 2|Toasting bread...Breads are already|10 sec. pro Toastbrot|
|6.|*Task&lt;Water&gt; PourWaterAsync()*|Gie�t das Wasser in ein Glas ein.|Pouring water...Water is already|1 sec.|

**Asynchrone Zubereitung des Abendessens** 

Simulieren Sie nun in einem Programm die asynchrone Zubereitung des Essens und geben Sie die ben�tigte Zeit in Sekunden an. Die Zubereitungsfolge k�nnen Sie aus der Nummerierung ableiten.

## Hilfsmitteln
-   keine

## Abgabe
-   Termin: 50 min. nach der Vorbereitung

-   Klasse:

-   Name:

## Quellen
-  keine

# 
<center><strong>Viel Erfolg!</strong></center>
