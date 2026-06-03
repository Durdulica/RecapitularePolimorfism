namespace Recapitulare.Models
{
    public class Punct : Figura
    {
        public int x { get; set; }
        public int y { get; set; }

        public Punct()
        {
            x = 0;
            y = 0;
        }

        public Punct(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override void Afisare()
        {
            Console.Write("(" + x + "," + y + ")");
        }

        public override void Translatare(int dx, int dy)
        {
            x += dx;
            y += dy;
        }

        public override Figura Duplicare()
        {
            return new Punct(x, y);
        }
    }
}