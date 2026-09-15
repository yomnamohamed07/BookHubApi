using BookHub.Data.Entities;
using BookHub.Data.Helper;


namespace BookHub.Data.Respositories
{
    public interface IBookRepository
    {
        Task<Book> AddAsync(Book book);

        Task<Book?> GetByIdAsync(int id);

        Task<Pagination<Book>> GetAllAsync(
            int pageIndex,
            int pageSize);

        Task UpdateAsync(Book book);

        Task DeleteAsync(Book book);
    }
}
