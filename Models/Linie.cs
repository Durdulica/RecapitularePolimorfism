namespace Recapitulare.Models
{
    public class Linie : Figura
    {
        public Punct a {  get; set; }
        public Punct b { get; set; }

        public Linie(Punct a, Punct b)
        {
            this.a = a;
            this.b = b;
        }

        public override void Afisare()
        {
            Console.Write("Linie: ");
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
