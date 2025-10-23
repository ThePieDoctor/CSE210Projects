namespace LibraryManagementSystem.Models
{
    public class Loan
    {
        public string BookID { get; set; }
        public string PatronID { get; set; }
        public DateTime DueDate { get; set; }

        public Loan() 
        {
            BookID = "default";
            PatronID = "default";
            DueDate = DateTime.Now;
        }

        public Loan(string bID, string pID)
        {
            BookID = bID;
            PatronID = pID;
            DueDate = DateTime.Now.AddDays(14);
        }

        public bool IsLate()
        {
            return DateTime.Now > DueDate;
        }

        public int CalculateDaysLate()
        {
            if (!IsLate())
            {
                return 0;
            }
            TimeSpan timeSpan = DateTime.Now - DueDate;
            return (int)Math.Ceiling(timeSpan.TotalDays);
        }
    }
}