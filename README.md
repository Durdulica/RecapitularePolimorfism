# Recapitulare Polimorfism

Trei exercitii progresive de OOP / polimorfism in C# (.NET 8). Fiecare exercitiu e independent — propriul `.csproj`, propriul `Cerinta.md`. Toate sunt legate de un `Recapitulare.sln` la root, ca sa le poti deschide impreuna in IDE.

## Cum rulezi un exercitiu

**Din IDE (Rider, Visual Studio, VS Code):**
- Deschide folderul root sau `Recapitulare.sln`.
- In Rider/VS, dreapta-click pe proiectul dorit (ex `Recapitulare` = ex1, `SistemFisiere` = ex2, `Expresii` = ex3) → **Set as Startup Project** → apoi Run (▶).

**Din terminal:**

```bash
# Ruleaza ex1 (figuri geometrice - deja rezolvat)
dotnet run --project ex1

# Ruleaza ex2 (sistem fisiere - starter, Main e gol)
dotnet run --project ex2

# Ruleaza ex3 (expresii - starter, Main e gol)
dotnet run --project ex3

# Build pentru toate 3 simultan
dotnet build
```

**Daca rulezi ex2 sau ex3 si nu vezi output:** e normal — `Program.cs` are doar TODO-uri. Trebuie sa scrii codul demo dupa ce implementezi clasele.

## Exercitii

| # | Titlu | Concept nou fata de precedentul | Status |
|---|---|---|---|
| **1** | [Figuri geometrice](ex1/) | Mostenire abstracta, polimorfism, Composite (Desen) | ✅ rezolvat |
| **2** | [Sistem de fisiere](ex2/Cerinta.md) | Composite recursiv, mutatie pe array (Add/Remove fara List) | 🟡 starter |
| **3** | [Expresii matematice](ex3/Cerinta.md) | 3 operatii polimorfice, derivare = transformare de arbore, Context cu lookup liniar | 🟡 starter |

## Reguli generale (ca la ex1)

- **Nu folosi** `List<T>`, `Dictionary<,>`, `HashSet<>` sau alte colectii generice — doar array-uri brute. Pentru Add/Remove redimensionezi manual.
- **Nu folosi** LINQ (`.Where`, `.Select`, etc.). Doar `for` clasic si indexare.
- **Mesajele de eroare** in exceptii — in engleza.
- **Stilul** — proprietati PascalCase, constructori care iau parametri, evita campurile publice direct.

## Cum sa lucrezi un exercitiu nou

1. Citeste **tot** `Cerinta.md` inainte sa atingi codul.
2. Deschide schelele din `Models/` si vezi metodele `throw new NotImplementedException()`. Asta e tot ce trebuie sa implementezi.
3. **Gandeste 10 minute pe hartie** ce face fiecare metoda inainte sa scrii cod.
4. Implementeaza intai metodele simple (clasele frunza — `Fisier`, `Constanta`, `Variabila`). Apoi clasele compuse.
5. Ruleaza demo-ul din `Program.cs` pas cu pas.
6. **Commit dupa fiecare clasa rezolvata.**
