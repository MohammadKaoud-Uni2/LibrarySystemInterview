using Library.Service.Implementation;
using Library.Service.Interface;
using Library.Service.Interfaces;
using LibraryDAL.Implementation;
using LibraryDAL.Interfaces;
using LibrarySystem.Helper;
using System.Runtime.CompilerServices;
using LibraryDAL.Implementation;
using LibrarySystem.Presentation.Filters;

namespace LibrarySystem.DiHelper
{
    public static class DiHelper
    {
        public static IServiceCollection  DiServiceAndRepo( this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserReposiory>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookRepoistory, BookRepository>();
            services.AddScoped<IBookService,BookService>();
            services.AddScoped<IBorrowingRepository, BorrowingRepository>();
            services.AddScoped<IBorrowingService,BorrowingService>();
            services.AddTransient<DatabaseInitializer>();
            services.AddScoped<GlobalActionFilter>();

            return services;
        }
    }
}
