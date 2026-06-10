# Exercitiul 4 — Sistem bancar

## Context

O banca administreaza mai multe tipuri de conturi pentru clientii sai. Trebuie sa implementezi gestionarea conturilor, a tranzactiilor si a istoricului, in asa fel incat acelasi cod sa functioneze peste toate tipurile de cont, fara `if`/`switch` pe tip.

## Tipuri de cont

1. **Cont de economii** — are dobanda anuala (de exemplu 4%). Permite UNA SINGURA retragere pe luna fara penalitate; orice retragere suplimentara in aceeasi luna calendaristica aplica o penalitate de 5% din suma retrasa (penalitatea se scade din cont peste suma retrasa). Soldul nu poate deveni negativ.

2. **Cont curent** — permite overdraft pana la o limita configurabila per cont (de exemplu -500 RON). Fiecare retragere are un comision fix (2 RON) care se scade in plus pe langa suma. Daca retragerea + comisionul ar duce soldul sub limita de overdraft, retragerea e respinsa integral.

3. **Cont card** — are o limita zilnica de retragere (de exemplu 2000 RON pe zi calendaristica). Suma totala a retragerilor intr-o zi nu poate depasi aceasta limita. Tranzactiile peste limita sunt respinse integral. Soldul nu poate deveni negativ.

## Tipuri de tranzactii

1. **Depunere(suma)** — adauga o suma in cont. Reuseste intotdeauna pentru suma > 0.

2. **Retragere(suma)** — scoate o suma din cont. Poate fi acceptata integral, sau respinsa integral, sau partial respinsa cu penalitati/comisioane (depinde de tipul de cont).

3. **Transfer(suma, contDestinatie)** — combina o retragere din contul sursa cu o depunere in contul destinatie. **Atomicitate:** daca retragerea esueaza, depunerea NU se face si contul destinatie ramane neatins.

Fiecare tranzactie pastreaza:
- `DateTime` cu data si ora aplicarii
- suma
- rezultat: `Succes` sau `Esec` + motiv (in engleza) daca a esuat
- referinta la contul (sau conturile) aferent(e)

## Operatii cerute

Fiecare cont trebuie sa:
- aplice o tranzactie peste el si sa-i memoreze rezultatul in istoric
- pastreze istoricul tranzactiilor (in ordine cronologica)
- afiseze un raport: tip cont, sold curent, ultimele 5 tranzactii cu data si rezultat
- aplice dobanda lunara cand i se cere (doar contul de economii face efectiv ceva; pentru celelalte tipuri operatia trebuie sa fie no-op fara a arunca exceptie)

## Cerinte

1. Defineste ierarhia de clase necesara.
2. Implementeaza regulile de comportament pentru fiecare tip de cont.
3. In `Program.cs`:
   - Creeaza minim 3 conturi de tipuri diferite cu solduri initiale.
   - Aplica minim 8 tranzactii (mix Depunere/Retragere/Transfer) care sa demonstreze ca cele 3 tipuri reactioneaza diferit la aceeasi tranzactie (cel putin o retragere mare care e respinsa pe Card, una care e acceptata cu overdraft pe Curent, una care declanseaza penalitate pe Economii).
   - Aplica dobanda lunara peste toate conturile, polimorfic — printr-o singura bucla, fara a testa tipul.
   - Afiseaza rapoartele finale pentru toate conturile.

## Constrangeri

- Fara `List<T>`, `Dictionary<,>`, `HashSet<>`, LINQ.
- Doar array-uri si `for` clasic.
- Mesajele de eroare in engleza.
- `DateTime.Now` e permis (e singura facilitate de runtime acceptata in afara celor din .NET base).
- Programul principal NU are voie sa testeze tipul concret al unui cont (`is`, `as`, `GetType()` interzise in afara framework-ului propriu, daca alegi sa folosesti vreunul).
