namespace Recapitulare.Models
{
    public class Cerc : Punct
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Punct a;
        public int raza;

        public Cerc(Punct a, int raza) : base(a.x, a.y)
        {
            Raza = raza;
        }

        public int Raza
        {
            get { return raza; }
            set
            {
                if(raza < 0)
                {
                    throw new ArgumentException("Raza nu poate fi negativa");
                }
                raza = value;
            }
        }
    }
}