using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy => policy.AllowAnyHeader()
                .AllowAnyMethod().WithOrigins("http://localhost:4200"));
        });
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ITmdbApiService>(provider =>
        {
            string bearerToken = "Bearer " + config["TmdbTokenKey"];
            return new TmdbApiService(bearerToken);
        });
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}