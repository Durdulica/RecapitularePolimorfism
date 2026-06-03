namespace Recapitulare.Models
{
    // Clasa de baza pentru toate figurile geometrice. Orice clasa derivata
    // trebuie sa implementeze Afisare, Translatare si Duplicare.
    public abstract class Figura
    {
        public abstract void Afisare();
        public abstract void Translatare(int dx, int dy);
        public abstract Figura Duplicare();
    }
}
