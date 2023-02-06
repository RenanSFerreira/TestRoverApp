using TestRoverApp.Model;
using TestRoverApp.Services;

namespace TestRoverApp.UnitTests.Services
{
    public class HoverServiceTests
    {
        private readonly HoverService _hoverService;

        public HoverServiceTests()
        {
            _hoverService = new HoverService();
        }

        [Fact]
        public void GetFileInformationShouldFillHoverServiceProperties()
        {
            //Arrange
            var lines = new string[]
            {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };

            var plateauUpperRight = new Coordenate(5, 5);
            var hovers = new List<Hover>
            {
                new Hover(new HoverPosition(1, 2, 'N'),"LMLMLMLMM"),
                new Hover(new HoverPosition(3, 3, 'E'),"MMRMMRMRRM")
            };

            //Act
            _hoverService.GetFileInformation(lines);

            //Assert
            Assert.Equivalent(plateauUpperRight, _hoverService.PlateauUpperRight);
            Assert.Equivalent(hovers, _hoverService.Hovers);
        }

        [Fact]
        public void ExecuteInstructionsShouldFillHoverTracking()
        {
            //Arrange
            var lines = new string[]
            {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };

            var plateauUpperRight = new Coordenate(5, 5);
            var hovers = new List<Hover>
            {
                new Hover(new HoverPosition(1, 2, 'N'),"LMLMLMLMM")
                {
                    Tracking = new List<HoverPosition>
                    {
                        new HoverPosition(1, 2, 'N'),
                        new HoverPosition(1, 2, 'W'),
                        new HoverPosition(0, 2, 'W'),
                        new HoverPosition(0, 2, 'S'),
                        new HoverPosition(0, 1, 'S'),
                        new HoverPosition(0, 1, 'E'),
                        new HoverPosition(1, 1, 'E'),
                        new HoverPosition(1, 1, 'N'),
                        new HoverPosition(1, 2, 'N'),
                        new HoverPosition(1, 3, 'N')
                    }
                },
                new Hover(new HoverPosition(3, 3, 'E'),"MMRMMRMRRM")
                {
                    Tracking = new List<HoverPosition>
                    {
                        new HoverPosition(3, 3, 'E'),
                        new HoverPosition(4, 3, 'E'),
                        new HoverPosition(5, 3, 'E'),
                        new HoverPosition(5, 3, 'S'),
                        new HoverPosition(5, 2, 'S'),
                        new HoverPosition(5, 1, 'S'),
                        new HoverPosition(5, 1, 'W'),
                        new HoverPosition(4, 1, 'W'),
                        new HoverPosition(4, 1, 'N'),
                        new HoverPosition(4, 1, 'E'),
                        new HoverPosition(5, 1, 'E')
                    }
                },
            };

            //Act
            _hoverService.ExecuteInstructions();

            //Assert
            Assert.Equivalent(hovers, _hoverService.Hovers);
        }
    }
}
