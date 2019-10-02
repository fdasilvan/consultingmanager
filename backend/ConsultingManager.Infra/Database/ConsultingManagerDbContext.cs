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
        public DbSet<CustomerMeetingPoco> CustomerMeetings { get; set; }
        public DbSet<CustomerStepPoco> CustomerSteps { get; set; }
        public DbSet<CustomerTaskPoco> CustomerTasks { get; set; }
        public DbSet<CustomerLevelPoco> CustomerLevels { get; set; }
        public DbSet<ModelProcessPoco> ModelProcesses { get; set; }
        public DbSet<ModelStepPoco> ModelSteps { get; set; }
        public DbSet<ModelTaskPoco> ModelTasks { get; set; }
        public DbSet<PlatformPoco> Platforms { get; set; }
        public DbSet<TaskContentPoco> TaskContent { get; set; }
        public DbSet<TaskTypePoco> TaskTypes { get; set; }
        public DbSet<UserPoco> Users { get; set; }
        public DbSet<UserTypePoco> UserTypes { get; set; }
        public DbSet<PlanPoco> Plans { get; set; }
        public DbSet<CustomerCategoryPoco> CustomerCategories { get; set; }
        public DbSet<CityPoco> Cities { get; set; }
        public DbSet<CustomerSituationPoco> CustomerSituations { get; set; }
        public DbSet<CommentPoco> Comments { get; set; }
        public DbSet<TeamPoco> Teams { get; set; }
        public DbSet<UserCustomerCategoryPoco> UserCustomerCategories { get; set; }
        public DbSet<UserCustomerLevelPoco> UserCustomerLevels { get; set; }

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
            modelBuilder.Entity<UserTypePoco>().HasData(new UserTypePoco() { Id = Const.UserTypes.Implanter, Description = "Implantador" });

            #endregion

            #region Tipos de Tarefa

            modelBuilder.Entity<TaskTypePoco>().HasData(new TaskTypePoco() { Id = Const.TaskTypes.Consultant, Description = "Consultor" });
            modelBuilder.Entity<TaskTypePoco>().HasData(new TaskTypePoco() { Id = Const.TaskTypes.Customer, Description = "Cliente" });

            #endregion

            #region Plataformas

            modelBuilder.Entity<PlatformPoco>().HasData(new PlatformPoco() { Id = Const.Platforms.Simplo7, Name = "Simplo7" });

            #endregion

            #region Situações do Cliente

            modelBuilder.Entity<CustomerSituationPoco>().HasData(new CustomerSituationPoco() { Id = Const.CustomerSituations.Active, Description = "Ativo" });
            modelBuilder.Entity<CustomerSituationPoco>().HasData(new CustomerSituationPoco() { Id = Const.CustomerSituations.Paused, Description = "Pausado" });
            modelBuilder.Entity<CustomerSituationPoco>().HasData(new CustomerSituationPoco() { Id = Const.CustomerSituations.Blocked, Description = "Bloqueado" });
            modelBuilder.Entity<CustomerSituationPoco>().HasData(new CustomerSituationPoco() { Id = Const.CustomerSituations.Canceled, Description = "Cancelado" });
            modelBuilder.Entity<CustomerSituationPoco>().HasData(new CustomerSituationPoco() { Id = Const.CustomerSituations.ContractCompleted, Description = "Contrato Concluído" });

            #endregion

            #region Equipes

            modelBuilder.Entity<TeamPoco>().HasData(new TeamPoco() { Id = Const.Teams.Implantation, Description = "Implantação" });
            modelBuilder.Entity<TeamPoco>().HasData(new TeamPoco() { Id = Const.Teams.Consulting, Description = "Consultoria" });

            #endregion

            #region ModelProcess x ModelSteps 1-to-n relationship

            modelBuilder.Entity<ModelProcessPoco>()
                .HasMany(c => c.ModelSteps)
                .WithOne(e => e.Process);

            #endregion

            #region ModelStep x ModelTasks 1-to-n relationship

            modelBuilder.Entity<ModelStepPoco>()
                .HasMany(c => c.ModelTasks)
                .WithOne(e => e.ModelStep);

            #endregion

            #region CustomerPoco x CustomerProcess 1-to-n relationship

            modelBuilder.Entity<CustomerPoco>()
                .HasMany(c => c.CustomerProcesses)
                .WithOne(e => e.Customer);

            #endregion

            #region CustomerMeeting x CustomerProcess 1-to-n relationship

            modelBuilder.Entity<CustomerMeetingPoco>()
                .HasMany(c => c.CustomerProcesses)
                .WithOne(e => e.CustomerMeeting);

            #endregion

            #region CustomerProcess x CustomerStep 1-to-n relationship

            modelBuilder.Entity<CustomerProcessPoco>()
                .HasMany(c => c.CustomerSteps)
                .WithOne(e => e.CustomerProcess);

            #endregion

            #region CustomerStep x CustomerTask 1-to-n relationship

            modelBuilder.Entity<CustomerStepPoco>()
                .HasMany(c => c.CustomerTasks)
                .WithOne(e => e.CustomerStep);

            #endregion

            #region ModelTask x TaskContent 1-to-n relationship

            modelBuilder.Entity<ModelTaskPoco>()
                .HasMany(c => c.TaskContent)
                .WithOne(e => e.ModelTask);

            #endregion

            #region CustomerPoco x User 1-to-n relationship

            modelBuilder.Entity<CustomerPoco>()
                .HasMany(c => c.Users)
                .WithOne(e => e.Customer);

            #endregion

            #region CustomerMeeting x Comment 1-to-n relationship

            modelBuilder.Entity<CustomerMeetingPoco>()
                .HasMany(c => c.Comments)
                .WithOne(e => e.CustomerMeeting);

            #endregion

            #region CustomerTask x Comment 1-to-n relationship

            modelBuilder.Entity<CustomerTaskPoco>()
                .HasMany(c => c.Comments)
                .WithOne(e => e.CustomerTask);

            #endregion

            #region Customer x Comment 1-to-n relationship

            modelBuilder.Entity<CustomerPoco>()
                .HasMany(c => c.Comments)
                .WithOne(e => e.Customer);

            #endregion

            #region User x Customer Categories n-to-n relationship

            modelBuilder.Entity<UserCustomerCategoryPoco>()
                .HasKey(bc => new { bc.UserId, bc.CustomerCategoryId });

            modelBuilder.Entity<UserCustomerCategoryPoco>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserCustomerCategories)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<UserCustomerCategoryPoco>()
                .HasOne(bc => bc.CustomerCategory)
                .WithMany(c => c.UserCustomerCategories)
                .HasForeignKey(bc => bc.CustomerCategoryId);

            #endregion

            #region User x Customer Level n-to-n relationship

            modelBuilder.Entity<UserCustomerLevelPoco>()
                .HasKey(bc => new { bc.UserId, bc.CustomerLevelId });

            modelBuilder.Entity<UserCustomerLevelPoco>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserCustomerLevels)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<UserCustomerLevelPoco>()
                .HasOne(bc => bc.CustomerLevel)
                .WithMany(c => c.UserCustomerLevel)
                .HasForeignKey(bc => bc.CustomerLevelId);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
