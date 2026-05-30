namespace Recapitulare.Models
{
    public class Eticheta : Figura
    {
        public Punct StSus { get; set; } = new Punct();
        public Punct DrJos { get; set; } = new Punct();
        public string Text { get; set; }

        public Eticheta(Punct stSus, Punct drJos, string text)
        {
            StSus = stSus;
            DrJos = drJos;
            Text = text;
        }

        public override void Afisare()
        {
            StSus.Afisare();
            Console.Write("  " + Text + "  ");
            DrJos.Afisare();
        }

        public override void Translatare(int dx, int dy)
        {
            StSus.Translatare(dx, dy);
            DrJos.Translatare(dx, dy);
        }

        public override Figura Duplicare()
        {
            return new Eticheta(StSus, DrJos, Text);
        }

    }
}
