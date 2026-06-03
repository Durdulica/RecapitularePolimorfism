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
            throw new NotImplementedException();
        }

        public override void Afisare(int nivel)
        {
            throw new NotImplementedException();
        }

        public override Element Cauta(string nume)
        {
            throw new NotImplementedException();
        }
    }
}
