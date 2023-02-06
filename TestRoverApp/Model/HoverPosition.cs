namespace TestRoverApp.Model
{
    public class HoverPosition : Coordenate
    {
        public HoverPosition(int x, int y, char heading) : base(x, y)
        {
            Heading = heading;
        }

        public char Heading { get; set; }
    }
}
