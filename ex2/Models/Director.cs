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

            Element[] tempElemente = new Element[Elemente.Length + 1];

            tempElemente[tempElemente.Length - 1] = element;
            
            for(int i = 0; i < Elemente.Length; i++)
            {
                tempElemente[i] = Elemente[i];
            }

            Elemente = tempElemente;
        }

        public void Sterge(string nume)
        {
            // TODO: gaseste primul element cu numele dat, apoi creeaza un array nou
            // cu Length-1 si copiaza toate celelalte

            for(int i = 0; i < Elemente.Length; i++)
            {
                if (Elemente[i].Nume == nume)
                {
                    Element[] tempElemente = new Element[Elemente.Length - 1];
                    int cnt = 0;

                    for(int j = 0; j < Elemente.Length; j++)
                    {
                        if(j != i)
                        {
                            tempElemente[cnt++] = Elemente[j];
                        }
                    }

                    Elemente = tempElemente;
                    return;
                }
            }
        }

        public override long DimensiuneTotala()
        {
            // TODO: suma dimensiunilor copiilor (apeleaza DimensiuneTotala() pe fiecare)
            long dim = 0;

            for(int i = 0; i < Elemente.Length; i++)
            {
                dim += Elemente[i].DimensiuneTotala();
            }

            return dim;
        }

        public override void Afisare(int nivel)
        {
            // TODO: afiseaza directorul curent cu indentarea data, apoi apeleaza
            // Afisare(nivel + 1) pe fiecare copil
            int aux = nivel;
            while(aux > 0)
            {
                Console.Write(" ");
                aux--;
            }
            nivel += 2;

            Console.WriteLine("[DIR] " + Nume + " (" +  DimensiuneTotala + " bytes)");
            for(int i = 0; i < Elemente.Length; i++)
            {
                Elemente[i].Afisare(nivel);
            }
        }

        public override Element Cauta(string nume)
        {
            // TODO: daca numele directorului curent e cel cautat, returneaza this.
            // Altfel, apeleaza Cauta pe fiecare copil; primul rezultat non-null se returneaza.
            if(Nume == nume)
            {
                return this;
            }

            for(int i = 0; i < Elemente.Length; i++)
            {
                if( Elemente[i].Cauta(nume) != null)
                {
                    return Elemente[i].Cauta(nume);//todo???
                }
            }

            throw new ArgumentException("No element with this name: " + nume);
        }
    }
}
