using GraphNet.Interfaces;
using GraphNet.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GraphNet.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
            options.AddPolicy("DefaultPolicy",
                builder =>
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()));
    }

    public static void ConfigureDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPooledDbContextFactory<ApplicationContext>(
            builder => builder.UseNpgsql(configuration.GetConnectionString("DbConnection"))
                .EnableSensitiveDataLogging()
                .UseSnakeCaseNamingConvention());
    }

    public static void ConfigureInjections(this IServiceCollection services)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
    }
}