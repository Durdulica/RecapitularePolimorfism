namespace Expresii.Models
{
    public class Constanta : Expresie
    {
        public double Valoare { get; set; }

        public Constanta(double valoare)
        {
            Valoare = valoare;
        }

        public override double Evaluare(Context ctx)
        {
            return Valoare;
        }

        public override void Afisare()
        {
            Console.Write(Valoare);
        }

        public override Expresie Derivare(string variabila)
        {
            // Hint: derivata unei constante e 0 (deci o noua Constanta(0)).

            return new Constanta(0);
        }
    }
}
