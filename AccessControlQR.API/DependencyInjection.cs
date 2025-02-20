using AcessControlQR.Application.Interfaces;
using AcessControlQR.Application.Services;
using AcessControlQR.Infrastructure.Data;
using AcessControlQR.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace AccessControlQR.API;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddDbContext<BaseContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddTransient<IAuthService, AuthService>();

        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserService, UserService>();
        
        services.AddTransient<IVisitorRepository, VisitorRepository>();
        services.AddTransient<IVisitorService, VisitorService>();

        return services;
    }

}