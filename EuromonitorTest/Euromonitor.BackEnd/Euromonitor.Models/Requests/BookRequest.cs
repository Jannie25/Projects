using System.ComponentModel.DataAnnotations;

namespace Euromonitor.Models.Requests
{
    public class BookRequest
    {
        [Required]
        public int BookId { get; set; }
        [Required]
        public int CheckOutUserId { get; set; }
        [Required]
        public string CheckOutUserName { get; set; }
    }
}