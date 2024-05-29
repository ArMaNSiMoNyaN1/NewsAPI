using Microsoft.EntityFrameworkCore;
using NewsAPI.Data;
using NewsAPI.Services.Implementations;
using NewsAPI.Services.Interfaces;

namespace NewsAPI;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterDataServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        return services;
    }

    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(ServiceRegistration));

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<INewsService, NewsService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }

    public static IServiceCollection MigrateDatabase(this IServiceCollection services)
    {   
        using (var scope = services.BuildServiceProvider().CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<DataContext>();
            db.Database.Migrate();
        }

        return services;
    }
}