using BookHub.Data.MappingProfiles.Inputs;
using BookHub.Data.MappingProfiles.Outputs;
using BookHub.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(
            [FromBody] AddBookDto dto)
        {
            if (dto == null)
                return BadRequest("Data is required");

            var result = await _bookService.CreateBookAsync(dto);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(
            [FromBody] UpdateBookDto dto)
        {
            if (dto == null)
                return BadRequest("Data is required");

            var result = await _bookService.UpdateBookAsync(dto);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBookAsync(id);

            if (!result)
                return NotFound("Book not found");

            return Ok("Book deleted successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var result = await _bookService.GetBookByIdAsync(id);

            if (result == null)
                return NotFound("Book not found");

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks(
            int pageIndex = 1,
            int pageSize = 10)
        {
            var result = await _bookService.GetAllBooksAsync(
                pageIndex,
                pageSize);

            return Ok(result);
        }
    }
}
