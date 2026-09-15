using BookHub.Data.Respositories;
using BookHub.Data.Services;
using BookHub.Infrastructure.Respositories;
using BookHub.Services.Mapper;
using BookHub.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookHubApi.Extenstions
{
    public static class AddApplicationServices
    {
        public static IServiceCollection AddApplicationService(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // AutoMapper
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<BookProfile>();
            });

            // Repositories
            services.AddScoped<IBookRepository, BookRepository>();

            // Services
            services.AddScoped<IBookService, BookService>();

            return services;
        }
    }

}
