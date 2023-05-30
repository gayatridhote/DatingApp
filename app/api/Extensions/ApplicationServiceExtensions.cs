using api.Data;
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


           return services;
        }
    }
}