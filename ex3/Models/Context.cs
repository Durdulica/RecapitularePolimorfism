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
            throw new NotImplementedException();
        }

        public double GetValoare(string nume)
        {
            // TODO: cautare liniara in Nume. Daca gasesti, returneaza Valori[i].
            // Daca nu, arunca ArgumentException cu mesaj englez.
            throw new NotImplementedException();
        }
    }
}
