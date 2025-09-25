using System;
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool isRunning = true;

        Console.WriteLine("Welcome to the Journal Program!");

        while (isRunning)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Load Journal from File");
            Console.WriteLine("4. Save Journal to File");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            Console.WriteLine();
            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Today's Prompt: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToString("MM/dd/yyyy");

                    Entry newEntry = new Entry
                    {
                        _date = date,
                        _prompt = prompt,
                        _response = response
                    };
                    journal.AddEntry(newEntry);
                    Console.WriteLine("Entry added successfully!\n");
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    Console.Write("Enter the filename to load: ");
                    string loadFile = Console.ReadLine();
                    try
                    {
                        journal.LoadFromFile(loadFile);
                        Console.WriteLine($"Journal loaded from '{loadFile}' successfully!\n");
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine($"Error: File '{loadFile}' not found.\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while loading the file: {ex.Message}\n");
                    }
                    break;
                case "4":
                    Console.Write("Enter the filename to save: ");
                    string saveFile = Console.ReadLine();
                     try
                    {
                        journal.SaveToFile(saveFile);
                        Console.WriteLine($"Journal saved to '{saveFile}' successfully!\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while saving the file: {ex.Message}\n");
                    }
                    break;
                case "5":
                    isRunning = false;
                    Console.WriteLine("Goodbye, see you tomorrow.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please enter a number from 1 to 5.\n");
                    break;
            }
        }
    }
}