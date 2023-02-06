using TestRoverApp;
using TestRoverApp.Services;

var textFile = ".\\testRover.txt";

string[] lines = File.ReadAllLines(textFile);

var hoverService = new HoverService();

hoverService.GetFileInformation(lines);

hoverService.ExecuteInstructions();

hoverService.PrintOutput();