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
            return ctx.GetValoare(Nume);
        }

        public override void Afisare()
        {
            Console.Write(Nume);
        }

        public override Expresie Derivare(string variabila)
        {
            // Hint: daca Nume == variabila, derivata e 1. Altfel 0.

            if (Nume == variabila) {

                return new Constanta(1);
            }

            return new Constanta(0);
        }
    }
}
