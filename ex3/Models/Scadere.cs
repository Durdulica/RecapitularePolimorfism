namespace Expresii.Models
{
    public class Scadere : Expresie
    {
        public Expresie Stanga { get; set; }
        public Expresie Dreapta { get; set; }

        public Scadere(Expresie stanga, Expresie dreapta)
        {
            Stanga = stanga;
            Dreapta = dreapta;
        }

        public override double Evaluare(Context ctx)
        {
            return Stanga.Evaluare(ctx) - Dreapta.Evaluare(ctx);
        }

        public override void Afisare()
        {
            Console.Write("(");
            Stanga.Afisare();
            Console.Write(" - ");
            Dreapta.Afisare();
            Console.Write(")");
        }

        public override Expresie Derivare(string variabila)
        {
            // (a - b)' = a' - b'
            return new Scadere(Stanga.Derivare(variabila), Dreapta.Derivare(variabila));
        }
    }
}
