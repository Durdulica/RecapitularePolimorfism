namespace SistemFisiere.Models
{
    public class Director : Element
    {
        public Element[] Elemente { get; set; }

        public Director(string nume) : base(nume)
        {
            Elemente = new Element[0];
        }

        public void Adauga(Element element)
        {
            // TODO: redimensioneaza array-ul Elemente (creezi unul nou cu Length+1,
            // copiezi vechile referinte, adaugi noua la final)
            throw new NotImplementedException();
        }

        public void Sterge(string nume)
        {
            // TODO: gaseste primul element cu numele dat, apoi creeaza un array nou
            // cu Length-1 si copiaza toate celelalte
            throw new NotImplementedException();
        }

        public override long DimensiuneTotala()
        {
            // TODO: suma dimensiunilor copiilor (apeleaza DimensiuneTotala() pe fiecare)
            throw new NotImplementedException();
        }

        public override void Afisare(int nivel)
        {
            // TODO: afiseaza directorul curent cu indentarea data, apoi apeleaza
            // Afisare(nivel + 1) pe fiecare copil
            throw new NotImplementedException();
        }

        public override Element Cauta(string nume)
        {
            // TODO: daca numele directorului curent e cel cautat, returneaza this.
            // Altfel, apeleaza Cauta pe fiecare copil; primul rezultat non-null se returneaza.
            throw new NotImplementedException();
        }
    }
}
