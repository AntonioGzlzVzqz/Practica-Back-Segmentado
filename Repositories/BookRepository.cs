using LibreriaApi.Data;
using LibreriaApi.Models;
using Microsoft.EntityFrameworkCore;

public class BookRepository : IBookRepository
{
    private readonly LibDbContext _context;

    public BookRepository(LibDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<Book> CreateBook(Book book)
    {
        _context.Books.Add(book);

        await _context.SaveChangesAsync();

        return book;
    }
}