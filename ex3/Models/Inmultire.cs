namespace Expresii.Models
{
    public class Inmultire : Expresie
    {
        public Expresie Stanga { get; set; }
        public Expresie Dreapta { get; set; }

        public Inmultire(Expresie stanga, Expresie dreapta)
        {
            Stanga = stanga;
            Dreapta = dreapta;
        }

        public override double Evaluare(Context ctx)
        {
            return Stanga.Evaluare(ctx) * Dreapta.Evaluare(ctx);
        }

        public override void Afisare()
        {
            Stanga.Afisare();
            Console.Write(" * ");
            Dreapta.Afisare();
        }

        public override Expresie Derivare(string variabila)
        {
            // Regula produsului: (a * b)' = a' * b + a * b'
            // Atentie: trebuie sa construiesti un arbore Adunare(Inmultire(...), Inmultire(...))

            return new Adunare(new Inmultire(Stanga.Derivare(variabila), Dreapta), new Inmultire(Stanga,Dreapta.Derivare(variabila)));
        }
    }
}
