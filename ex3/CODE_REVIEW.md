# Code Review — ex3 (Expresii matematice)

**Status:** ✅ rezolvat, demo ruleaza si da `24` + `11` (corect matematic)

Felicitari — structura ierarhiei e curata, regula produsului si regula coatului sunt corecte matematic, si `Derivare` returneaza corect un **arbore nou** (testul critic — nu mutezi expresia existenta). Dar sunt 3 bug-uri reale si 2 lucruri de curatat.

---

## 🔴 Bug-uri reale

### 1. `Context.Seteaza` pierde vechile valori la redimensionare

**Fisier:** `Models/Context.cs:28-35`

Creezi `numeTemp`/`valoriTemp` mai mari cu 1 si pui doar elementul nou la final, **dar nu copiezi vechile elemente**. Functioneaza acum doar pentru ca demo-ul seteaza o singura variabila (`"x"`). Repro:

```csharp
ctx.Seteaza("x", 5);
ctx.Seteaza("y", 7);
ctx.GetValoare("x");   // ArgumentException! "x" a disparut
```

**Fix:** adauga bucla de copy inainte de a pune elementul nou:

```csharp
string[] numeTemp = new string[Nume.Length + 1];
double[] valoriTemp = new double[Valori.Length + 1];

for (int i = 0; i < Nume.Length; i++)
{
    numeTemp[i] = Nume[i];
    valoriTemp[i] = Valori[i];
}

numeTemp[numeTemp.Length - 1] = nume;
valoriTemp[valoriTemp.Length - 1] = valoare;

Nume = numeTemp;
Valori = valoriTemp;
```

**De ce conteaza:** exact aceasta operatie apare in ex2 (`Director.Adauga`) si in orice exercitiu unde ai de redimensionat un array. Daca o gresesti acolo, pierzi toate fisierele existente cand adaugi unul nou.

---

### 2. `Inmultire.Afisare` nu pune paranteze

**Fisier:** `Models/Inmultire.cs:19-24`

Cerinta cere `((x + 3) * (x - 2))`, dar produci `(x + 3) * (x - 2)`. Functioneaza in demo-ul curent doar pentru ca `Adunare`/`Scadere` deja isi pun paranteze. Dar pentru o expresie ca `Inmultire(Inmultire(a, b), c)` afisarea e ambigua: `a * b * c`.

**Fix:**

```csharp
public override void Afisare()
{
    Console.Write("(");
    Stanga.Afisare();
    Console.Write(" * ");
    Dreapta.Afisare();
    Console.Write(")");
}
```

---

### 3. `Impartire.Afisare` — aceeasi problema

**Fisier:** `Models/Impartire.cs:24-29`

Identic cu #2. Adauga `Console.Write("(")` la inceput si `Console.Write(")")` la sfarsit.

---

## 🟡 Curatenie

### 4. Cod mort in `Inmultire.Derivare`

**Fisier:** `Models/Inmultire.cs:31`

```csharp
Context ctx = new Context();    // ← linie complet inutila, sterge-o
```

Nu o folosesti nicaieri. Probabil ai inceput sa scrii ceva si nu ai mai sters.

---

### 5. `Impartire.Evaluare` evalueaza `Dreapta` de doua ori

**Fisier:** `Models/Impartire.cs:16-21`

```csharp
double val = Dreapta.Evaluare(ctx);
if (val == 0) { throw new ArgumentException("..."); }
return Stanga.Evaluare(ctx) / Dreapta.Evaluare(ctx);   // ← reapelezi Dreapta!
```

**Fix:** reutilizeaza `val`:

```csharp
double valDreapta = Dreapta.Evaluare(ctx);
if (valDreapta == 0) throw new ArgumentException("Division by zero");
return Stanga.Evaluare(ctx) / valDreapta;
```

---

## 🟡 Mesaje de eroare in engleza (regula proiectului)

| Fisier | Romana acum | Engleza dorita |
|---|---|---|
| `Context.cs:50` | `"Variabila nu este cunoscuta"` | `"Unknown variable: " + nume` |
| `Impartire.cs:18` | `"Impartirea cu 0 este imposibila"` | `"Division by zero"` |

Comentariul-hint de deasupra `GetValoare` zice explicit „arunca ArgumentException cu mesaj englez" — ai uitat regula.

---

## ✅ Ce ai facut bine

- `Constanta`, `Variabila`, `Adunare`, `Scadere` — clean, fara probleme.
- `Adunare.Derivare` si `Scadere.Derivare` — fix `(a + b)' = a' + b'`, exact.
- `Inmultire.Derivare` — regula produsului `(a*b)' = a'*b + a*b'` aplicata corect.
- `Impartire.Derivare` — regula coatului `(a/b)' = (a'*b - a*b') / b²` aplicata corect, cu `Inmultire(Dreapta, Dreapta)` in loc de o putere (corect, nu aveai cum altfel).
- Folosesti corect proprietatile, constructorii cer parametri, fara colectii generice.
- `Derivare` returneaza intotdeauna obiecte noi — nu modifici expresia existenta. Asta e testul critic al ex-ului.

---

## Tabel sumar

| # | Severitate | Fisier:linie | Problema |
|---|---|---|---|
| 1 | 🔴 Bug | `Context.cs:28-35` | Nu copiaza vechile valori → a 2-a variabila sterge prima |
| 2 | 🔴 Bug | `Inmultire.cs:19-24` | `Afisare` fara paranteze → ambiguu la imbricare |
| 3 | 🔴 Bug | `Impartire.cs:24-29` | Idem |
| 4 | 🟡 Cleanup | `Inmultire.cs:31` | `new Context()` nefolosit |
| 5 | 🟡 Perf | `Impartire.cs:16-21` | `Dreapta` evaluata de 2 ori |
| 6 | 🟡 Stil | `Context.cs:50` | Mesaj eroare RO in loc de EN |
| 7 | 🟡 Stil | `Impartire.cs:18` | Idem |

## Ordine recomandata de rezolvare

1. **Intai #1 (Context)** — bug-ul cel mai grav, dar invizibil cu demo-ul actual. Adauga un test: `ctx.Seteaza("x", 5); ctx.Seteaza("y", 7); Console.WriteLine(ctx.GetValoare("x"));` — daca da `5`, ai reparat.
2. **#2 si #3 (paranteze)** — la fel — adauga un caz nou in demo: `new Inmultire(new Inmultire(a, b), c).Afisare();` ar trebui sa dea `((a * b) * c)`.
3. **#4, #5, #6, #7** — curatenie rapida.
