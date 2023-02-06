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
        [InlineData('N', 'W')]
        [InlineData('W', 'S')]
        [InlineData('S', 'E')]
        [InlineData('E', 'N')]
        public void MoveReturnTheExpectedHoverPosition(char input, char expectedOutput)
        {
            Assert.Equal(expectedOutput, NavigationHelper.TurnLeft(input));
        }
    }
}
