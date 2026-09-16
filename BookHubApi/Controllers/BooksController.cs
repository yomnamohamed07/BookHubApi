using BookHub.Data.MappingProfiles.Inputs;
using BookHub.Data.MappingProfiles.Outputs;
using BookHub.Data.MappingProfiles.Outputs.BookHub.Data.MappingProfiles.Inputs;
using BookHub.Data.Services;
using BookHub.Services.Exceptions;
using BookHubApi.Errors;
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
        public async Task<IActionResult> CreateBook([FromBody] AddBookDto dto)
        {
            var result = await _bookService.CreateBookAsync(dto);

            return CreatedAtAction(nameof(GetBookById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDto dto)
        {
            if (id != dto.Id)
                throw new BadRequestException("Route id does not match body id");

            var result = await _bookService.UpdateBookAsync(dto);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBookAsync(id);

            return Ok("Book deleted successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var result = await _bookService.GetBookByIdAsync(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks(
            int pageIndex = 1,
            int pageSize = 10)
        {
            var result = await _bookService.GetAllBooksAsync(pageIndex, pageSize);

            return Ok(result);
        }
    }
}