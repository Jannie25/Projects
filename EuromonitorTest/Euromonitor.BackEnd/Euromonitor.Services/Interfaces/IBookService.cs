using Euromonitor.Models.General;
using Euromonitor.Models.Requests;
using System.Collections.Generic;

namespace Euromonitor.Services.Interfaces
{
    public interface IBookService
    {
        List<Book> GetBooks();
        int CheckOutBook(BookRequest model);
        int CheckInBook(BookRequest model);

    }
}
