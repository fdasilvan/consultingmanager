using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConsultingManager.Infra.Database
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabaseDependency(this IServiceCollection services)
        {
            return services;
        }
    }
}
