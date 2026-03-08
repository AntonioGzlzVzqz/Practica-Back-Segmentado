using LibreriaApi.DTOs;
using LibreriaApi.Exceptions;
using LibreriaApi.Models;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository repository)
    {
        _bookRepository = repository;
    }

    public async Task<IEnumerable<BookDTO>> GetBooksAsync()
    {
        var books = await _bookRepository.GetBooksAsync();

        return books.Select(b => new BookDTO
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author
        });

    }

    public async Task<BookDTO?> GetBookByIdAsync(int id)
    {
        var book = await _bookRepository.GetBookByIdAsync(id);

        if(book == null) throw new NotFoundException("No se encontro el libro o no existe");

        return new BookDTO
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author
        };
    }

    public async Task<BookDTO> CreateBookAsync(BookCreateDTO bookCreate)
    {
        var newBook = new Book
        {
            Title = bookCreate.Title,
            Author = bookCreate.Author,
            Stock = bookCreate.Stock
        };

        await _bookRepository.CreateBook(newBook);

        return new BookDTO
        {
            Id = newBook.Id,
            Title = newBook.Title,
            Author = newBook.Author
        };
    }
}