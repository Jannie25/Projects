namespace Euromonitor.Models.General
{
    public class Book
    {
        public int BookId { get; }
        public string Name { get; set; }
        public string Text { get; set; }
        public double PurchasePrice { get; set; }
        public int CheckOutUserId { get; set; }
        public string CheckOutUserName { get; set; }
    }
}
