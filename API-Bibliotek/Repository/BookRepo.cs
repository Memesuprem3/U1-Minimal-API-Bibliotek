using API_Bibliotek.Data;
using API_Bibliotek.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Bibliotek.Serviceis
{
    public class BookRepo : IbookRepo
    {
        private readonly AppDbContext _appDbContext;

        public BookRepo(AppDbContext context)
        {
            _appDbContext = context;
        }

        public async Task AddBookAsync(Book book)
        {
            _appDbContext.Books.Add(book);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _appDbContext.Books.FindAsync(id);
            if (book != null)
            {
                _appDbContext.Books.Remove(book);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _appDbContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _appDbContext.Books.FindAsync(id);
        }

        public async Task<Book> GetBookByTitleAsync(string title) // Ny metod
        {
            return await _appDbContext.Books.FirstOrDefaultAsync(b => b.Title == title);
        }

        public async Task UpdateBookAsync(Book book)
        {
            _appDbContext.Books.Update(book);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
    
