using API_Bibliotek.Models;

namespace API_Bibliotek.Serviceis
{
    public interface IbookRepo
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> GetBookByTitleAsync(string title);
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
    }
}
