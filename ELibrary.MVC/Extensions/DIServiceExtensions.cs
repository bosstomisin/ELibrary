using ELibrary.Core.Abstractions;
using ELibrary.Core.Implementations;
using ELibrary.Data.Repositories.Abstractions;
using ELibrary.Data.Repositories.Implementations;
using ELibrary.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ELibrary.MVC.Extensions
{
    public static class DIServiceExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IRateService, RateService>();
            
            services.AddScoped<IUserService, UserService>();
        }
    }
}
