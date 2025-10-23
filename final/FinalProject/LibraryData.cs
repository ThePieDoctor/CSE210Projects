namespace LibraryManagementSystem.Core
{
    using LibraryManagementSystem.Models;

    public class LibraryData
    {
        public List<Book> Catalog { get; set; } = new List<Book>();
        public List<Patron> Patrons { get; set; } = new List<Patron>();
        public List<Loan> Loans { get; set; } = new List<Loan>();
    }
}