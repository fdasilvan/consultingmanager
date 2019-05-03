using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Tnf.Runtime.Session;

namespace ConsultingManager.Infra.Database
{
    public class ConsultingManagerDbContextFactory : IDesignTimeDbContextFactory<ConsultingManagerDbContext>
    {
        private IConfiguration _configuration;

        public ConsultingManagerDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ConsultingManagerDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ConsultingManagerDbContext>();

            var configuration = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile($"appsettings.json", false)
                                    .Build();

            builder.UseSqlServer(configuration.GetConnectionString("ProSaude"));

            return (ConsultingManagerDbContext)Activator.CreateInstance(typeof(ConsultingManagerDbContext), builder.Options, NullTnfSession.Instance);
        }
    }
}
