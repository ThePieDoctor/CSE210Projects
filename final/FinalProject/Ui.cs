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
                        DoAddPatron();
                        break;
                    case "6":
                        DoAddBook();
                        break;
                    case "7":
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
            Console.WriteLine("5. Add Patron");
            Console.WriteLine("6. Add Book");
            Console.WriteLine("7. Quit");
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

        private void DoAddPatron()
        {
            Console.WriteLine("\n--- Add New Patron ---");
            string name = GetInput("Enter the patron's name: ");
            string id = GetInput("Enter a unique patron ID (e.g., p123): ");

            bool added = _library.AddPatron(name, id);
            if (added)
            {
                Console.WriteLine($"Patron '{name}' (ID: {id}) added successfully.");
            }
            else
            {
                Console.WriteLine("A patron with that ID already exists. Try a different ID.");
            }
        }

        private void DoAddBook()
        {
            Console.WriteLine("\n--- Add New Book ---");
            string id = GetInput("Enter the Book ID (e.g., b010): ");
            string title = GetInput("Enter the book title: ");
            string author = GetInput("Enter the author: ");

            Console.WriteLine("Genres: 0=Fiction, 1=NonFiction, 2=SciFi, 3=Fantasy, 4=Mystery");
            string genreInput = GetInput("Enter genre number: ");
            if (!int.TryParse(genreInput, out int genreVal) || genreVal < 0 || genreVal > 4)
            {
                Console.WriteLine("Invalid genre. Book not added.");
                return;
            }

            var genre = (BookGenre)genreVal;
            bool added = _library.AddBook(id, title, author, genre);
            if (added)
            {
                Console.WriteLine($"Book '{title}' (ID: {id}) added successfully.");
            }
            else
            {
                Console.WriteLine("A book with that ID already exists. Try a different ID.");
            }
        }
    }
}