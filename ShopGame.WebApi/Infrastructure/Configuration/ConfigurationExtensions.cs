using GameshopMini.Infrastructure.ProfileForMapper;
using GameshopMini.ModelsDTO;
using ShopGame.DAL.Configuration.DALConfiguration;

namespace GameshopMini.Infrastructure.Configuration;

public static  class ConfigurationExtensions
{
    public static void ConfigureBLL(this IServiceCollection services,string? connection)
    {
        services.ConfigureDAL(connection);
        services.AddAutoMapper(
            typeof(GameProfile),
            typeof(GenreProfile),
            typeof(OrderProfile));
            services.AddAutoMapper(typeof(Program).Assembly);
    }
}
