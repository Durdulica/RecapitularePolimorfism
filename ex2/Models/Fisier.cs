namespace SistemFisiere.Models
{
    public class Fisier : Element
    {
        public long Dimensiune { get; set; }

        public Fisier(string nume, long dimensiune) : base(nume)
        {
            Dimensiune = dimensiune;
        }

        public override long DimensiuneTotala()
        {
            return Dimensiune;
        }

        public override void Afisare(int nivel)
        {
            while(nivel > 0)
            {
                Console.Write(" ");
                nivel--;
            }
            Console.WriteLine("[FILE] " + Nume + " (" + Dimensiune + " bytes)");
        }

        public override Element Cauta(string nume)
        {
            return Nume == nume ? this : null;
        }
    }
}
