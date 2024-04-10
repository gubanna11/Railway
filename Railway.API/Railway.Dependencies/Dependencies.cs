using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Railway.Infrastructure.Data;
using Railway.Infrastructure.Entities;

namespace Railway.Dependencies;

public static class Dependencies
{
    public static IServiceCollection ConfigureEnvironment(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.ConfigureDatabase(configuration);

        return services;
    }

    private static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(
            options => options.UseMySQL(configuration["ConnectionStrings:Railway"]));

        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
    }
}