namespace Recapitulare.Models
{
    // Un desen este compus din mai multe figuri (poate include si alte desene,
    // pentru ca Desen mosteneste tot Figura - pattern Composite).
    public class Desen : Figura
    {
        public Figura[] Figuri { get; set; }

        public Desen(Figura[] figuri)
        {
            Figuri = figuri;
        }

        public override void Afisare()
        {
            Console.WriteLine("=== Desen ===");
            for (int i = 0; i < Figuri.Length; i++)
            {
                Figuri[i].Afisare();
                Console.WriteLine();
            }
            Console.WriteLine("=============");
        }

        public override void Translatare(int dx, int dy)
        {
            for (int i = 0; i < Figuri.Length; i++)
            {
                Figuri[i].Translatare(dx, dy);
            }
        }

        public override Figura Duplicare()
        {
            Figura[] copie = new Figura[Figuri.Length];
            for (int i = 0; i < Figuri.Length; i++)
            {
                copie[i] = Figuri[i].Duplicare();
            }
            return new Desen(copie);
        }
    }
}
