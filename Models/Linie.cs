namespace Recapitulare.Models
{
    public class Linie : Punct
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        Punct a, b;

        public Linie(Punct a, Punct b) : base()
        {
            this.a = a;
            this.b = b;
        }
    }
}
