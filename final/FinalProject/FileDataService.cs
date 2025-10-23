namespace LibraryManagementSystem.Services
{
    using System.IO;
    using System.Text.Json;
    using LibraryManagementSystem.Core;

    public class FileDataService : IDataService
    {
        private readonly string _dataFilePath;


        private static readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true,

            PropertyNameCaseInsensitive = true
        };

        public FileDataService(string dataFilePath)
        {
            _dataFilePath = dataFilePath;
        }

        public void Save(LibraryData data)
        {
            try
            {

                string jsonString = JsonSerializer.Serialize(data, _options);

                File.WriteAllText(_dataFilePath, jsonString);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        public LibraryData Load()
        {

            if (!File.Exists(_dataFilePath))
            {
                return new LibraryData();
            }

            try
            {

                string jsonString = File.ReadAllText(_dataFilePath);

                LibraryData? data = JsonSerializer.Deserialize<LibraryData>(jsonString, _options);
                

                return data ?? new LibraryData();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");

                return new LibraryData();
            }
        }
    }
}