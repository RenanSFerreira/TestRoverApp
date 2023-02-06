using TestRoverApp.Model;

namespace TestRoverApp.Utils
{
    public static class NavigationHelper
    {
        private static List<char> Compass = new char[] { 'N', 'E', 'S', 'W' }.ToList();

        public static char TurnRight(char heading)
        {
            var index = Compass.IndexOf(heading);
            index++;
            index = index % Compass.Count;

            return Compass[index];
        }

        public static char TurnLeft(char heading)
        {
            var index = Compass.IndexOf(heading);
            index--;
            if (index < 0)
            {
                index = Compass.Count - 1;
            }

            return Compass[index];
        }

        public static HoverPosition Move(HoverPosition position)
        {
            switch (position.Heading)
            {
                case 'N':
                    return new HoverPosition(position.X, position.Y + 1, position.Heading);
                case 'E':
                    return new HoverPosition(position.X + 1, position.Y, position.Heading);
                case 'S':
                    return new HoverPosition(position.X, position.Y - 1, position.Heading);
                case 'W':
                    return new HoverPosition(position.X - 1, position.Y, position.Heading);
                default:
                    return position;
            }
        }
    }
}
