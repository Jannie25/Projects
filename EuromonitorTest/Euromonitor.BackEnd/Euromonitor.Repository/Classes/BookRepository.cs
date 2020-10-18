using Euromonitor.DataHelper.Interfaces;
using Euromonitor.Models.General;
using Euromonitor.Models.Requests;
using Euromonitor.Repository.Interfaces;
using System.Collections.Generic;

namespace Euromonitor.Repository.Classes
{
    public class BookRepository : IBookRepository
    {
        private IDapperService _dapperService;

        public BookRepository(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public int CheckInAndOut(BookRequest model)
        {
            var p = new
            {
                model.BookId,
                model.CheckOutUserId,
                model.CheckOutUserName
            };
            return _dapperService.Execute("uspCheckInAndOutBook", p);
        }

        public List<Book> GetAll()
        {
            return _dapperService.Query<Book>("usp_GetBooks", null);
        }
    }
}
