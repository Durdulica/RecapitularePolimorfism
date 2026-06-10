namespace Expresii.Models
{
    public class Impartire : Expresie
    {
        public Expresie Stanga { get; set; }
        public Expresie Dreapta {  get; set; }

        public Impartire(Expresie stanga, Expresie dreapta)
        {
            Stanga = stanga;
            Dreapta = dreapta;
        }

        public override double Evaluare(Context ctx)
        {
            double val = Dreapta.Evaluare(ctx);
            if (val == 0) {
                throw new ArgumentException("Division by 0");
            }

            return Stanga.Evaluare(ctx) / val;
        }

        public override void Afisare()
        {
            Stanga.Afisare();
            Console.Write(" / ");
            Dreapta.Afisare();
        }

        public override Expresie Derivare(string variabila)
        {

            Scadere scadere = new Scadere(new Inmultire(Stanga.Derivare(variabila), Dreapta)
                                        , new Inmultire(Stanga, Dreapta.Derivare(variabila)));
            Inmultire inmultire = new Inmultire(Dreapta,Dreapta);

            return new Impartire(scadere, inmultire);
        }
    }
}
