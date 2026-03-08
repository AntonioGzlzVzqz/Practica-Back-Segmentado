using LibreriaApi.DTOs;

public interface IBookService
{
    Task<IEnumerable<BookDTO>> GetBooksAsync();

    Task<BookDTO?> GetBookByIdAsync(int id);

    Task<BookDTO> CreateBookAsync(BookCreateDTO bookCreate);
}