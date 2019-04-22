using Microsoft.Extensions.DependencyInjection;

namespace ConsultingManager.Infra
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfraDependency(this IServiceCollection services)
        {
            return services;
        }
    }
}