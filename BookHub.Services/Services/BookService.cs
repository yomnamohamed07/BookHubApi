
using AutoMapper;
using BookHub.Data.Entities;
using BookHub.Data.Helper;
using BookHub.Data.MappingProfiles.Inputs;
using BookHub.Data.MappingProfiles.Outputs;
using BookHub.Data.Respositories;
using BookHub.Data.Services;

namespace BookHub.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(
            IBookRepository bookRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookShowDto> CreateBookAsync(AddBookDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                throw new Exception("Title is required");

            if (string.IsNullOrWhiteSpace(dto.Author))
                throw new Exception("Author is required");

            if (string.IsNullOrWhiteSpace(dto.ISBN))
                throw new Exception("ISBN is required");

            if (string.IsNullOrWhiteSpace(dto.Category))
                throw new Exception("Category is required");

            if (dto.AvailableCopies < 0)
                throw new Exception("Available Copies cannot be negative");

            var book = _mapper.Map<Book>(dto);

            book.IsDeleted = false;

            await _bookRepository.AddAsync(book);

            return _mapper.Map<BookShowDto>(book);
        }

        public async Task<BookShowDto> UpdateBookAsync(UpdateBookDto dto)
        {
            var book = await _bookRepository.GetByIdAsync(dto.Id);

            if (book == null)
                throw new Exception("Book not found");

            if (string.IsNullOrWhiteSpace(dto.Title))
                throw new Exception("Title is required");

            if (string.IsNullOrWhiteSpace(dto.Author))
                throw new Exception("Author is required");

            if (string.IsNullOrWhiteSpace(dto.ISBN))
                throw new Exception("ISBN is required");

            if (string.IsNullOrWhiteSpace(dto.Category))
                throw new Exception("Category is required");

            if (dto.AvailableCopies < 0)
                throw new Exception("Available Copies cannot be negative");

            _mapper.Map(dto, book);

            await _bookRepository.UpdateAsync(book);

            return _mapper.Map<BookShowDto>(book);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
                throw new Exception("Book not found");

            await _bookRepository.DeleteAsync(book);

            return true;
        }

        public async Task<BookShowDto> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
                throw new Exception("Book not found");

            return _mapper.Map<BookShowDto>(book);
        }

        public async Task<Pagination<BookShowDto>> GetAllBooksAsync(
            int pageIndex,
            int pageSize)
        {
            var result = await _bookRepository.GetAllAsync(
                pageIndex,
                pageSize);

            var data = _mapper.Map<List<BookShowDto>>(result.Data);

            return new Pagination<BookShowDto>(
                result.PageIndex,
                result.PageSize,
                data,
                result.Count);
        }
    }
}
 