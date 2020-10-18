using System.Collections.Generic;
using Euromonitor.Models.General;
using Euromonitor.Models.Requests;
using Euromonitor.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Euromonitor.Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [Authorize]
        [HttpGet("getbooks")]
        public List<Book> GetBooks()
        {
            return _bookService.GetBooks();
        }

        [Authorize]
        [HttpPost("checkoutbook")]
        public IActionResult CheckOutBook(BookRequest model)
        {
            var response = _bookService.CheckOutBook(model);

            if (response == 0)
                return BadRequest(new { message = "Error checking out book" });

            return Ok(response);
        }

        [Authorize]
        [HttpPost("checkinbook")]
        public IActionResult CheckInBook(BookRequest model)
        {
            var response = _bookService.CheckInBook(model);

            if (response == 0)
                return BadRequest(new { message = "Error checking in book" });

            return Ok(response);
        }
    }
}
