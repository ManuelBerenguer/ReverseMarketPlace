using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReverseMarketPlace.Demands.Infrastructure.Data.EF.Data;

namespace ReverseMarketPlace.Demands.API.Configuration.EF
{
    public static class EFSetup
    {
        private const string ConnectionStringPropertyName = "DemandsConnectionString";
        private const string UseInMemoryDataBasePropertyName = "UseInMemoryDatabase";
        private const string InMemoryDataBaseName = "Demands";

        public static IServiceCollection AddEFConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var useInMemoryDatabase = configuration.GetSection("Settings").GetValue<bool>(UseInMemoryDataBasePropertyName);

            services.AddDbContext<DemandsDbContext>(options =>
            {
                if (useInMemoryDatabase)
                {
                    options.UseInMemoryDatabase(InMemoryDataBaseName);
                }
                else
                {
                    options.UseSqlServer(configuration.GetSection("Settings").GetValue<string>(ConnectionStringPropertyName));
                }
            });

            //services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
