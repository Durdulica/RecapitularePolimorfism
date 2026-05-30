namespace Recapitulare.Models
{
    public class Cerc : Punct
    {
        public Punct a;
        public int raza;

        public Cerc(int x, int y, int raza) : base(x,y)
        {
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
            a.Afisare();
            Console.Write(", raza: " + Raza);
        }

        public override void Translatare(int dx, int dy)
        {
            a.Translatare(dx, dy);
        }

        public override Figura Duplicare()
        {
            return new Cerc(x,y,Raza);
        }
    }
}