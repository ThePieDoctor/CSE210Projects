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
        public bool Available { get; set; }

        public Book() : base("default-book-id")
        {
            Title = "Unknown";
            Author = "Unknown";
            Genre = BookGenre.Fiction;
            Available = false;
        }

        public Book(string itemID, string title, string author, BookGenre genre) : base(itemID)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Available = true;
        }

        public bool IsAvailable()
        {
            return Available;
        }

        public void CheckOut()
        {
            Available = false;
        }

        public void Return()
        {
            Available = true;
        }

        public override decimal CalculateLateFeeRate()
        {

            return 0.25m; 
        }

        public string GetDetailsString()
        {
            string availability = Available ? "Available" : "Checked Out";
            return $"[{ItemID}] '{Title}' by {Author} ({Genre}) - {availability}";
        }
    }
}