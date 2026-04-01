using Microsoft.EntityFrameworkCore;
using LibraryProject.Data;
using LibraryProject.Model;
using LibraryProject.Repositories.Interfaces;

namespace LibraryProject.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;
        public BookRepository (LibraryDbContext context)
        {
            _context=context;
        }
        
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }
        
        public async Task <Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async  Task AddBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        public  void UpdateBook (Book book)
        {
            _context.Books.Update(book);
        }

        public void DeleteBook (Book book)
        {
            _context.Books.Remove(book);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}