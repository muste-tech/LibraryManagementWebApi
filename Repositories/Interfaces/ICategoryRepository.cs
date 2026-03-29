using System.ComponentModel;
using LibraryProject.Model;

namespace LibraryProject.Repositories.Interfaces
{

    public interface ICategoryRepository
    {
        Task <IEnumerable<Category>> GetAllCategoriesAsync ();
        Task AddCategory (Category category);
        void UpdateCategory (Catogory catogory);
        void DeleteCategory (Category category);
        Task SaveChangesAsync();
    }
}