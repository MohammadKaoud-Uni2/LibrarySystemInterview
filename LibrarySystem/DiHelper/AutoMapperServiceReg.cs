using Library.Service.Mapping;

namespace LibrarySystem.Presentation.DiHelper
{
    public static  class AutoMapperServiceReg
    {
        public static IServiceCollection AllowAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BookProfile));
            services.AddAutoMapper(typeof(BorrowingProfile));
            services.AddAutoMapper(typeof(UserProfile));
            return services;
        }
    }
}
