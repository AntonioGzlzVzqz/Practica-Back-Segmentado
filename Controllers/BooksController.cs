using LibreriaApi.Data;
using LibreriaApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookService.GetBooksAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(BookCreateDTO bookCreate)
        {
            var newBook = await _bookService.CreateBookAsync(bookCreate);

            return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
        }
    }
}