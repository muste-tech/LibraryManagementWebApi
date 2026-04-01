using LibraryProject.DTOs;
using System.Runtime.InteropServices;

namespace LibraryProject.Services.Interface
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponse>> GetAllBooksAsync();
        Task<BookResponse?> GetBookByIdAsync(int id);

        Task<BookResponse> AddBookAsync(CreateBookRequest request);

        Task<bool> UpdateBookAsync(int id, UpdateBookRequest request);

        Task<bool> DeleteBookAsync(int id);
    }
}