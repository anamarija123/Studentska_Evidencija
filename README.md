# Studentska Evidencija
Studentska evidencija je stranica koja sadrzi bazu podataka fakulteta u koju se ulogira nastavnik/student te ima uvid u podatke 
studenata, profesora,smjerove,predmete i ispite. Ima mogućnost editiranja i kreiranja novih podataka.

## Pocetna stranica-Vsite
![alt tag](https://github.com/anamarija123/Studentska_Evidencija-PIN/blob/master/evidencija.PNG)

Za izgled početne web stranice, kao temelj sam izabrala bootstrap template. Stranicu sam radila po pitanju: kome je ova evidencija namjenjena? Tko će biti posjetitelji te stranice? - odgovorila sam sa budući studenti, sadašnji studenti i profesori.
Upotrebljavala sam nešto javascripta i external css. Početna web stranica je rađena u Home - Index.cshtml file-u. External css se nalazi u wwwroot - css - main.css file-u.

Na sve tablice sam dodala boostrap klasu (class="table table-hover" ili "class=table table-border" ili "class=table table-striped")

Projekt je rađen u akademske svrhe.
### Identity
Za nastavak se potrebno registrirati ili ako ste već registrirani, potrebno se logirati.
Koristen Authorize atribut koji onemogucuje pristup ukoliko niste registrirani.
```asp.net
[Authorize]
```
#### Model u MVC-u

Modeli: Student, Nastavnik, Predmet, Smjer, Ispit.

Svaki entitet ima svoj ID.
Student ima ime i prezime te datum rodenja. Nastavnik ima ime, prezime i datum zaposlenja.
Unos imena i prezimena je ograniceno na 15 znakova.

Primjer:
```asp.net
[Required]
[StringLength(15, ErrorMessage = "maksimalno 15 znakova")]
```
Prilikom kreiranja ili editiranja datuma u entitetu, prikazuje se padajuci izbornik za laksi odabir:
```asp.net
[DataType(DataType.Date)]
[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
```
Smjer sadrzi ID, naziv i ects bodove potrebne za upis na taj smjer.

Predmet sadrzi ID,naziv i strani kljuc smjera.
U Ispit entitetu se nalaze tri strana kljuca - profesorID, studentID i predmetID. Takodjer sadrzi i svoj ID,ocjenu te datum ispita.

Na stranici se ne prikazuju njihovi IDevi vec ime i prezime ili naziv, za lakse snalazenje.

##### Migracija

Migracija na bazu se radi putem naredbe:
Add-Migration (naziv),
Update-Database.

###### Trazilica
U entitetima Student i Nastavnik postoji rubrika Trazi. Upisivanjem imena ili prezimena s lakocom se dolazi do odredjene osobe.
Koristen je LINQ upit za dohvat podataka.
