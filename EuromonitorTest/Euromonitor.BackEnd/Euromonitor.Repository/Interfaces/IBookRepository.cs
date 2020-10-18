using Euromonitor.Models.General;
using Euromonitor.Models.Requests;
using System.Collections.Generic;

namespace Euromonitor.Repository.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        int CheckInAndOut(BookRequest model);
    }
}
