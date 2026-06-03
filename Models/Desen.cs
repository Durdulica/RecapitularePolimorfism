namespace Recapitulare.Models
{
    public class Desen : Figura
    {
        public List<Figura> Figuri{ get; set; }

        public Desen(List<Figura> figuri)
        {
            Figuri = figuri;
        }

        public override void Translatare(int x, int y) {
            foreach(Figura fig in Figuri)
            {
                fig.Translatare(x,y);
            }
        }

        public override Figura Duplicare()
        {
            List<Figura> copie = new List<Figura>();
            foreach(Figura fig in Figuri)
            {
                copie.Add(fig.Duplicare());
            }

            return new Desen(copie);
        }

        public override void Afisare()
        {
            Console.WriteLine("========Desen========");
            foreach (Figura fig in Figuri)
            {
                fig.Afisare();
                Console.WriteLine();
            }
        }


    }
}
