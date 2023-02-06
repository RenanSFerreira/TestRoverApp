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
                new Hover(new Position(1, 2, 'N'),"LMLMLMLMM"),
                new Hover(new Position(3, 3, 'E'),"MMRMMRMRRM")
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

            _hoverService.PlateauUpperRight = new Coordenate(5, 5);
            _hoverService.Hovers = new List<Hover>
            {
                new Hover(new Position(1, 2, 'N'),"LMLMLMLMM"),
                new Hover(new Position(3, 3, 'E'),"MMRMMRMRRM")
            };

            var expectedHovers = new List<Hover>
            {
                new Hover()
                {
                    Instructions = "LMLMLMLMM",
                    Tracking = new List<Position>
                    {
                        new Position(1, 2, 'N'),
                        new Position(1, 2, 'W'),
                        new Position(0, 2, 'W'),
                        new Position(0, 2, 'S'),
                        new Position(0, 1, 'S'),
                        new Position(0, 1, 'E'),
                        new Position(1, 1, 'E'),
                        new Position(1, 1, 'N'),
                        new Position(1, 2, 'N'),
                        new Position(1, 3, 'N')
                    }
                },
                new Hover()
                {
                    Instructions = "MMRMMRMRRM",
                    Tracking = new List<Position>
                    {
                        new Position(3, 3, 'E'),
                        new Position(4, 3, 'E'),
                        new Position(5, 3, 'E'),
                        new Position(5, 3, 'S'),
                        new Position(5, 2, 'S'),
                        new Position(5, 1, 'S'),
                        new Position(5, 1, 'W'),
                        new Position(4, 1, 'W'),
                        new Position(4, 1, 'N'),
                        new Position(4, 1, 'E'),
                        new Position(5, 1, 'E')
                    }
                },
            };

            //Act
            _hoverService.ExecuteInstructions();

            //Assert
            Assert.Equivalent(expectedHovers, _hoverService.Hovers);
        }

        [Fact]
        public void GetOutputShouldReturnString()
        {
            //Arrange
            var expectedOutput = "1 3 N\n5 1 E\n";

            _hoverService.PlateauUpperRight = new Coordenate(5, 5);
            _hoverService.Hovers = new List<Hover>
            {
                new Hover(new Position(1, 2, 'N'),"LMLMLMLMM")
                {
                    Tracking = new List<Position>
                    {
                        new Position(1, 2, 'N'),
                        new Position(1, 2, 'W'),
                        new Position(0, 2, 'W'),
                        new Position(0, 2, 'S'),
                        new Position(0, 1, 'S'),
                        new Position(0, 1, 'E'),
                        new Position(1, 1, 'E'),
                        new Position(1, 1, 'N'),
                        new Position(1, 2, 'N'),
                        new Position(1, 3, 'N')
                    }
                },
                new Hover(new Position(3, 3, 'E'),"MMRMMRMRRM")
                {
                    Tracking = new List<Position>
                    {
                        new Position(3, 3, 'E'),
                        new Position(4, 3, 'E'),
                        new Position(5, 3, 'E'),
                        new Position(5, 3, 'S'),
                        new Position(5, 2, 'S'),
                        new Position(5, 1, 'S'),
                        new Position(5, 1, 'W'),
                        new Position(4, 1, 'W'),
                        new Position(4, 1, 'N'),
                        new Position(4, 1, 'E'),
                        new Position(5, 1, 'E')
                    }
                },
            };


            //Act
            var result = _hoverService.GetOutput();

            //Assert
            Assert.Equivalent(expectedOutput, result);
        }
    }
}
