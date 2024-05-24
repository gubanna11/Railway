using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Railway.Core.Abstract;
using Railway.Core.Abstract.Interfaces;
using Railway.Core.Data;
using Railway.Core.Entities;
using Railway.Infrastructure.Mapping;
using Railway.Infrastructure.Services;
using Railway.Infrastructure.Services.Interfaces;
using System.Text;

namespace Railway.Dependencies;

public static class Dependencies
{
    public static IServiceCollection ConfigureEnvironment(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.ConfigureDatabase(configuration);
        services.ConfigureUnitOfWork();
        services.ConfigureMapper();

        services.ConfigureServices();
        services.ConfigureCors(configuration);
        services.ConfigureJwt(configuration);

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

    private static void ConfigureUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
    }

    private static void ConfigureMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DataProfile));
    }

    private static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IRoutesService, RoutesService>();
        services.AddScoped<ITrainsService, TrainsService>();
        services.AddScoped<ITrainTypesService, TrainTypesService>();
        services.AddScoped<ILocalitiesService, LocalitiesService>();
        services.AddScoped<IStationsService, StationsService>();
        services.AddScoped<IRouteStopsService, RouteStopsService>();
        services.AddScoped<IRouteSeatsService, RouteSeatsService>();

        services.AddScoped<JwtHandler>();
    }

    private static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JWTSettings");
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["validIssuer"],
                ValidAudience = jwtSettings["validAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(jwtSettings.GetSection("securityKey").Value))
            };
        });
    }
    private static void ConfigureCors(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options => options.AddPolicy(name: configuration["UI:Name"]!,
        policy =>
        {
            policy
            .WithOrigins(configuration["UI:Link"]!)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        }));
    }
}