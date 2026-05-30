namespace Recapitulare.Models
{
     //cuvantul cheie abstract
     // O clasa abstracta nu poate fi instantiata 
     // orice clasa ce mosteneste o clasa abstarcta este obligata sa suprascrie metodele abstracte
     // o clasa abstracta poate contine atat metode concrete cat si metoda abastracte

    public  abstract class Figura
    {
        public abstract void Afisare();
        public abstract void Translatare(int dx, int dy);
        public abstract Figura Duplicare();
    }
}