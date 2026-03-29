using Microsoft.EntityFrameworkCore;
using LibraryProject.Data;
using LibraryProject.Model;
using LibraryProject.Repositories.Interfaces;

namespace LibraryProject.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository (AppDbContext context)
        {
            _context = context;
        }

        public async Task <IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task <Author> GetAuthorByIdAsync (int id)
        {
            return await _context.Authors.FindAsync(id);
        }

        public async Task AddAuthorAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
        }

        public void UpdateAuthor (Author author)
        {
            _context.Authors.Update(author);
        }
        
        public void DeleteAuthor (Author author)
        {
            _context.Authors.Remove(author);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}