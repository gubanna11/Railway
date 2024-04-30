﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Railway.Core.Abstract;
using Railway.Core.Abstract.Interfaces;
using Railway.Core.Data;
using Railway.Core.Entities;
using Railway.Infrastructure.Mapping;
using Railway.Infrastructure.Services;
using Railway.Infrastructure.Services.Interfaces;

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
    }
}