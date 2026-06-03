namespace Recapitulare.Models
{
    public class Dreptunghi : Figura
    {
        public Punct StSus { get; set; }
        public Punct DrJos { get; set; }

        public Dreptunghi(Punct stSus, Punct drJos)
        {
            StSus = stSus;
            DrJos = drJos;
        }

        public override void Afisare()
        {
            Console.Write("Dreptunghi: ");
            StSus.Afisare();
            Console.Write(" - ");
            DrJos.Afisare();
        }

        public override void Translatare(int dx, int dy)
        {
            StSus.Translatare(dx, dy);
            DrJos.Translatare(dx, dy);
        }

        public override Figura Duplicare()
        {
            return new Dreptunghi((Punct)StSus.Duplicare(), (Punct)DrJos.Duplicare());
        }
    }
}
