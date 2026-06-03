namespace Recapitulare.Models
{
    public class Punct : Figura
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Punct() { }

        public Punct(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override void Afisare()
        {
            Console.Write("(" + X + "," + Y + ")");
        }

        public override void Translatare(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }

        public override Figura Duplicare()
        {
            return new Punct(X, Y);
        }
    }
}
