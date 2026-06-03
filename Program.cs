using Recapitulare.Models;

internal class Program
{
    public static void Main()
    {
        List<Figura> figuri = new();
        
        Punct a = new Punct(1,1);
        Punct b = new Punct(2,2);
        Eticheta eticheta = new(a, b, "test");

        figuri.Add(a);
        figuri.Add(b);
        figuri.Add(eticheta);

        Desen desen = new Desen(figuri);

        desen.Afisare();
    }
}