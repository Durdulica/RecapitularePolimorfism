# Recapitulare Polimorfism

Sase exercitii progresive de OOP / polimorfism in C# (.NET 8). Fiecare exercitiu e independent — propriul `.csproj`, propriul `Cerinta.md` (sau `Cerinta.jpg` la ex1). Toate sunt legate de un `Recapitulare.sln` la root, ca sa le poti deschide impreuna in IDE.

## Cum rulezi un exercitiu

**Din IDE (Rider, Visual Studio, VS Code):**
- Deschide folderul root sau `Recapitulare.sln`.
- In Rider/VS, dreapta-click pe proiectul dorit (ex `Recapitulare` = ex1, `SistemFisiere` = ex2, `Expresii` = ex3) → **Set as Startup Project** → apoi Run (▶).

**Din terminal:**

```bash
# Ruleaza un exercitiu (ex1 e singurul cu Main complet — restul sunt starter)
dotnet run --project ex1     # figuri geometrice (rezolvat)
dotnet run --project ex2     # sistem fisiere (starter)
dotnet run --project ex3     # expresii (starter)
dotnet run --project ex4     # banca (fara starter)
dotnet run --project ex5     # RPG (fara starter)
dotnet run --project ex6     # mini-limbaj (fara starter)

# Build pentru toate simultan
dotnet build
```

**Daca rulezi ex2 sau ex3 si nu vezi output:** e normal — `Program.cs` are doar TODO-uri. Trebuie sa scrii codul demo dupa ce implementezi clasele.

## Exercitii

### Nivel 1 (cu schelet + hint-uri in cod)

| # | Titlu | Concept nou fata de precedentul | Status |
|---|---|---|---|
| **1** | [Figuri geometrice](ex1/) | Mostenire abstracta, polimorfism, Composite (Desen) | ✅ rezolvat |
| **2** | [Sistem de fisiere](ex2/Cerinta.md) | Composite recursiv, mutatie pe array (Add/Remove fara List) | 🟡 starter |
| **3** | [Expresii matematice](ex3/Cerinta.md) | 3 operatii polimorfice, derivare = transformare de arbore, Context cu lookup liniar | 🟡 starter |

### Nivel 2 (fara schelet, fara hint-uri — design complet pe cont propriu)

| # | Titlu | Provocare suplimentara | Status |
|---|---|---|---|
| **4** | [Sistem bancar](ex4/Cerinta.md) | Reguli de business divergente per tip de cont (penalitati, overdraft, limita zilnica), tranzactii compuse atomice (Transfer), dobanda lunara polimorfica | 🔴 fara starter |
| **5** | [RPG turn-based](ex5/Cerinta.md) | 5 tipuri de personaje cu mecanici complet diferite, echipa + batalie polimorfica, randomness reproductibil | 🔴 fara starter |
| **6** | [Mini-limbaj de programare](ex6/Cerinta.md) | AST cu Expresii + Instructiuni (If, While, Assign, Bloc), 3 operatii independente peste acelasi AST (interpretor, printer, numaratoare), zero if/switch pe tip de nod | 🔴 fara starter |

**Pentru exercitiile 4-6:**
- Nu ai nicio clasa scheletata — pornesti de la zero.
- `Program.cs` e gol, `Models/` nu exista — creezi tu structura.
- Cerinta descrie problema dar nu sugereaza ce clase trebuie sa faci. Tu decizi ierarhia.
- Constrangerea **„fara if/switch pe tipul concret"** te forteaza sa rezolvi orice variatie de comportament prin polimorfism (override). E cea mai importanta verificare a intelegerii OOP.

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
