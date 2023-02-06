namespace TestRoverApp.Interfaces
{
    public interface IHoverService
    {
        void GetFileInformation(string[] lines);

        void ExecuteInstructions();

        string GetOutput();

    }
}
