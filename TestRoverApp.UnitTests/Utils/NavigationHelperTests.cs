using TestRoverApp.Model;
using TestRoverApp.Utils;

namespace TestRoverApp.UnitTests.Utils
{
    public class NavigationHelperTests
    {
        [Theory]
        [InlineData('N', 'E')]
        [InlineData('E', 'S')]
        [InlineData('S', 'W')]
        [InlineData('W', 'N')]
        public void TurnRightShouldReturnTheExpectedChar(char input, char expectedOutput)
        {
            Assert.Equal(NavigationHelper.TurnRight(input), expectedOutput);
        }

        [Theory]
        [InlineData('N', 'W')]
        [InlineData('W', 'S')]
        [InlineData('S', 'E')]
        [InlineData('E', 'N')]
        public void TurnLetfShouldReturnTheExpectedChar(char input, char expectedOutput)
        {
            Assert.Equal(expectedOutput, NavigationHelper.TurnLeft(input));
        }

        [Theory]
        [InlineData(1, 2, 'N', 1, 3)]
        [InlineData(1, 2, 'E', 2, 2)]
        [InlineData(1, 2, 'S', 1, 1)]
        [InlineData(1, 2, 'W', 0, 2)]
        public void MoveReturnTheExpectedHoverPosition(int x, int y, char heading, int x2, int y2)
        {
            Coordenate c = new Coordenate(5, 5);
            Position initialPosition = new Position(x, y, heading);
            Position expectedPosition = new Position(x2, y2, heading);

            Assert.Equivalent(expectedPosition, NavigationHelper.Move(initialPosition, c));
        }
    }
}
