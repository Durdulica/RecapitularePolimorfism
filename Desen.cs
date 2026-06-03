using Recapitulare.Models;

namespace Recapitulare
{
    public class Desen
    {
        List<Figura> figuri = new();

        public Figura CreazaFigura(Figura figura)
        {
            figuri.Add(figura);
            return figura;
        }

        public void AfisareFiguri()
        {
            foreach (Figura fig in figuri)
            {
                fig.Afisare();
            }
        }
    }
}
