using System.ComponentModel;
using LibraryProject.Model;

namespace LibraryProject.Repositories.Interfaces
{

    public interface ICategoryRepository
    {
        Task <IEnumerable<Category>> GetAllCategoriesAsync ();
         Task<Category?> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync (Category category);
        void UpdateCategory (Category catogory);
        void DeleteCategory (Category category);
        Task SaveChangesAsync();
    }
}