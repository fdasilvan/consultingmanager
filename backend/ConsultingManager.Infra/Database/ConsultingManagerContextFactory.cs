using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using Tnf.Runtime.Session;

namespace ConsultingManager.Infra.Database
{
    public class ConsultingManagerContextFactory : IDesignTimeDbContextFactory<ConsultingManagerDbContext>
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