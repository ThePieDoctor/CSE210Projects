namespace LibraryManagementSystem.Models
{
    public abstract class LibraryItem
    {
        public string ItemID { get; set; }

        public LibraryItem()
        {
            ItemID = "default-item-id";
        }

        public LibraryItem(string itemID)
        {
            ItemID = itemID;
        }
        public abstract decimal CalculateLateFeeRate();
    }
}