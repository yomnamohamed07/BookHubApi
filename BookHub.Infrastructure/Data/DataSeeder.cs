using System.Text.Json;
using BookHub.Data.Entities;


namespace BookHub.Infrastructure.Data.DataSeeding
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(BookHubDbContext context)
        {
            if (!context.Books.Any())
            {
                var path = "../BookHub.Infrastructure/Data/DataSeeding/Book.json";

                var bookData = File.ReadAllText(path);

                var books = JsonSerializer.Deserialize<List<Book>>(bookData);

                if (books?.Count > 0)
                {
                    foreach (var book in books)
                    {
                        await context.Books.AddAsync(book);
                    }

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}