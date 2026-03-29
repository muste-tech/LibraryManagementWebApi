using LibraryProject.Model;
using LibraryProject.Data;
using LibraryProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Repositories.Implementations
{
    public class BorrowRepository : IBorrowRepository
    {
        private readonly LibraryDbContext _context;

        public BorrowRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Borrow>> VeiwBorrowedBooks()
        {
            return await _context.Borrows
                .Where(b => !b.IsReturned)
                .ToListAsync();
        }
        public async Task<IEnumerable<Borrow>> VeiwOverdueBooks()
        {
            return await _context.Borrows
                .Where(b => !b.IsReturned && b.DueDate < DateTime.Now)
                .ToListAsync();
        }
        public void BorrowBook(Borrow borrow)
        {
            _context.Borrows.Add(borrow);
        }

        public void ReturnBook(Borrow borrow)
        {
            borrow.IsReturned = true;
            borrow.ReturnDate = DateTime.Now;

            _context.Borrows.Update(borrow);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}