using LibraryProject.DTOs;
using LibraryProject.Model;
using LibraryProject.Repositories.Interfaces;
using LibraryProject.Services.Interface;

namespace LibraryProject.Services
{
    public class BorrowService : IBorrowService
    {
        private readonly IBorrowRepository _borrowRepo;
        private readonly IBookRepository _bookRepo;

        public BorrowService(IBorrowRepository borrowRepo, IBookRepository bookRepo)
        {
            _borrowRepo = borrowRepo;
            _bookRepo = bookRepo;
        }

        public async Task<IEnumerable<BorrowResponse>> GetAllBorrowedBooksAsync()
        {
            var borrows = await _borrowRepo.VeiwBorrowedBooks();

            return borrows.Select(b => new BorrowResponse
            {
                Id = b.Id,
                BookId = b.BookId,
                MemberId = b.MemberId,
                BorrowDate = b.BorrowDate,
                DueDate = b.DueDate,
                IsReturned = b.IsReturned
            });
        }

        public async Task<IEnumerable<BorrowResponse>> GetOverdueBooksAsync()
        {
            var borrows = await _borrowRepo.VeiwOverdueBooks();

            return borrows.Select(b => new BorrowResponse
            {
                Id = b.Id,
                BookId = b.BookId,
                MemberId = b.MemberId,
                BorrowDate = b.BorrowDate,
                DueDate = b.DueDate,
                IsReturned = b.IsReturned
            });
        }

        public async Task<bool> BorrowBookAsync(BorrowRequest request)
        {
            var book = await _bookRepo.GetBookByIdAsync(request.BookId);

            if (book == null || book.AvailableCopies <= 0)
                return false;

            var borrow = new Borrow
            {
                BookId = request.BookId,
                MemberId = request.MemberId,
                BorrowDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(14),
                IsReturned = false
            };

            book.AvailableCopies--;

            _borrowRepo.BorrowBook(borrow);
            await _borrowRepo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ReturnBookAsync(int borrowId)
        {
            var borrows = await _borrowRepo.VeiwBorrowedBooks();

            var record = borrows.FirstOrDefault(x => x.Id == borrowId);

            if (record == null)
                return false;

            _borrowRepo.ReturnBook(record);
            await _borrowRepo.SaveChangesAsync();

            return true;
        }
    }
}