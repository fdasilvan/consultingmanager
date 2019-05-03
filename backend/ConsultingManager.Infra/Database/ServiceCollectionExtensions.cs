using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConsultingManager.Infra.Database
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabaseDependency(this IServiceCollection services)
        {
            services
             .AddTnfEntityFrameworkCore()
             .AddTnfDbContext<ConsultingManagerDbContext>((config) =>
             {
                 config.DbContextOptions.UseSqlServer(config.ConnectionString);
             });

            return services;

        }
    }
}
