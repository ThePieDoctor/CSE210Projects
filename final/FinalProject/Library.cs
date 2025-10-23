namespace LibraryManagementSystem.Core
{
    using LibraryManagementSystem.Models;
    using LibraryManagementSystem.Services;

    public class Library
    {
        private List<Book> _catalog;
        private List<Patron> _patrons;
        private List<Loan> _loans;

        private readonly IDataService _dataService;
        

        private readonly Fine _fineCalculator;

        public Library(IDataService dataService)
        {
            _dataService = dataService;
            _fineCalculator = new Fine();
            LoadData();
        }

        public void LoadData()
        {
            Console.WriteLine("Loading library data...");
            LibraryData data = _dataService.Load();
            _catalog = data.Catalog;
            _patrons = data.Patrons;
            _loans = data.Loans;

            if (_catalog.Count == 0 && _patrons.Count == 0)
            {
                Console.WriteLine("No data found. Seeding new data...");
                SeedData();
                SaveData();
            }
        }

        public void SaveData()
        {
            Console.WriteLine("Saving library data...");
            LibraryData data = new LibraryData
            {
                Catalog = _catalog,
                Patrons = _patrons,
                Loans = _loans
            };
            _dataService.Save(data);
        }


        public bool CheckOutBook(string pID, string bID)
        {
            Patron? patron = _patrons.Find(p => p.GetID() == pID);
            Book? book = _catalog.Find(b => b.ItemID == bID);

            if (patron == null)
            {
                Console.WriteLine("Error: Patron not found.");
                return false;
            }
            if (book == null)
            {
                Console.WriteLine("Error: Book not found.");
                return false;
            }
            if (!patron.CanCheckout())
            {
                Console.WriteLine("Error: Patron has reached the maximum checkout limit.");
                return false;
            }
            if (!book.IsAvailable())
            {
                Console.WriteLine("Error: Book is currently unavailable.");
                return false;
            }

            book.CheckOut();
            Loan newLoan = new Loan(bID, pID);
            _loans.Add(newLoan);
            patron.AddBook(bID);

            Console.WriteLine($"Success: '{book.Title}' checked out to {patron.Name}.");
            return true;
        }

        public void ReturnBook(string pID, string bID)
        {
            Patron? patron = _patrons.Find(p => p.GetID() == pID);
            Book? book = _catalog.Find(b => b.ItemID == bID);

            Loan? loan = _loans.Find(l => l.BookID == bID && l.PatronID == pID);

            if (patron == null || book == null || loan == null)
            {
                Console.WriteLine("Error: Could not find matching loan record for this return.");
                return;
            }

            book.Return();

            if (loan.IsLate())
            {
                int daysLate = loan.CalculateDaysLate();
                decimal fineAmount = _fineCalculator.CalculateTotalFine(book, daysLate);
                patron.AddFine(fineAmount);
                Console.WriteLine($"Book is {daysLate} days late! A fine of {fineAmount:C} has been added.");
            }

            _loans.Remove(loan);
            patron.RemoveBook(bID);

            Console.WriteLine($"Success: '{book.Title}' returned by {patron.Name}.");
        }

        public List<Book> Search(string title)
        {
            return _catalog.FindAll(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        }

        public List<Book> Search(BookGenre genre)
        {
            return _catalog.FindAll(b => b.Genre == genre);
        }
        public List<Book> GetCatalog()
        {
            return _catalog;
        }

        public Patron? GetPatron(string pID)
        {
            return _patrons.Find(p => p.GetID() == pID);
        }
        private void SeedData()
        {
            _patrons = new List<Patron>
            {
                new Patron("Evan Barrett", "p100"),
                new Patron("Guest", "p001"),
                new Patron("Joseph Smith", "p531")
            };

            _catalog = new List<Book>
            {
                new Book("b001", "Harry Potter and the Sorcerer's Stone", "J.K. Rowling", BookGenre.Fantasy),
                new Book("b002", "The Hobbit", "J.R.R. Tolkien", BookGenre.Fantasy),
                new Book("b003", "Percy Jackson: The Lightning Thief", "Rick Riordan", BookGenre.Fantasy),
                new Book("b004", "Diary of a Wimpy Kid", "Jeff Kinney", BookGenre.Fiction),
                new Book("b005", "The Cat in the Hat", "Dr. Seuss", BookGenre.Fiction),
                new Book("b006", "The Miracle of Forgiveness", "Spencer W. Kimball", BookGenre.NonFiction),
                new Book("b007", "The Book Thief", "Markus Zusak", BookGenre.NonFiction),
                new Book("b008", "The Great Gatsby", "F. Scott Fitzgerald", BookGenre.Fiction),
                new Book("b009", "The Maze Runner", "James Dashner", BookGenre.SciFi),
            };

            _loans = new List<Loan>();
        }
    }
}