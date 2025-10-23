using LibraryManagementSystem.Services;
using LibraryManagementSystem.UI;
using LibraryManagementSystem.Core;

public class Program
{
    public static void Main(string[] args)
    {
        string dataFilePath = "library_data.json";

        IDataService dataService = new FileDataService(dataFilePath);

        Library library = new Library(dataService);

        ConsoleUI ui = new ConsoleUI(library);

        ui.StartProgram();
    }
}