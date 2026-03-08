using LibreriaApi.Models;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetBooksAsync();

    Task<Book?> GetBookByIdAsync(int id);

    Task<Book> CreateBook(Book book);
}