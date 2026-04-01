using LibraryProject.DTOs;
using System.Runtime.InteropServices;

namespace LibraryProject.Services.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync();
        Task<CategoryResponse?> GetCategoryByIdAsync(int id);
        Task<CategoryResponse> AddCategoryAsync(CreateCategoryRequest request);
        Task<bool> UpdateCategoryAsync(int id, UpdateCategoryRequest request);
        Task<bool> DeleteCategoryAsync(int id);
    }
}