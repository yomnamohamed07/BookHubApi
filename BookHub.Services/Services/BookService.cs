using AutoMapper;
using BookHub.Data.Entities;
using BookHub.Data.Helper;
using BookHub.Data.MappingProfiles.Inputs;
using BookHub.Data.MappingProfiles.Inputs.BookHub.Data.MappingProfiles.Outputs;
using BookHub.Data.MappingProfiles.Outputs;
using BookHub.Data.MappingProfiles.Outputs.BookHub.Data.MappingProfiles.Inputs;
using BookHub.Data.Respositories;
using BookHub.Data.Services;
using BookHub.Services.Exceptions;


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
            var existingBook = await _bookRepository.GetByIsbnAsync(dto.ISBN);

            if (existingBook != null)
                throw new BadRequestException($"A book with ISBN '{dto.ISBN}' already exists");

            var book = _mapper.Map<Book>(dto);

            book.IsDeleted = false;

            await _bookRepository.AddAsync(book);

            return _mapper.Map<BookShowDto>(book);
        }

        public async Task<BookShowDto> UpdateBookAsync(UpdateBookDto dto)
        {
            var book = await _bookRepository.GetByIdAsync(dto.Id);

            if (book == null)
                throw new NotFoundException("Book not found");

            var existingBook = await _bookRepository.GetByIsbnAsync(dto.ISBN);

            if (existingBook != null && existingBook.Id != dto.Id)
                throw new BadRequestException($"Another book with ISBN '{dto.ISBN}' already exists");

            _mapper.Map(dto, book);

            await _bookRepository.UpdateAsync(book);

            return _mapper.Map<BookShowDto>(book);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
                throw new NotFoundException("Book not found");

            await _bookRepository.DeleteAsync(book);

            return true;
        }

        public async Task<BookShowDto> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
                throw new NotFoundException("Book not found");

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