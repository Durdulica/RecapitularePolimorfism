using SistemFisiere.Models;

internal class Program
{
    private static void Main()
    {
        // TODO: construieste ierarhia:
        //
        // root/
        // ├── docs/
        // │   ├── readme.txt (500 bytes)
        // │   └── notes.txt (300 bytes)
        // └── app.exe (700 bytes)
        //
        // Apoi:
        // 1. Afiseaza dimensiunea totala (1500)
        // 2. Afiseaza ierarhia (cu Afisare(0))
        // 3. Cauta "notes.txt" si afiseaza dimensiunea lui
        // 4. Cauta "inexistent.txt" si trateaza cazul null
        // 5. Sterge "app.exe" si afiseaza din nou ierarhia

        Director root = new Director("root");

        Director dir = new Director("docs");
        Fisier file1 = new Fisier("readme.txt", 500);
        Fisier file2 = new Fisier("notes.txt", 300);
        Fisier file3 = new Fisier("app.exe", 700);
        dir.Adauga(file1);
        dir.Adauga(file2);
        root.Adauga(dir);
        root.Adauga(file3);

        Console.WriteLine(root.DimensiuneTotala());
        root.Afisare(0);
        root.Sterge("app.exe");
        root.Afisare(0);
    }
}
