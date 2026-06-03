namespace Recapitulare.Models
{
    public class Eticheta : Dreptunghi
    {
        public string Text { get; set; }

        public Eticheta(Punct stSus, Punct drJos, string text) : base(stSus, drJos)
        {
            Text = text;
        }

        public override void Afisare()
        {
            Console.Write("Eticheta: ");
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
            return new Eticheta((Punct)StSus.Duplicare(), (Punct)DrJos.Duplicare(), Text);
        }

    }
}
