# Exercitiul 2 — Sistem de fisiere

## Context

Sa se defineasca o ierarhie de clase pentru reprezentarea unui sistem de fisiere simplificat.

## Tipuri de elemente

Un **element** dintr-un sistem de fisiere poate fi:

| Tip | Are |
|---|---|
| **Fisier** | nume + dimensiune (in bytes) |
| **Director** | nume + lista de elemente (poate contine fisiere SAU alte directoare, oricat de adanc) |

## Operatii cerute pe ORICE element

1. **`long DimensiuneTotala()`**
   - Pentru un fisier: dimensiunea proprie.
   - Pentru un director: **suma dimensiunilor tuturor copiilor**, recursiv (sub-directoare incluse).

2. **`void Afisare(int nivel)`**
   - Afiseaza ierarhia cu indentare. `nivel` controleaza cate spatii pui in fata.
   - Exemplu de output:
   ```
   [DIR] root (1500 bytes)
     [DIR] docs (800 bytes)
       [FILE] readme.txt (500 bytes)
       [FILE] notes.txt (300 bytes)
     [FILE] app.exe (700 bytes)
   ```

3. **`Element Cauta(string nume)`**
   - Cauta primul element cu numele dat in ierarhie. Returneaza referinta la el sau `null` daca nu exista.
   - Cautarea trebuie sa fie **recursiva** (sa intre si in sub-directoare).

## Operatii suplimentare pe Director

4. **`void Adauga(Element element)`** — adauga un element nou.
5. **`void Sterge(string nume)`** — sterge primul element cu numele dat de la primul nivel (nu recursiv). Daca nu exista, nu face nimic.

## Cerinte

1. Defineste o clasa abstracta `Element` cu metodele 1, 2, 3.
2. Defineste `Fisier : Element` si `Director : Element`.
3. Foloseste **pattern-ul Composite**: `Director.Elemente` e un `Element[]`. Asa, un director poate contine fisiere SAU alte directoare, fara discriminare.
4. **Nu folosi `List<T>`, `Dictionary<,>` sau alte colectii generice** — doar array-uri brute (`Element[]`). Pentru Add/Remove va trebui sa redimensionezi manual array-ul (creezi unul nou de dimensiunea potrivita si copiezi elementele).
5. Scrie un program demo in `Program.cs` care:
   - Construieste ierarhia de mai jos
   - Afiseaza dimensiunea totala
   - Afiseaza intreaga ierarhie
   - Cauta `"notes.txt"` si afiseaza dimensiunea lui (ar trebui sa fie 300)
   - Cauta `"inexistent.txt"` (ar trebui sa returneze null — afiseaza un mesaj)
   - Sterge `"app.exe"` din root si afiseaza din nou ierarhia

```
root/
├── docs/
│   ├── readme.txt (500 bytes)
│   └── notes.txt (300 bytes)
└── app.exe (700 bytes)
```

## Concepte testate

- Mostenire + polimorfism (peste `Element`)
- **Composite pattern** — un director e tratat la fel ca un fisier (ambele sunt `Element`)
- **Recursie prin polimorfism** — `DimensiuneTotala()` se apeleaza recursiv pe copii fara sa stii ce tip sunt
- **Manipulare manuala de array** — Add/Remove fara `List<T>`

## Cum rulezi

```bash
cd ex2
dotnet run
```

## Bonus (daca termini repede)

- Adauga o metoda `int NumarFisiere()` care numara cate fisiere (nu directoare) sunt in toata ierarhia.
- Adauga validare: nu poti adauga doua elemente cu acelasi nume in acelasi director.
