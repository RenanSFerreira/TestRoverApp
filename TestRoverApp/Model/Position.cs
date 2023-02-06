namespace TestRoverApp.Model
{
    public class Position : Coordenate
    {
        private static List<char> ValidHeadings = new char[] { 'N', 'E', 'S', 'W' }.ToList();

        public Position(int x, int y, char heading) : base(x, y)
        {
            if (!ValidHeadings.Contains(heading))
                throw new ArgumentException("Invalid position heading input");
            Heading = heading;
        }

        public char Heading { get; set; }
    }
}
