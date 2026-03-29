using Microsoft.EntityFrameworkCore;
using LibraryProject.Data;
using LibraryProject.Model;
using LibraryProject.Repositories.Interfaces;

namespace LibraryProject.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LibraryDbContext _context;
        public CategoryRepository (LibraryDbContext context)
        {
            _context=context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task AddCategoryAsync (Category category)
        {
            await _context.Categories.AddAsync(category);
        }
        
        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
        }

         public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
        }

         public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}