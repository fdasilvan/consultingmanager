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
        public ConsultingManagerDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ConsultingManagerDbContext>();

            var configuration = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile($"appsettings.json", false)
                                    .Build();

            builder.UseSqlServer(configuration.GetConnectionString("ConsultingManager"));

            return new ConsultingManagerDbContext(builder.Options, NullTnfSession.Instance);
        }
    }
}
