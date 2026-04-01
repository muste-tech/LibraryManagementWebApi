using LibraryProject.DTOs;
using System.Runtime.InteropServices;

namespace LibraryProject.Services.Interface
{
    public interface IAuthorService
    {
        Task <IEnumerable<AuthorResponse>> GetAllAuthorsAsync();
        Task <AuthorResponse?> GetAuthorByIdAsync(int id);
        Task <AuthorResponse> AddAuthorAsync(CreateAuthorRequest request);
        Task <bool> UpdateAuthorAsync (int Id, UpdateAuthorRequest request);
        Task <bool> DeleteAuthorAsync (int id);
    }
}