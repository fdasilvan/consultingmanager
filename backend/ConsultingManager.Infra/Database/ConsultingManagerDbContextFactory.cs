using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

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
            var obj = new DbContextOptionsBuilder<ConsultingManagerDbContext>();
            obj.UseSqlServer("Server=sql-server-consulting-manager.ccn8jodofc23.sa-east-1.rds.amazonaws.com; Integrated Security=True; Persist Security Info=True;Initial Catalog=ConsultingManager;MultipleActiveResultSets=True; User Id=admin; Password=adalberto!1410");
            return new ConsultingManagerDbContext(obj.Options);
        }
    }
}
