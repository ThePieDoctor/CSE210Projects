namespace LibraryManagementSystem.Models
{
    public class Fine
    {
        public decimal CalculateTotalFine(LibraryItem item, int daysLate)
        {
            return item.CalculateLateFeeRate() * daysLate;
        }
    }
}