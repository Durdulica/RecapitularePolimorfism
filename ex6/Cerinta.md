# Exercitiul 6 — Mini-limbaj de programare

## Context

Implementeaza infrastructura pentru un mini-limbaj cu variabile, expresii, conditii si bucle. Lucrezi direct cu arborele de sintaxa abstracta (AST) construit manual cu constructori — fara parser de text.

Peste acelasi AST trebuie sa rulezi **3 operatii independente**, fiecare in mod polimorfic. Codul fiecarei operatii NU are voie sa testeze tipul concret al unui nod cu `if`/`switch` / `is` / `as` / `GetType()`. Diferenta de comportament per tip de nod trebuie sa vina din `override`.

## Tipuri de nod in AST

### Expresii (returneaza valoare la evaluare)

- `IntLit(int n)` — literal intreg (ex `42`)
- `BoolLit(bool b)` — literal boolean (ex `true`)
- `Var(string nume)` — referinta la o variabila
- `BinOp(string operator, Expresie stanga, Expresie dreapta)` — operatie binara cu operatorul in `+`, `-`, `*`, `/`, `<`, `>`, `==`, `&&`, `||`
- `UnaryOp(string operator, Expresie operand)` — `!` (negare booleana) sau `-` (negare numerica)

### Instructiuni (modifica starea, nu returneaza valoare)

- `Declaratie(string tip, string nume, Expresie valoareInitiala)` — `tip` e `"int"` sau `"bool"`
- `Atribuire(string nume, Expresie valoare)` — actualizeaza valoarea unei variabile deja declarate
- `If(Expresie conditie, Bloc ramuraThen, Bloc ramuraElse)` — `ramuraElse` poate fi un bloc gol (nu null)
- `While(Expresie conditie, Bloc corp)`
- `Bloc(Instructiune[] instructiuni)` — secventa de instructiuni
- `Afisare(Expresie expresie)` — printeaza valoarea expresiei evaluate, urmata de newline

Valorile cu care lucreaza limbajul sunt **int** si **bool**. Operatorii aritmetici (`+ - * /`) si comparatiile (`< >`) lucreaza pe int; `==` lucreaza pe ambele tipuri dar operanzii trebuie sa fie de acelasi tip; `&& ||` lucreaza doar pe bool; `!` doar pe bool; `-` unar doar pe int.

## Cele 3 operatii peste AST

### 1. Interpretor

Executa programul:
- Mentine un mediu (variabile declarate → valoarea lor curenta).
- Evalueaza expresiile recursiv.
- Executa instructiunile in ordine, modificand mediul.
- `Afisare` scrie la consola.
- Tratament de erori (toate cu mesaj in engleza):
  - Variabila folosita fara declaratie
  - Variabila redeclarata
  - Tip gresit (ex `+` aplicat pe bool, sau `&&` aplicat pe int)
  - Atribuire de tip gresit (`int x = true`)
  - Impartire la zero

### 2. Printer

Afiseaza programul ca text human-readable, cu indentare de 2 spatii pentru fiecare nivel de bloc.

Exemplu de output asteptat pentru programul de mai jos:
```
int x = 0;
int suma = 0;
while ((x < 10)) {
  suma = (suma + x);
  x = (x + 1);
}
print(suma);
```

Expresiile binare se afiseaza cu paranteze intotdeauna (ca la ex3). `If` se afiseaza cu `if` + `else` (chiar daca else e bloc gol).

### 3. NumaratoareNoduri

Parcurge AST-ul si returneaza un raport: cate noduri de fiecare tip exista (cate `IntLit`, cate `BinOp`, cate `If`, etc.). Afisarea raportului se face la finalul vizitarii.

Exemplu de raport (numerele sunt orientative):
```
IntLit: 5
Var: 4
BinOp: 4
Declaratie: 2
Atribuire: 2
While: 1
Bloc: 1
Afisare: 1
```

## Cerinte

1. Defineste ierarhia AST.
2. Implementeaza cele 3 operatii.
3. In `Program.cs` construieste **manual** AST-ul echivalent cu:
   ```
   int x = 0;
   int suma = 0;
   while (x < 10) {
     suma = suma + x;
     x = x + 1;
   }
   print(suma);
   ```
   Apoi:
   - Aplica Printer si afiseaza textul programului
   - Aplica NumaratoareNoduri si afiseaza raportul
   - Aplica Interpretor; output-ul `Afisare` trebuie sa fie `45` (suma 0+1+2+...+9)

## Constrangeri

- Fara `List<T>`, `Dictionary<,>` (inclusiv pentru mediul interpretorului si pentru numaratoarea de noduri — foloseste array-uri brute redimensionate manual). Fara LINQ.
- Cele 3 operatii trebuie sa fie complet independente — nu impart cod intre ele, nu se invoca una pe alta.
- Niciun `if`/`switch`/`is`/`as`/`GetType()` pe tipuri de nod in afara constructorilor.
- Mesajele de eroare in engleza.

## Bonus (daca termini)

- Adauga instructiunea `For(Declaratie init, Expresie conditie, Atribuire increment, Bloc corp)`.
- Adauga o a patra operatie: **constant folding** — daca un `BinOp` are doua operanzi `IntLit` (sau `BoolLit`), il inlocuieste cu rezultatul calculat. Returneaza un AST NOU (nu modifica originalul). Aplica-o inainte de Interpretor si arata ca rezultatul evaluarii nu se schimba.
