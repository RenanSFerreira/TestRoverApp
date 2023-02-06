namespace TestRoverApp.Model
{
    public class Hover
    {
        public List<HoverPosition> Tracking { get; set; } = new List<HoverPosition>();

        public string Instructions { get; set; }

        public Hover(HoverPosition startPosition, string instruction)
        {
            Tracking.Add(startPosition);
            Instructions = instruction;
        }
    }
}
