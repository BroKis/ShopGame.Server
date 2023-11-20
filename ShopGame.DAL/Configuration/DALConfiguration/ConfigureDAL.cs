using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopGame.DAL.Context;
using ShopGame.DAL.Repository.Implementation;
using ShopGame.DAL.Repository.Interfaces;

namespace ShopGame.DAL.Configuration.DALConfiguration;

public static class ConfigurationExtensions
{
    public static void ConfigureDAL(this IServiceCollection services,string? connection)
    {
        services.AddDbContext<ApplicationContext>(option
            =>
        {
            option.UseMySql(connection, new MySqlServerVersion("8.0.32"));
        });
        
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
    }
    
}
