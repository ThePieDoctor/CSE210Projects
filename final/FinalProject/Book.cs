namespace LibraryManagementSystem.Models
{
    public enum BookGenre
    {
        Fiction,
        NonFiction,
        SciFi,
        Fantasy,
        Mystery
    }

    public class Book : LibraryItem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public BookGenre Genre { get; set; }
        private bool _isAvailable;

        public Book() : base("default-book-id") 
        {
            Title = "Unknown";
            Author = "Unknown";
            Genre = BookGenre.Fiction;
            _isAvailable = false;
        }

        public Book(string itemID, string title, string author, BookGenre genre) : base(itemID)
        {
            Title = title;
            Author = author;
            Genre = genre;
            _isAvailable = true;
        }

        public bool IsAvailable()
        {
            return _isAvailable;
        }

        public void CheckOut()
        {
            _isAvailable = false;
        }

        public void Return()
        {
            _isAvailable = true;
        }

        public override decimal CalculateLateFeeRate()
        {

            return 0.25m; 
        }

        public string GetDetailsString()
        {
            string availability = _isAvailable ? "Available" : "Checked Out";
            return $"[{ItemID}] '{Title}' by {Author} ({Genre}) - {availability}";
        }
    }
}