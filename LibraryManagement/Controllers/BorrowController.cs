using LibraryProject.DTOs;
using LibraryProject.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowController : ControllerBase
    {
        private readonly IBorrowService _borrowService;

        public BorrowController(IBorrowService borrowService)
        {
            _borrowService = borrowService;
        }

        [HttpGet("borrowed")]
        public async Task<IActionResult> GetBorrowedBooks()
        {
            return Ok(await _borrowService.GetAllBorrowedBooksAsync());
        }

        [HttpGet("overdue")]
        public async Task<IActionResult> GetOverdueBooks()
        {
            return Ok(await _borrowService.GetOverdueBooksAsync());
        }

        [HttpPost("borrow")]
        public async Task<IActionResult> BorrowBook(BorrowRequest request)
        {
            var result = await _borrowService.BorrowBookAsync(request);
            if (!result) return BadRequest("Book not available or invalid request");

            return Ok("Book borrowed successfully");
        }

        [HttpPost("return/{id}")]
        public async Task<IActionResult> ReturnBook(int id)
        {
            var result = await _borrowService.ReturnBookAsync(id);
            if (!result) return NotFound();

            return Ok("Book returned successfully");
        }
    }
}