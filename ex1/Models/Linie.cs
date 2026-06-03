namespace Recapitulare.Models
{
    public class Linie : Figura
    {
        public Punct A { get; set; }
        public Punct B { get; set; }

        public Linie(Punct a, Punct b)
        {
            A = a;
            B = b;
        }

        public override void Afisare()
        {
            Console.Write("Linie: ");
            A.Afisare();
            Console.Write(" - ");
            B.Afisare();
        }

        public override void Translatare(int dx, int dy)
        {
            A.Translatare(dx, dy);
            B.Translatare(dx, dy);
        }

        public override Figura Duplicare()
        {
            // clonam recursiv punctele, altfel originalul si copia ar imparti aceleasi obiecte Punct
            return new Linie((Punct)A.Duplicare(), (Punct)B.Duplicare());
        }
    }
}
