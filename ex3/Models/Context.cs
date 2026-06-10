namespace Expresii.Models
{
    public class Context
    {
        public string[] Nume { get; set; }
        public double[] Valori { get; set; }

        public Context()
        {
            Nume = new string[0];
            Valori = new double[0];
        }

        public void Seteaza(string nume, double valoare)
        {
            // TODO: daca numele exista deja in array, doar actualizeaza Valori[i].
            // Altfel, redimensioneaza ambele array-uri si adauga la final.

            for(int i = 0; i < Nume.Length; i++)
            {
                if (Nume[i] == nume)
                {
                    Valori[i] = valoare;
                    return;
                }
            }

            string[] numeTemp = new string[Nume.Length + 1];
            double[] valoriTemp = new double[Valori.Length + 1];

            numeTemp[numeTemp.Length - 1] = nume;
            valoriTemp[valoriTemp.Length - 1] = valoare;

            Nume = numeTemp;
            Valori = valoriTemp;
        }

        public double GetValoare(string nume)
        {
            // TODO: cautare liniara in Nume. Daca gasesti, returneaza Valori[i].
            // Daca nu, arunca ArgumentException cu mesaj englez.
            for (int i = 0; i < Nume.Length; i++)
            {
                if (Nume[i] == nume)
                {
                    return Valori[i];
                }
            }

            throw new ArgumentException("Variabila nu este cunoscuta");
        }
    }
}
