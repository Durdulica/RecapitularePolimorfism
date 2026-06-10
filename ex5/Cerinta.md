# Exercitiul 5 — RPG turn-based

## Context

Implementeaza un mini-RPG cu echipe de personaje care lupta intr-o secventa de runde, alternand. Fiecare personaj are abilitati diferite si reactioneaza diferit la actiunile celorlalti. Codul care orchestreaza batalia trebuie sa fie generic — nu testeaza tipul personajului cu `if`/`switch`.

## Personaje (5 tipuri obligatorii)

| Tip | HP initial | Statistici proprii | Comportament in lupta |
|---|---|---|---|
| **Razboinic** | 100 | Forta = 20, Armura = 10 | Loveste un inamic in viata cu sabia (daune = Forta). Cand primeste daune, scade Armura din ele (minim 1 daunie). |
| **Mag** | 60 | PutereMagica = 25, Mana initiala = 100 | Arunca fireball care consuma 30 mana (daune = PutereMagica). Daca nu are mana suficienta, sare tura. Regenereaza 5 mana la inceputul fiecarei runde. |
| **Arcas** | 75 | Precizie = 80, Damage = 18 | Trage sageti — cu probabilitate egala cu Precizia (procentual) loveste un inamic; altfel rateaza si nu face daune. |
| **Vindecator** | 50 | PutereVindecare = 30 | NU ataca niciodata. Vindeca un coleg in viata (din aceeasi echipa) cu HP-ul cel mai mic. Daca toti colegii sunt la HP maxim, sare tura. HP-ul vindecat nu poate depasi HP maxim al colegului. |
| **Asasin** | 70 | Damage = 30 | Atac normal in fiecare runda. La fiecare a treia tura proprie aplica "Critical strike" — daune x2 in acea tura. |

Toate personajele au: `Nume`, `HP curent`, `HP maxim`, `EsteInViata` (true daca HP > 0). Cand HP ajunge la 0 sau sub, personajul moare si nu mai actioneaza.

## Echipe

O `Echipa` are un nume si contine 2-5 personaje. Echipa e considerata infranta cand toate personajele au murit.

## Batalia

O batalie e intre 2 echipe. Se desfasoara in runde:

1. La inceputul fiecarei runde, regenereaza mana pentru toti magii in viata din ambele echipe.
2. In ordinea declararii (mai intai echipa A in ordinea personajelor, apoi echipa B), fiecare personaj in viata executa actiunea proprie. Daca personajul e mort cand i-ar veni randul, e sarit.
3. Personajele care ataca aleg primul inamic in viata din echipa adversa.
4. Vindecatorul alege colegul lui in viata cu cel mai mic HP.

Batalia se incheie cand una din echipe ramane fara personaje in viata. Trebuie sa afisezi:
- ce s-a intamplat in fiecare runda (cine a atacat pe cine, daune, vindecari, ratari, mort)
- echipa castigatoare
- statistici finale: cate runde a durat, cati combatanti au mai ramas in viata din echipa castigatoare, HP-urile finale

## Cerinte

1. Defineste ierarhia de clase pentru personaje.
2. Implementeaza Echipa si Batalia.
3. In `Program.cs`:
   - Creeaza 2 echipe cu compozitii diferite. Recomandare pentru un test cu rezultat interesant:
     - Echipa A: 1 Razboinic, 1 Vindecator, 1 Mag
     - Echipa B: 2 Arcasi, 1 Asasin
   - Ruleaza o batalie completa cu output detaliat per runda.

## Constrangeri

- Fara `List<T>`, `Dictionary<,>`, LINQ. Doar array-uri si `for` clasic.
- Pentru elemente probabilistice (Arcas, atac aleator) foloseste `Random` cu seed fix (de exemplu `new Random(42)`) ca rezultatul sa fie reproductibil.
- Bucla principala a bataliei NU are voie sa testeze tipul concret al unui personaj. Orice diferenta de comportament trebuie sa vina din polimorfism (metode override).
- Mesajele de output in romana sunt ok; mesajele de eroare in exceptii in engleza.
