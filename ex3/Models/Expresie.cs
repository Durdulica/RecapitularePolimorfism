namespace Expresii.Models
{
    public abstract class Expresie
    {
        public abstract double Evaluare(Context ctx);
        public abstract void Afisare();
        public abstract Expresie Derivare(string variabila);
    }
}
