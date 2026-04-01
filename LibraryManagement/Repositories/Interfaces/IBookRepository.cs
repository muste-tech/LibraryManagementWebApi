using LibraryProject.Model;

namespace LibraryProject.Repositories.Interfaces 
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task <Book> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);
        void UpdateBook (Book book);
        void DeleteBook (Book book);
        Task SaveChangesAsync();


    }
}