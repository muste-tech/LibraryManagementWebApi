using LibraryProject.DTOs;
using System.Runtime.InteropServices;

namespace LibraryProject.Services.Interface
{
    public interface IBorrowService
    {
        Task<IEnumerable<BorrowResponse>> GetAllBorrowedBooksAsync();
        Task<IEnumerable<BorrowResponse>> GetOverdueBooksAsync();

        Task<bool> BorrowBookAsync(BorrowRequest request);
        Task<bool> ReturnBookAsync(int borrowId);
    }
}