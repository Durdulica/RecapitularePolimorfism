using Recapitulare.Models;

internal class Program
{
    private static void Main()
    {
        // Construim desenul din imaginea din enunt: eticheta + dreptunghi + linie + cerc
        var eticheta = new Eticheta(new Punct(0, 0), new Punct(4, 2), "Text");
        var dreptunghi = new Dreptunghi(new Punct(0, 4), new Punct(6, 8));
        var linie = new Linie(new Punct(6, 6), new Punct(10, 6));
        var cerc = new Cerc(new Punct(12, 6), 2);

        var desen = new Desen(new Figura[] { eticheta, dreptunghi, linie, cerc });

        Console.WriteLine(">>> Desenul original");
        desen.Afisare();

        Console.WriteLine("\n>>> Translatare cu (100, 50)");
        desen.Translatare(100, 50);
        desen.Afisare();

        // Demo critic: duplicam, apoi mutam DOAR originalul.
        // Daca Duplicare ar fi shallow copy, copia s-ar muta odata cu originalul.
        Console.WriteLine("\n>>> Duplicam desenul, apoi mutam DOAR originalul inapoi");
        Figura copie = desen.Duplicare();
        desen.Translatare(-100, -50);

        Console.WriteLine("\nOriginalul (mutat inapoi la coordonatele initiale):");
        desen.Afisare();

        Console.WriteLine("\nCopia (a ramas la (100, 50) - dovedind ca duplicarea a fost completa):");
        copie.Afisare();
    }
}
