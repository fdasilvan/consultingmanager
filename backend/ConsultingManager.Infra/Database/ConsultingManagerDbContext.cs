using ConsultingManager.Infra.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace ConsultingManager.Infra.Database
{
    public class ConsultingManagerDbContext : DbContext
    {
        public ConsultingManagerDbContext()
        {
        }

        public ConsultingManagerDbContext(DbContextOptions<ConsultingManagerDbContext> options)
          : base(options)
        {
        }

        public DbSet<CustomerPoco> Customers { get; set; }
        public DbSet<PlatformPoco> Platforms { get; set; }
        public DbSet<ProcessPoco> Processes { get; set; }
        public DbSet<StepPoco> Steps { get; set; }
        public DbSet<TaskPoco> Tasks { get; set; }
        public DbSet<TaskTypePoco> TaskTypes { get; set; }
        public DbSet<TaskTemplatePoco> TaskTemplates { get; set; }
        public DbSet<UserPoco> Users { get; set; }
        public DbSet<UserTypePoco> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime) && property.Name == "CreatedDate")
                    {
                        modelBuilder.Entity(entityType.Name)
                            .Property(property.Name)
                            .HasDefaultValueSql("getdate()");
                    }
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
