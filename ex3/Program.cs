using Expresii.Models;

internal class Program
{
    private static void Main()
    {
        // TODO:
        // 1. Construieste expresia  e = (x + 3) * (x - 2)
        //    e = new Inmultire(
        //          new Adunare(new Variabila("x"), new Constanta(3)),
        //          new Scadere(new Variabila("x"), new Constanta(2))
        //        );
        //
        // 2. Afiseaza expresia.
        //
        // 3. Construieste contextul cu x = 5:
        //    var ctx = new Context();
        //    ctx.Seteaza("x", 5);
        //
        // 4. Evalueaza si afiseaza rezultatul (asteptat: 24).
        //
        // 5. Construieste derivata in raport cu x:
        //    var eDerivat = e.Derivare("x");
        //    Afiseaz-o (va fi un arbore stufos, dar matematic echivalent cu 2x + 1).
        //
        // 6. Evalueaza derivata pentru x = 5 (asteptat: 11).


        Inmultire e = new Inmultire(
            new Adunare(new Variabila("x"), new Constanta(3)),
            new Scadere(new Variabila("x"), new Constanta(2))
        );

        e.Afisare();
        Console.WriteLine();

        Context ctx = new Context();
        ctx.Seteaza("x", 5);

        Console.WriteLine(e.Evaluare(ctx));

        Console.WriteLine(e.Derivare("x").Evaluare(ctx));
    }
}