using ConsultingManager.Domain;
using ConsultingManager.Dto;
using ConsultingManager.Infra.Database.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ConsultingManager.Domain
{
    internal static class MapperExtensions
    {
        internal static IServiceCollection AddMapperDependency(this IServiceCollection services)
        {
            return services.AddTnfAutoMapper(config =>
            {
                config.AddProfile<InfraToDto>();
            });
        }
    }
}
