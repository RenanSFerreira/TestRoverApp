namespace TestRoverApp.Model
{
    public class Coordenate
    {
        public Coordenate(int x, int y)
        {
            if (x < 0)
                throw new ArgumentException("Coordenate X can't be negative");

            if (y < 0)
                throw new ArgumentException("Coordenate Y can't be negative");

            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
