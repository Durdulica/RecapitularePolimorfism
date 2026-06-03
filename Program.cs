using Recapitulare;
using Recapitulare.Models;

internal class Program
{
    public static void Main()
    {
        Desen desen = new Desen();
        Punct a = new Punct(1,1);
        Punct b = new Punct(2,2);

        Eticheta linie = new(a, b, "test");

        desen.CreazaFigura(linie);
        desen.AfisareFiguri();
    }
}