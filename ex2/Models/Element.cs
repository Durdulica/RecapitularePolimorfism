namespace SistemFisiere.Models
{
    public abstract class Element
    {
        public string Nume { get; set; }

        protected Element(string nume)
        {
            Nume = nume;
        }

        public abstract long DimensiuneTotala();
        public abstract void Afisare(int nivel);
        public abstract Element Cauta(string nume);
    }
}
