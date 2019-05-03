using ConsultingManager.Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingManager.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainDependency(this IServiceCollection services)
        {
            services.AddMapperDependency();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}
