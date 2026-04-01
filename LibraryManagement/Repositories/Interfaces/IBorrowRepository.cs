using LibraryProject.Model;

namespace LibraryProject.Repositories.Interfaces
{
    public interface IBorrowRepository
    {
        Task<IEnumerable<Borrow>> VeiwBorrowedBooks();
        Task<IEnumerable<Borrow>> VeiwOverdueBooks();

        void BorrowBook(Borrow borrow);
        void ReturnBook(Borrow borrow);

        Task SaveChangesAsync();
    }
}