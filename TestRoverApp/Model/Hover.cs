using System.Drawing;

namespace TestRoverApp.Model
{
    public class Hover
    {
        public List<Position> Tracking { get; set; } = new List<Position>();

        public string Instructions { get; set; }

        public Hover(Position startPosition, string instruction)
        {
            Tracking.Add(startPosition);
            Instructions = instruction;
        }

        public Hover(){} 
    }
}
