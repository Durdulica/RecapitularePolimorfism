namespace Recapitulare.Models
{
    public class Cerc : Figura
    {
        public Punct a { get; set; } = new();
        public int raza { get; set; }

        public Cerc(int x, int y, int raza)
        {
            a.x = x;
            a.y = y;
            Raza = raza;
        }

        public int Raza
        {
            get { return raza; }
            set
            {
                if(raza < 0)
                {
                    throw new ArgumentException("Raza nu poate fi negativa");
                }
                raza = value;
            }
        }

        public override void Afisare()
        {
            Console.Write("Cerc: ");
            a.Afisare();
            Console.Write(", raza: " + Raza);
        }

        public override void Translatare(int dx, int dy)
        {
            a.Translatare(dx, dy);
        }

        public override Figura Duplicare()
        {
            return new Cerc(a.x, a.y, Raza);
        }
    }
}