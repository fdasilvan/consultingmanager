﻿// <auto-generated />
using System;
using ConsultingManager.Infra.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsultingManager.Infra.Migrations
{
    [DbContext(typeof(ConsultingManagerDbContext))]
    partial class ConsultingManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.CityPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.Property<string>("State");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.CommentPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CustomerId");

                    b.Property<Guid?>("CustomerMeetingId");

                    b.Property<Guid?>("CustomerTaskId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Text");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("CustomerMeetingId");

                    b.HasIndex("CustomerTaskId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.CustomerCategoryPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("CustomerCategories");
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.CustomerLevelPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<decimal>("RevenueHighLimit");

                    b.Property<decimal>("RevenueLowLimit");

                    b.HasKey("Id");

                    b.ToTable("CustomerLevels");
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.CustomerMeetingPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("OriginalDate");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerMeetings");
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.CustomerPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CategoryId");

                    b.Property<Guid?>("CityId");

                    b.Property<Guid?>("ConsultantId");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CustomerFolderUrl");

                    b.Property<Guid?>("CustomerLevelId");

                    b.Property<string>("Email");

                    b.Property<string>("LogoUrl");

                    b.Property<string>("MeetingsDescription");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<Guid?>("PlanId");

                    b.Property<Guid?>("PlatformId");

                    b.Property<Guid?>("SituationId");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("StoreAnalysisUrl");

                    b.Property<string>("StoreUrl");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CityId");

                    b.HasIndex("ConsultantId");

                    b.HasIndex("CustomerLevelId");

                    b.HasIndex("PlanId");

                    b.HasIndex("PlatformId");

                    b.HasIndex("SituationId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.CustomerProcessPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CustomerId");

                    b.Property<Guid?>("CustomerMeetingId");

                    b.Property<string>("Description");

                    b.Property<string>("Detail");

                    b.Property<DateTime?>("EndDate");

                    b.Property<DateTime>("EstimatedEndDate");

                    b.Property<Guid>("ModelProcessId");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("CustomerMeetingId");

                    b.HasIndex("ModelProcessId");

                    b.ToTable("CustomerProcesses");
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.CustomerSituationPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("CustomerSituations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dd57b16a-ccf9-4da1-8d3b-d24e59251aff"),
                            Description = "Ativo"
                        },
                        new
                        {
                            Id = new Guid("11a6435d-be18-4427-af65-428eef70c23b"),
                            Description = "Pausado"
                        },
                        new
                        {
                            Id = new Guid("3668344d-2bfa-4c36-aa91-5d7a42cb651f"),
                            Description = "Bloqueado"
                        },
                        new
                        {
                            Id = new Guid("eb71c684-a336-4985-a50f-923b3f439387"),
                            Description = "Cancelado"
                        });
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.CustomerStepPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CustomerProcessId");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("EndDate");

                    b.Property<DateTime>("EstimatedEndDate");

                    b.Property<Guid>("ModelStepId");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("CustomerProcessId");

                    b.HasIndex("ModelStepId");

                    b.ToTable("CustomerSteps");
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.CustomerTaskPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ConsultantId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<Guid>("CustomerId");

                    b.Property<Guid>("CustomerStepId");

                    b.Property<Guid>("CustomerUserId");

                    b.Property<string>("Description");

                    b.Property<int>("Duration");

                    b.Property<DateTime?>("EndDate");

                    b.Property<DateTime>("EstimatedEndDate");

                    b.Property<string>("Instructions");

                    b.Property<string>("MailBody");

                    b.Property<string>("MailSubject");

                    b.Property<Guid>("ModelTaskId");

                    b.Property<Guid>("OwnerId");

                    b.Property<DateTime>("StartDate");

                    b.Property<Guid>("TaskTypeId");

                    b.HasKey("Id");

                    b.HasIndex("ConsultantId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("CustomerStepId");

                    b.HasIndex("CustomerUserId");

                    b.HasIndex("ModelTaskId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("TaskTypeId");

                    b.ToTable("CustomerTasks");
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.ModelProcessPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("Enabled");

                    b.HasKey("Id");

                    b.ToTable("ModelProcesses");
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.ModelStepPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("Enabled");

                    b.Property<Guid>("ProcessId");

                    b.HasKey("Id");

                    b.HasIndex("ProcessId");

                    b.ToTable("ModelSteps");
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.ModelTaskPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("DueDays");

                    b.Property<int>("Duration");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Instructions");

                    b.Property<string>("MailBody");

                    b.Property<string>("MailSubject");

                    b.Property<Guid>("ModelStepId");

                    b.Property<int>("StartAfterDays");

                    b.Property<Guid>("TaskTypeId");

                    b.HasKey("Id");

                    b.HasIndex("ModelStepId");

                    b.HasIndex("TaskTypeId");

                    b.ToTable("ModelTasks");
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.PlanPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Duration");

                    b.HasKey("Id");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.PlatformPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Platforms");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7b64054e-fc81-44e1-a1e2-cfb4bfcf8489"),
                            Name = "Simplo7"
                        });
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.TaskContentPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<Guid>("ModelTaskId");

                    b.Property<int>("PageNumber");

                    b.Property<string>("Title");

                    b.Property<string>("VideoUrl");

                    b.HasKey("Id");

                    b.HasIndex("ModelTaskId");

                    b.ToTable("TaskContent");
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.TaskTypePoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("TaskTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e84138fe-a7c6-4724-865f-1c4cab8be234"),
                            Description = "Consultor"
                        },
                        new
                        {
                            Id = new Guid("a26f516b-6a6f-4159-8f4e-6ca3193bea95"),
                            Description = "Cliente"
                        });
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.UserPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConferenceRoomAddress");

                    b.Property<Guid?>("CustomerId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<Guid>("UserTypeId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.UserTypePoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d10dd961-e131-4618-a235-8b0116aecc91"),
                            Description = "Administrador"
                        },
                        new
                        {
                            Id = new Guid("5f70a257-25a9-42e4-9db3-8623d6e758a5"),
                            Description = "Líder"
                        },
                        new
                        {
                            Id = new Guid("70f24307-54b9-41e3-b4fb-4c86e0202ba4"),
                            Description = "Consultor"
                        },
                        new
                        {
                            Id = new Guid("43c2e87c-35a8-47c0-a4dd-d233b836dd4a"),
                            Description = "Cliente"
                        });
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.CommentPoco", b =>
                {
                    b.HasOne("ConsultingManager.Infra.Database.Models.CustomerPoco", "Customer")
                        .WithMany("Comments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConsultingManager.Infra.Database.Models.CustomerMeetingPoco", "CustomerMeeting")
                        .WithMany("Comments")
                        .HasForeignKey("CustomerMeetingId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConsultingManager.Infra.Database.Models.CustomerTaskPoco", "CustomerTask")
                        .WithMany("Comments")
                        .HasForeignKey("CustomerTaskId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConsultingManager.Infra.Database.Models.UserPoco", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.CustomerMeetingPoco", b =>
                {
                    b.HasOne("ConsultingManager.Infra.Database.Models.CustomerPoco", "Customer")
                        .WithMany("CustomerMeetings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.CustomerPoco", b =>
                {
                    b.HasOne("ConsultingManager.Infra.Database.Models.CustomerCategoryPoco", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConsultingManager.Infra.Database.Models.CityPoco", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConsultingManager.Infra.Database.Models.UserPoco", "Consultant")
                        .WithMany()
                        .HasForeignKey("ConsultantId");

                    b.HasOne("ConsultingManager.Infra.Database.Models.CustomerLevelPoco", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerLevelId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConsultingManager.Infra.Database.Models.PlanPoco", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConsultingManager.Infra.Database.Models.PlatformPoco", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConsultingManager.Infra.Database.Models.CustomerSituationPoco", "Situation")
                        .WithMany()
                        .HasForeignKey("SituationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.CustomerProcessPoco", b =>
                {
                    b.HasOne("ConsultingManager.Infra.Database.Models.CustomerPoco", "Customer")
                        .WithMany("CustomerProcesses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConsultingManager.Infra.Database.Models.CustomerMeetingPoco", "CustomerMeeting")
                        .WithMany("CustomerProcesses")
                        .HasForeignKey("CustomerMeetingId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConsultingManager.Infra.Database.Models.ModelProcessPoco", "ModelProcess")
                        .WithMany()
                        .HasForeignKey("ModelProcessId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.CustomerStepPoco", b =>
                {
                    b.HasOne("ConsultingManager.Infra.Database.Models.CustomerProcessPoco", "CustomerProcess")
                        .WithMany("CustomerSteps")
                        .HasForeignKey("CustomerProcessId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConsultingManager.Infra.Database.Models.ModelStepPoco", "ModelStep")
                        .WithMany()
                        .HasForeignKey("ModelStepId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.CustomerTaskPoco", b =>
                {
                    b.HasOne("ConsultingManager.Infra.Database.Models.UserPoco", "Consultant")
                        .WithMany()
                        .HasForeignKey("ConsultantId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConsultingManager.Infra.Database.Models.CustomerPoco", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConsultingManager.Infra.Database.Models.CustomerStepPoco", "CustomerStep")
                        .WithMany("CustomerTasks")
                        .HasForeignKey("CustomerStepId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConsultingManager.Infra.Database.Models.UserPoco", "CustomerUser")
                        .WithMany()
                        .HasForeignKey("CustomerUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConsultingManager.Infra.Database.Models.ModelTaskPoco", "ModelTask")
                        .WithMany()
                        .HasForeignKey("ModelTaskId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConsultingManager.Infra.Database.Models.UserPoco", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConsultingManager.Infra.Database.Models.TaskTypePoco", "TaskType")
                        .WithMany()
                        .HasForeignKey("TaskTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.ModelStepPoco", b =>
                {
                    b.HasOne("ConsultingManager.Infra.Database.Models.ModelProcessPoco", "Process")
                        .WithMany("ModelSteps")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.ModelTaskPoco", b =>
                {
                    b.HasOne("ConsultingManager.Infra.Database.Models.ModelStepPoco", "ModelStep")
                        .WithMany("ModelTasks")
                        .HasForeignKey("ModelStepId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConsultingManager.Infra.Database.Models.TaskTypePoco", "TaskType")
                        .WithMany()
                        .HasForeignKey("TaskTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.TaskContentPoco", b =>
                {
                    b.HasOne("ConsultingManager.Infra.Database.Models.ModelTaskPoco", "ModelTask")
                        .WithMany("TaskContent")
                        .HasForeignKey("ModelTaskId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ConsultingManager.Infra.Database.Models.UserPoco", b =>
                {
                    b.HasOne("ConsultingManager.Infra.Database.Models.CustomerPoco", "Customer")
                        .WithMany("Users")
                        .HasForeignKey("CustomerId");

                    b.HasOne("ConsultingManager.Infra.Database.Models.UserTypePoco", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
