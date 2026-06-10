namespace Expresii.Models
{
    public class Adunare : Expresie
    {
        public Expresie Stanga { get; set; }
        public Expresie Dreapta { get; set; }

        public Adunare(Expresie stanga, Expresie dreapta)
        {
            Stanga = stanga;
            Dreapta = dreapta;
        }

        public override double Evaluare(Context ctx)
        {
            return Stanga.Evaluare(ctx) + Dreapta.Evaluare(ctx);
        }

        public override void Afisare()
        {
            // Format dorit: "(stanga + dreapta)" cu paranteze
            Console.Write("(");
            Stanga.Afisare();
            Console.Write(" + ");
            Dreapta.Afisare();
            Console.Write(")");
        }

        public override Expresie Derivare(string variabila)
        {
            // (a + b)' = a' + b'
            return new Adunare(Stanga.Derivare(variabila), Dreapta.Derivare(variabila));
        }
    }
}
