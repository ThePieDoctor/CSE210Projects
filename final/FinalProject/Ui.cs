namespace LibraryManagementSystem.UI
{
    using LibraryManagementSystem.Core;
    using LibraryManagementSystem.Models;

    public class ConsoleUI
    {
        private readonly Library _library;

        public ConsoleUI(Library library)
        {
            _library = library;
        }
        public void StartProgram()
        {
            bool running = true;
            while (running)
            {
                ShowMenu();
                string choice = GetInput("Enter your choice: ");

                switch (choice)
                {
                    case "1":
                        DoViewCatalog();
                        break;
                    case "2":
                        DoCheckOutBook();
                        break;
                    case "3":
                        DoReturnBook();
                        break;
                    case "4":
                        DoViewAccountStatus();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (running)
                {
                    _library.SaveData();
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Action complete. Data saved. Press Enter to continue...");
                    Console.ReadLine();
                }
            }
            Console.WriteLine("Thank you for using the Library Management System!");
        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Library Management System ===");
            Console.WriteLine("1. View Book Catalog");
            Console.WriteLine("2. Check Out Book");
            Console.WriteLine("3. Return Book");
            Console.WriteLine("4. View My Account Status");
            Console.WriteLine("5. Quit");
        }

        private string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? "";
        }


        private void DoViewCatalog()
        {
            Console.WriteLine("\n--- Book Catalog ---");
            var catalog = _library.GetCatalog();
            if (catalog.Count == 0)
            {
                Console.WriteLine("The catalog is empty.");
            }
            else
            {
                foreach (var book in catalog)
                {
                    if (book.IsAvailable())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.WriteLine(book.GetDetailsString());

                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        private void DoCheckOutBook()
        {
            Console.WriteLine("\n--- Check Out Book ---");
            string pID = GetInput("Enter your Patron ID (e.g., p100): ");
            string bID = GetInput("Enter the Book ID (e.g., b001): ");
            _library.CheckOutBook(pID, bID);
        }

        private void DoReturnBook()
        {
            Console.WriteLine("\n--- Return Book ---");
            string pID = GetInput("Enter your Patron ID: ");
            string bID = GetInput("Enter the Book ID you are returning: ");
            _library.ReturnBook(pID, bID);
        }

        private void DoViewAccountStatus()
        {
            Console.WriteLine("\n--- View Account Status ---");
            string pID = GetInput("Enter your Patron ID: ");
            Patron? patron = _library.GetPatron(pID);

            if (patron == null)
            {
                Console.WriteLine("Patron ID not found.");
                return;
            }

            Console.WriteLine(patron.GetDetailsString());
            
            Console.WriteLine("Checked out books:");
            var bookIDs = patron.GetCheckedOutBookIDs();

            if (bookIDs.Count == 0)
            {
                Console.WriteLine("  None.");
            }
            else
            {
                foreach (string bID in bookIDs)
                {
                    var book = _library.GetCatalog().Find(b => b.ItemID == bID);
                    Console.WriteLine($"  - {book?.Title ?? "Unknown Book"} (ID: {bID})");
                }
            }
        }
    }
}