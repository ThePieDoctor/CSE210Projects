namespace LibraryManagementSystem.Models
{
    public class Patron : Person
    {
        private List<string> _bookIDsCheckedOut = new List<string>();
        private decimal _totalFines;
        private const int MAX_BOOKS = 5;

        public Patron() : base("Default", "default-id") 
        {
            _totalFines = 0;
        }

        public Patron(string name, string id) : base(name, id)
        {
            _totalFines = 0;
        }

        public bool CanCheckout()
        {
            return _bookIDsCheckedOut.Count < MAX_BOOKS;
        }

        public void AddFine(decimal amount)
        {
            _totalFines += amount;
        }

        public void AddBook(string bookID)
        {
            if (!_bookIDsCheckedOut.Contains(bookID))
            {
                _bookIDsCheckedOut.Add(bookID);
            }
        }

        public void RemoveBook(string bookID)
        {
            _bookIDsCheckedOut.Remove(bookID);
        }

        public List<string> GetCheckedOutBookIDs()
        {
            return _bookIDsCheckedOut;
        }

        public override string GetDetailsString()
        {
            return $"Patron: {Name} (ID: {ID}), Books Checked Out: {_bookIDsCheckedOut.Count}, Total Fines: {_totalFines:C}";
        }
    }
}