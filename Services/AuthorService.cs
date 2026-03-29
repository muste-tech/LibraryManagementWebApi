using LibraryProject.DTOs;
using LibraryProject.Model;
using LibraryProject.Repositories.Interfaces;
using LibraryProject.Services.Interface;

namespace LibraryProject.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repo;

        public AuthorService(IAuthorRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<AuthorResponse>> GetAllAuthorsAsync()
        {
            var authors = await _repo.GetAllAuthorsAsync();

            return authors.Select(a => new AuthorResponse
            {
                Id = a.Id,
                FullName = a.FullName,
                Biography = a.Biography
            });
        }

        public async Task<AuthorResponse?> GetAuthorByIdAsync(int id)
        {
            var a = await _repo.GetAuthorByIdAsync(id);
            if (a == null) return null;

            return new AuthorResponse
            {
                Id = a.Id,
                FullName = a.FullName,
                Biography = a.Biography
            };
        }

        public async Task<AuthorResponse> AddAuthorAsync(CreateAuthorRequest request)
        {
            var author = new Author
            {
                FullName = request.FullName,
                Biography = request.Biography
            };

            await _repo.AddAuthorAsync(author);
            await _repo.SaveChangesAsync();

            return new AuthorResponse
            {
                Id = author.Id,
                FullName = author.FullName,
                Biography = author.Biography
            };
        }

        public async Task<bool> UpdateAuthorAsync(int id, UpdateAuthorRequest request)
        {
            var author = await _repo.GetAuthorByIdAsync(id);
            if (author == null) return false;

            author.FullName = request.FullName;
            author.Biography = request.Biography;

            _repo.UpdateAuthor(author);
            await _repo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var author = await _repo.GetAuthorByIdAsync(id);
            if (author == null) return false;

            _repo.DeleteAuthor(author);
            await _repo.SaveChangesAsync();

            return true;
        }
    }
}