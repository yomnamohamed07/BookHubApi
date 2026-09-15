using BookHub.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace BookHub.Infrastructure.Data
{
    public class BookHubDbContext : DbContext
    {
        public BookHubDbContext(
            DbContextOptions<BookHubDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly());
        }

        public DbSet<Book> Books { get; set; }
    }
}
