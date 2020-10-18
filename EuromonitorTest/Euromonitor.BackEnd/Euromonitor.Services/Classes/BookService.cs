using Euromonitor.Models.General;
using Euromonitor.Models.Requests;
using Euromonitor.Repository.Interfaces;
using Euromonitor.Services.Interfaces;
using System.Collections.Generic;

namespace Euromonitor.Services.Classes
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public int CheckInBook(BookRequest model)
        {
            model.CheckOutUserId = 0;
            model.CheckOutUserName = "";
            return _bookRepository.CheckInAndOut(model);
        }

        public int CheckOutBook(BookRequest model)
        {
            return _bookRepository.CheckInAndOut(model);
        }

        public List<Book> GetBooks()
        {
            return _bookRepository.GetAll();
        }
    }
}