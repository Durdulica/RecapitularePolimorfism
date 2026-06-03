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
            throw new NotImplementedException();
        }

        public override void Afisare()
        {
            throw new NotImplementedException();
        }

        public override Expresie Derivare(string variabila)
        {
            // (a - b)' = a' - b'
            throw new NotImplementedException();
        }
    }
}
