using BookHub.Data.Helper;
using BookHub.Data.MappingProfiles.Inputs;
using BookHub.Data.MappingProfiles.Outputs;


namespace BookHub.Data.Services
{
    public interface IBookService
    {
        Task<BookShowDto> CreateBookAsync(AddBookDto dto);

        Task<BookShowDto> UpdateBookAsync(UpdateBookDto dto);

        Task<bool> DeleteBookAsync(int id);

        Task<BookShowDto> GetBookByIdAsync(int id);

        Task<Pagination<BookShowDto>> GetAllBooksAsync(
            int pageIndex,
            int pageSize);
    }
}
