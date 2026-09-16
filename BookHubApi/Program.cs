using BookHub.Infrastructure.Data;
using BookHub.Infrastructure.Data.DataSeeding;
using BookHubApi.Errors;
using BookHubApi.Extenstions;
using BookHubApi.MiddleWares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookHubApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Custom response shape for automatic Model Validation (Data Annotations)
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value?.Errors.Count > 0)
                        .SelectMany(e => e.Value!.Errors)
                        .Select(e => e.ErrorMessage);

                    var response = new InvalidBadRequestResponse(errors);

                    return new BadRequestObjectResult(response);
                };
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddApplicationService(builder.Configuration);

            builder.Services.AddDbContext<BookHubDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"));

                options.EnableSensitiveDataLogging();
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Database Migration & Data Seeding
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var dbcontext = services.GetRequiredService<BookHubDbContext>();

                    await dbcontext.Database.MigrateAsync();

                    await DataSeeder.SeedAsync(dbcontext);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();

                    logger.LogError(ex, "Error occurred during startup seeding");
                }
            }

            // Configure the HTTP request pipeline.

            app.UseMiddleware<ExceptionMiddleWare>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowFrontend");
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}