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
            throw new NotImplementedException();
        }

        public override void Afisare()
        {
            throw new NotImplementedException();
        }

        public override Expresie Derivare(string variabila)
        {
            // Regula produsului: (a * b)' = a' * b + a * b'
            // Atentie: trebuie sa construiesti un arbore Adunare(Inmultire(...), Inmultire(...))
            throw new NotImplementedException();
        }
    }
}
