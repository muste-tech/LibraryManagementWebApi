using LibraryProject.DTOs;
using LibraryProject.Model;
using LibraryProject.Repositories.Interfaces;
using LibraryProject.Services.Interface;

namespace LibraryProject.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;

        public BookService(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }
        public async Task<IEnumerable<BookResponse>> GetAllBooksAsync()
        {
            var books = await _bookRepo.GetAllBooksAsync();

            return books.Select(b => new BookResponse
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                TotalCopies = b.TotalCopies,
                AvailableCopies = b.AvailableCopies,
                AuthorId = b.AuthorId,
                CategoryId = b.CategoryId
            });
        }
        public async Task<BookResponse?> GetBookByIdAsync(int id)
        {
            var b = await _bookRepo.GetBookByIdAsync(id);

            if (b == null) return null;

            return new BookResponse
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                TotalCopies = b.TotalCopies,
                AvailableCopies = b.AvailableCopies,
                AuthorId = b.AuthorId,
                CategoryId = b.CategoryId
            };
        }

        public async Task<BookResponse> AddBookAsync(CreateBookRequest request)
        {
            var book = new Book
            {
                Title = request.Title,
                ISBN = request.ISBN,
                TotalCopies = request.TotalCopies,
                AvailableCopies = request.TotalCopies,
                AuthorId = request.AuthorId,
                CategoryId = request.CategoryId
            };

            await _bookRepo.AddBookAsync(book);
            await _bookRepo.SaveChangesAsync();

            return new BookResponse
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                TotalCopies = book.TotalCopies,
                AvailableCopies = book.AvailableCopies,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId
            };
        }

        public async Task<bool> UpdateBookAsync(int id, UpdateBookRequest request)
        {
            var book = await _bookRepo.GetBookByIdAsync(id);

            if (book == null)
                return false;

            book.Title = request.Title;
            book.ISBN = request.ISBN;
            book.TotalCopies = request.TotalCopies;
            book.AvailableCopies = request.AvailableCopies;
            book.AuthorId = request.AuthorId;
            book.CategoryId = request.CategoryId;

            _bookRepo.UpdateBook(book);
            await _bookRepo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _bookRepo.GetBookByIdAsync(id);

            if (book == null)
                return false;

            _bookRepo.DeleteBook(book);
            await _bookRepo.SaveChangesAsync();

            return true;
        }
    }
}