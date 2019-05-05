using ConsultingManager.Infra.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Tnf.EntityFrameworkCore;
using Tnf.Runtime.Session;

namespace ConsultingManager.Infra.Database
{
    public class ConsultingManagerDbContext : TnfDbContext
    {
        public ConsultingManagerDbContext(DbContextOptions<ConsultingManagerDbContext> options, ITnfSession session)
          : base(options, session)
        {

        }

        public DbSet<CustomerPoco> Customers { get; set; }
        public DbSet<CustomerProcessPoco> CustomerProcesses { get; set; }
        public DbSet<CustomerStepPoco> CustomerSteps { get; set; }
        public DbSet<CustomerTaskPoco> CustomerTasks { get; set; }
        public DbSet<ModelProcessPoco> ModelProcesses { get; set; }
        public DbSet<ModelStepPoco> ModelSteps { get; set; }
        public DbSet<ModelTaskPoco> ModelTaks { get; set; }
        public DbSet<PlatformPoco> Platforms { get; set; }
        public DbSet<TaskContentPoco> TaskContent { get; set; }
        public DbSet<TaskTypePoco> TaskTypes { get; set; }        
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

            #region Tipo de Usuário

            modelBuilder.Entity<UserTypePoco>().HasData(new UserTypePoco() { Id = Const.UserTypes.Administrator, Description = "Administrador" });
            modelBuilder.Entity<UserTypePoco>().HasData(new UserTypePoco() { Id = Const.UserTypes.Leader, Description = "Líder" });
            modelBuilder.Entity<UserTypePoco>().HasData(new UserTypePoco() { Id = Const.UserTypes.Consultant, Description = "Consultor" });
            modelBuilder.Entity<UserTypePoco>().HasData(new UserTypePoco() { Id = Const.UserTypes.Customer, Description = "Cliente" });

            #endregion

            #region Tipos de Tarefa

            modelBuilder.Entity<TaskTypePoco>().HasData(new TaskTypePoco() { Id = Const.TaskTypes.Consultant, Description = "Consultor" });
            modelBuilder.Entity<TaskTypePoco>().HasData(new TaskTypePoco() { Id = Const.TaskTypes.Customer, Description = "Cliente" });

            #endregion

            #region Plataforma

            modelBuilder.Entity<TaskTypePoco>().HasData(new TaskTypePoco() { Id = Const.Platforms.Simplo7, Description = "Simplo7" });

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
