namespace Recapitulare.Models
{
    public class Punct
    {
        public Guid Id { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public Punct()
        {
            x = 0;
            y = 0;
        }

        public Punct(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Punct(string text)
        {
            string[] cuv = text.Split(',');
            Id = Guid.Parse(cuv[0]);
            x = int.Parse(cuv[1]);
            y = int.Parse(cuv[2]);
        }

        public override string ToString() {
            return Id + "," + x + "," + y;
        }
    }
}
