using TestRoverApp.Interfaces;
using TestRoverApp.Model;
using TestRoverApp.Utils;

namespace TestRoverApp.Services
{
    public class HoverService: IHoverService
    {
        public Coordenate? PlateauUpperRight;
        public List<Hover> Hovers { get; set; } = new List<Hover>();

        public void GetFileInformation(string[] lines)
        {
            if (lines.Length <= 0)
                throw new ArgumentException("There is no lines to read.");

            if (lines.Length == 1)
                throw new ArgumentException("There is no hovers.");

            if (lines.Length > 1 && lines.Length % 2 == 0)
                throw new ArgumentException("Invalid input number of lines");

            var plateau = lines[0].Split(' ');

            if (plateau.Length != 2)
                throw new ArgumentException("Invalid plateau input");

            int plateauX = 0;
            if(!int.TryParse(plateau[0], out plateauX))
                throw new ArgumentException("Invalid plateau X input");

            int plateauY = 0;
            if (!int.TryParse(plateau[1], out plateauY))
                throw new ArgumentException("Invalid plateau Y input");

            PlateauUpperRight = new Coordenate(plateauX, plateauY);

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

        public string GetOutput()
        {
            string output = string.Empty;

            foreach (var hover in Hovers)
            {
                var lastPosition = hover.Tracking.Last();
                output += $"{lastPosition.X} {lastPosition.Y} {lastPosition.Heading}\n";
            }

            return output;
        }

        private Position GetHoverInitialPosition(string line)
        {
            var hoverPositionString = line.Split(' ');
            if (hoverPositionString.Length != 3)
                throw new ArgumentException("Invalid hover input");
            
            int hoverPositionX = 0;
            if (!int.TryParse(hoverPositionString[0], out hoverPositionX))
                throw new ArgumentException("Invalid hover X input");

            int hoverPositionY = 0;
            if (!int.TryParse(hoverPositionString[1], out hoverPositionY))
                throw new ArgumentException("Invalid hover Y input");

            var hoverPositionHeading = hoverPositionString[2][0];

            var hoverPosition = new Position(hoverPositionX, hoverPositionY, hoverPositionHeading);

            return hoverPosition;
        }

        private void ExecuteInstructions(Hover hover)
        {
            var actualPosition = hover.Tracking.First();
            char auxHeading;
            Position newPosition;

            foreach (var instruction in hover.Instructions)
            {
                switch (instruction)
                {
                    case 'L':
                        auxHeading = NavigationHelper.TurnLeft(actualPosition.Heading);
                        newPosition = new Position(actualPosition.X, actualPosition.Y, auxHeading);
                        hover.Tracking.Add(newPosition);
                        actualPosition = newPosition;
                        break;
                    case 'R':
                        auxHeading = NavigationHelper.TurnRight(actualPosition.Heading);
                        newPosition = new Position(actualPosition.X, actualPosition.Y, auxHeading);
                        hover.Tracking.Add(newPosition);
                        actualPosition = newPosition;
                        break;
                    case 'M':
                        newPosition = NavigationHelper.Move(actualPosition, PlateauUpperRight);
                        hover.Tracking.Add(newPosition);
                        actualPosition = newPosition;
                        break;
                    default:
                        throw new ArgumentException("Invalid instruction");
                }
            }
        }
    }
}
