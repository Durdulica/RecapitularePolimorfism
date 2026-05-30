namespace Recapitulare.Models
{
    public class Linie : Figura
    {
        Punct a, b;

        public Linie(Punct a, Punct b)
        {
            this.a = a;
            this.b = b;
        }

        public override void Afisare()
        {
            a.Afisare();
            Console.Write(" ");
            b.Afisare();
        }

        public override void Translatare(int dx, int dy)
        {
            a.Translatare(dx, dy);
            b.Translatare(dx, dy);
        }

        public override Figura Duplicare()
        {
            return new Linie(a,b);
        }
    }
}
