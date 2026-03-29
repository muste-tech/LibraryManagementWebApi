using LibraryProject.Model;

namespace LibraryProject.Repositories.Interfaces 
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task <Student> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);
        void UpdateBook (Book book);
        void DeleteBook (Book book);
        Task SaveChangesAsync();


    }
}