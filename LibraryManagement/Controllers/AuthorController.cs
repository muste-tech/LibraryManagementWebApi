using LibraryProject.DTOs;
using LibraryProject.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            return Ok(await _authorService.GetAllAuthorsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(CreateAuthorRequest request)
        {
            var author = await _authorService.AddAuthorAsync(request);
            return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, UpdateAuthorRequest request)
        {
            var result = await _authorService.UpdateAuthorAsync(id, request);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var result = await _authorService.DeleteAuthorAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}