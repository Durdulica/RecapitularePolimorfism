namespace Recapitulare.Models
{
    public class Cerc : Figura
    {
        private int raza;

        public Punct Centru { get; set; }

        public int Raza
        {
            get { return raza; }
            set
            {
                // verificam valoarea NOUA (value), nu campul actual
                if (value < 0)
                {
                    throw new ArgumentException("Raza nu poate fi negativa");
                }
                raza = value;
            }
        }

        public Cerc(Punct centru, int raza)
        {
            Centru = centru;
            Raza = raza;
        }

        public override void Afisare()
        {
            Console.Write("Cerc cu centrul in ");
            Centru.Afisare();
            Console.Write(", raza: " + Raza);
        }

        public override void Translatare(int dx, int dy)
        {
            Centru.Translatare(dx, dy);
        }

        public override Figura Duplicare()
        {
            return new Cerc((Punct)Centru.Duplicare(), Raza);
        }
    }
}
