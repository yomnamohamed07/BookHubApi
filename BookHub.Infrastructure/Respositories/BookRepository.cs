using BookHub.Data.Entities;
using BookHub.Data.Helper;
using BookHub.Data.Respositories;
using BookHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace BookHub.Infrastructure.Respositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookHubDbContext _context;
        private readonly DbSet<Book> _dbSet;

        public BookRepository(BookHubDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Book>();
        }

        public async Task<Book> AddAsync(Book book)
        {
            await _dbSet.AddAsync(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _dbSet
                .FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);
        }

        public async Task<Pagination<Book>> GetAllAsync(
            int pageIndex,
            int pageSize)
        {
            var query = _dbSet
                .AsNoTracking()
                .Where(b => !b.IsDeleted);

            var totalCount = await query.CountAsync();

            var books = await query
                .OrderBy(b => b.Title)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new Pagination<Book>(
                pageIndex,
                pageSize,
                books,
                totalCount);
        }

        public async Task UpdateAsync(Book book)
        {
            _dbSet.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            book.IsDeleted = true;

            await _context.SaveChangesAsync();
        }

        public async Task<Book?> GetByIsbnAsync(string isbn)
        {
            return await _context.Books
                .FirstOrDefaultAsync(b => b.ISBN == isbn && !b.IsDeleted);
        }
    }
}
