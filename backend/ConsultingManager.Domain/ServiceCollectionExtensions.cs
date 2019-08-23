using ConsultingManager.Domain.Mailing;
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
            services.AddTransient<IProcessRepository, ProcessRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMailingHelper, MailingHelper>();
            return services;
        }
    }
}
