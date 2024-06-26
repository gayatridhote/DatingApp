using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Services;
using Microsoft.EntityFrameworkCore;

namespace api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationSerices( this IServiceCollection services,IConfiguration config)
        {
           services.AddDbContext<DataContext>(opt =>
            {
               opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
           services.AddCors();
           services.AddScoped<ITokenService, TokenService>();
           services.AddScoped<IUserRepository, UserRepository>();
           services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
           services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
           services.AddScoped<IPhotoService, PhotoService>();
           services.AddScoped<LogUserActivity>();
           services.AddScoped<ILikesRepository,LikesRepository>();

           return services;
        }
    }
}