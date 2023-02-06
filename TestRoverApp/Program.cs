using TestRoverApp.Interfaces;
using TestRoverApp.Services;

try
{
    var textFile = ".\\testRover.txt";

    string[] lines = File.ReadAllLines(textFile);

    IHoverService hoverService = new HoverService();

    hoverService.GetFileInformation(lines);

    hoverService.ExecuteInstructions();

    Console.WriteLine(hoverService.GetOutput());
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();