using LibraryProject.DTOs;
using LibraryProject.Model;
using LibraryProject.Repositories.Interfaces;
using LibraryProject.Services.Interface;

namespace LibraryProject.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync()
        {
            var categories = await _repo.GetAllCategoriesAsync();

            return categories.Select(c => new CategoryResponse
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            });
        }

       public async Task<CategoryResponse?> GetCategoryByIdAsync(int id)
        {
            var c = await _repo.GetCategoryByIdAsync(id);
            if (c == null) return null;

            return new CategoryResponse
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            };
        }
        public async Task<CategoryResponse> AddCategoryAsync(CreateCategoryRequest request)
        {
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description
            };

            await _repo.AddCategoryAsync(category);
            await _repo.SaveChangesAsync();

            return new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        public async Task<bool> UpdateCategoryAsync(int id, UpdateCategoryRequest request)
        {
            var category = await _repo.GetCategoryByIdAsync(id);
            if (category == null) return false;

            category.Name = request.Name;
            category.Description = request.Description;

            _repo.UpdateCategory(category);
            await _repo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _repo.GetCategoryByIdAsync(id);
            if (category == null) return false;

            _repo.DeleteCategory(category);
            await _repo.SaveChangesAsync();

            return true;
        }
    }
}