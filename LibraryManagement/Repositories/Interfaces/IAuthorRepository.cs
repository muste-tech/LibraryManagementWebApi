using LibraryProject.Model;
 
namespace LibraryProject.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        Task <IEnumerable<Author>> GetAllAuthorsAsync();
        Task <Author> GetAuthorByIdAsync (int id) ;
        Task AddAuthorAsync(Author author);
        void UpdateAuthor (Author author);
        void DeleteAuthor (Author author);
        Task SaveChangesAsync();
    }
}