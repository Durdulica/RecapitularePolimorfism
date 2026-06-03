# Exercitiul 3 — Expresii matematice

## Context

Sa se defineasca o ierarhie de clase pentru reprezentarea si manipularea **expresiilor aritmetice**.

O expresie e un arbore: nodurile interne sunt operatii (`+`, `-`, `*`), iar frunzele sunt constante (`5`, `3.14`) sau variabile (`x`, `y`).

Exemple de expresii:
- `(x + 3)` — adunare intre o variabila si o constanta
- `(x + 3) * (x - 2)` — inmultire intre doua sub-expresii

## Tipuri de expresie

| Tip | Are |
|---|---|
| **Constanta** | o valoare numerica (`double`) |
| **Variabila** | un nume (`string`, ex: `"x"`) |
| **Adunare** | doua sub-expresii (`stanga`, `dreapta`) |
| **Scadere** | doua sub-expresii |
| **Inmultire** | doua sub-expresii |

## Operatii cerute pe ORICE expresie

### 1. `double Evaluare(Context ctx)`

Calculeaza valoarea numerica a expresiei, pentru un anumit context (valorile concrete ale variabilelor).

- `Constanta(5).Evaluare(ctx)` returneaza `5`, indiferent de context.
- `Variabila("x").Evaluare(ctx)` cauta in `ctx` valoarea lui `"x"` si o returneaza.
- `Adunare(a, b).Evaluare(ctx)` returneaza `a.Evaluare(ctx) + b.Evaluare(ctx)`.
- Analog pentru `Scadere` (minus), `Inmultire` (`*`).

### 2. `void Afisare()`

Afiseaza expresia in forma cu paranteze. Exemplu:
- `Adunare(Variabila("x"), Constanta(3))` -> `(x + 3)`
- `Inmultire(Adunare(Variabila("x"), Constanta(3)), Scadere(Variabila("x"), Constanta(2)))` -> `((x + 3) * (x - 2))`

### 3. `Expresie Derivare(string variabila)`

**Asta e partea grea.** Returneaza o **NOUA expresie** care reprezinta derivata expresiei curente in raport cu `variabila`.

Reguli matematice (le ai si in liceu):

| Expresie | Derivata in raport cu `x` |
|---|---|
| `c` (constanta) | `0` |
| `x` (chiar variabila ceruta) | `1` |
| `y` (alta variabila) | `0` |
| `a + b` | `a' + b'` |
| `a - b` | `a' - b'` |
| `a * b` | `a' * b + a * b'` (regula produsului) |

unde `a'` inseamna `a.Derivare(variabila)`.

**Important:** `Derivare` nu evalueaza nimic — construieste un arbore nou. Asta e ce face polimorfismul puternic — fiecare clasa stie cum sa-si construiasca derivata.

## Clasa `Context`

Pentru ca evaluarea unei variabile cere o valoare concreta, ai nevoie de un container nume → valoare.

**Constrangere:** nu folosi `Dictionary<,>`. In schimb, foloseste doua array-uri paralele:

```csharp
public string[] Nume { get; set; }    // ["x", "y"]
public double[] Valori { get; set; }  // [5, 7]
```

Si o metoda `GetValoare(string nume)` care cauta liniar prin `Nume` si returneaza din `Valori`. Daca nu gaseste, arunca `ArgumentException`.

Adauga si o metoda `Seteaza(string nume, double valoare)` care:
- daca numele exista deja, actualizeaza valoarea
- altfel redimensioneaza array-urile si adauga la final

## Cerinte

1. Defineste o clasa abstracta `Expresie` cu cele 3 metode.
2. Defineste cele 5 subclase (`Constanta`, `Variabila`, `Adunare`, `Scadere`, `Inmultire`).
3. Implementeaza clasa `Context` cu cautare liniara.
4. Scrie un program demo in `Program.cs` care:
   - Construieste expresia `e = (x + 3) * (x - 2)`
   - O afiseaza
   - Construieste contextul cu `x = 5`
   - Evalueaza `e` — ar trebui sa returneze `(5 + 3) * (5 - 2) = 8 * 3 = 24`
   - Calculeaza `eDerivat = e.Derivare("x")` si o afiseaza
     - Matematic, derivata e `2x + 1`, dar arborele construit poate fi mai stufos (de exemplu `((1 + 0) * (x - 2) + (x + 3) * (1 - 0))`) — asta e ok, nu cerem simplificare.
   - Evalueaza `eDerivat` pentru `x = 5` — ar trebui sa returneze `11` (egal cu `2*5 + 1`)

## Concepte testate

- **Polimorfism puternic** — 3 operatii diferite, fiecare cu logica proprie per subclasa
- **Recursie naturala prin polimorfism** — `Evaluare` se cheama recursiv fara if-uri pe tip
- **Constructie de arbore nou** — `Derivare` returneaza obiecte noi (test pentru intelegerea referintelor vs valorilor)
- **Cautare liniara intr-un array** — `Context.GetValoare`

## Cum rulezi

```bash
cd ex3
dotnet run
```

## Bonus (daca termini)

- Adauga `Impartire` (si nu uita ca pentru `a / b` derivata e `(a'*b - a*b') / b^2` — adica vei avea nevoie si de `Inmultire` si `Scadere` si `Impartire`)
- Adauga o metoda `bool EsteConstant()` — returneaza `true` daca expresia nu contine nicio variabila
- Simplificare partiala: `Adunare(Constanta(0), x)` ar trebui sa se simplifice la `x` (foarte greu, doar daca-ti place provocarea)
