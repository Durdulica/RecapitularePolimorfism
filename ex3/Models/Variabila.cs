namespace Expresii.Models
{
    public class Variabila : Expresie
    {
        public string Nume { get; set; }

        public Variabila(string nume)
        {
            Nume = nume;
        }

        public override double Evaluare(Context ctx)
        {
            // Hint: ctx.GetValoare(Nume)
            throw new NotImplementedException();
        }

        public override void Afisare()
        {
            throw new NotImplementedException();
        }

        public override Expresie Derivare(string variabila)
        {
            // Hint: daca Nume == variabila, derivata e 1. Altfel 0.
            throw new NotImplementedException();
        }
    }
}
