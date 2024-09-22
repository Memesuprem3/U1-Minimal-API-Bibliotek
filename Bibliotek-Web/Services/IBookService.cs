using API_Bibliotek.Models.DTOs;

namespace Bibliotek_Web.Services
{
    public interface IBookService
    {
        Task<List<BookDTO>> GetAllBooksAsync();
        Task<BookDTO> GetBookByIdAsync(int id);
        Task<bool> CreateBookAsync(CreateBookDTO bookDto);
        Task<bool> UpdateBookAsync(UpdateBookDTO bookDto);
        Task<bool> DeleteBookAsync(int id);
    }
}
