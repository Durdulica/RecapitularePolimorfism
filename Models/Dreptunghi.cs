namespace Recapitulare.Models
{
    public class Dreptunghi : Figura
    {
        public Punct StSus { get; set; } = new Punct();
        public Punct DrJos { get; set; } = new Punct();

        public Dreptunghi(Punct stSus, Punct drJos)
        {
            StSus = stSus;
            DrJos = drJos;
        }

        public override void Afisare()
        {
            StSus.Afisare();
            Console.Write(" ");
            DrJos.Afisare();
        }

        public override void Translatare(int dx, int dy)
        {
            StSus.Translatare(dx, dy);
            DrJos.Translatare(dx, dy);
        }

        public override Figura Duplicare()
        {
            return new Dreptunghi(StSus, DrJos);
        }
    }
}