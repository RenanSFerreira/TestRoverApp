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

        public static Position Move(Position position, Coordenate PlateauUpperRight)
        {
            switch (position.Heading)
            {
                case 'N':
                    var newNY = position.Y + 1;
                    if (newNY < 0 || newNY > PlateauUpperRight.Y)
                        throw new Exception("Hover jumping off the plateau");

                    return new Position(position.X, newNY, position.Heading);
                case 'E':
                    var newEX = position.X + 1;
                    if (newEX < 0 || newEX > PlateauUpperRight.X)
                        throw new Exception("Hover jumping off the plateau");

                    return new Position(newEX, position.Y, position.Heading);
                case 'S':
                    var newSY = position.Y - 1;
                    if (newSY < 0 || newSY > PlateauUpperRight.Y)
                        throw new Exception("Hover jumping off the plateau");

                    return new Position(position.X, newSY, position.Heading);
                case 'W':
                    var newWX = position.X - 1;
                    if (newWX < 0 || newWX > PlateauUpperRight.X)
                        throw new Exception("Hover jumping off the plateau");

                    return new Position(newWX, position.Y, position.Heading);
                default:
                    return position;
            }
        }
    }
}
