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
        services.AddDbContextPool<ApplicationContext>(
            builder => builder.UseNpgsql(configuration.GetConnectionString("DbConnection"))
                .EnableSensitiveDataLogging()
                .UseSnakeCaseNamingConvention());
    }
}