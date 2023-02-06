using TestRoverApp.Model;
using TestRoverApp.Utils;

namespace TestRoverApp.Services
{
    public class HoverService
    {
        public Coordenate? PlateauUpperRight;
        public List<Hover> Hovers { get; set; } = new List<Hover>();

        public void GetFileInformation(string[] lines)
        {
            var plateau = lines[0].Split(' ');
            PlateauUpperRight = new Coordenate(Convert.ToInt32(plateau[0]), Convert.ToInt32(plateau[1]));

            for (int i = 1; i < lines.Length; i++)
            {
                var startPosition = GetHoverInitialPosition(lines[i]);
                i++;
                var instructions = lines[i];
                var hover = new Hover(startPosition, instructions);
                Hovers.Add(hover);
            }
        }

        public void ExecuteInstructions()
        {
            foreach (var hover in Hovers)
            {
                ExecuteInstructions(hover);
            }
        }

        public void PrintOutput()
        {
            string output = string.Empty;

            foreach (var hover in Hovers)
            {
                var lastPosition = hover.Tracking.Last();
                output += $"{lastPosition.X} {lastPosition.Y} {lastPosition.Heading}\n";
            }

            Console.WriteLine(output);
        }

        public void PrintTracking()
        {
            string output = string.Empty;

            foreach (var hover in Hovers)
            {
                foreach (var tracking in hover.Tracking)
                {
                    output += $"{tracking.X} {tracking.Y} {tracking.Heading}\n";
                }
                output += "\n";
            }

            Console.WriteLine(output);
        }

        private HoverPosition GetHoverInitialPosition(string line)
        {
            var hoverPositionString = line.Split(' ');

            var hoverPositionX = Convert.ToInt32(hoverPositionString[0]);
            var hoverPositionY = Convert.ToInt32(hoverPositionString[1]);
            var hoverPositionHeading = hoverPositionString[2][0];

            var hoverPosition = new HoverPosition(hoverPositionX, hoverPositionY, hoverPositionHeading);

            return hoverPosition;
        }

        private void ExecuteInstructions(Hover hover)
        {
            var actualPosition = hover.Tracking.First();
            char auxHeading;
            HoverPosition newPosition;

            foreach (var instruction in hover.Instructions)
            {
                switch (instruction)
                {
                    case 'L':
                        auxHeading = NavigationHelper.TurnLeft(actualPosition.Heading);
                        newPosition = new HoverPosition(actualPosition.X, actualPosition.Y, auxHeading);
                        hover.Tracking.Add(newPosition);
                        actualPosition = newPosition;
                        break;
                    case 'R':
                        auxHeading = NavigationHelper.TurnRight(actualPosition.Heading);
                        newPosition = new HoverPosition(actualPosition.X, actualPosition.Y, auxHeading);
                        hover.Tracking.Add(newPosition);
                        actualPosition = newPosition;
                        break;
                    case 'M':
                        newPosition = NavigationHelper.Move(actualPosition);
                        hover.Tracking.Add(newPosition);
                        actualPosition = newPosition;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
