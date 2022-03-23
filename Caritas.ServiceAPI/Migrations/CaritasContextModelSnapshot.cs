﻿// <auto-generated />
using System;
using Caritas.ServiceAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Caritas.ServiceAPI.Migrations
{
    [DbContext(typeof(CaritasContext))]
    partial class CaritasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Caritas.ServiceAPI.Context.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Kinship");

                    b.Property<string>("Name");

                    b.Property<string>("Neighborhood");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Contacts","shelt");
                });

            modelBuilder.Entity("Caritas.ServiceAPI.Context.Entities.GeneralSheltInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnyOccurrence");

                    b.Property<string>("ControlledMedicine");

                    b.Property<string>("Disability");

                    b.Property<bool>("Drinker");

                    b.Property<bool>("FeedsItself");

                    b.Property<bool>("GoOutAline");

                    b.Property<bool>("HasMedicalTreatment");

                    b.Property<string>("HealthProblem");

                    b.Property<string>("HowMoves");

                    b.Property<string>("MedicalInsurance");

                    b.Property<bool>("Smoker");

                    b.Property<string>("WhichHospital");

                    b.HasKey("Id");

                    b.ToTable("GeneralSheltInfos","shelt");
                });

            modelBuilder.Entity("Caritas.ServiceAPI.Context.Entities.Kinship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KinName");

                    b.HasKey("Id");

                    b.ToTable("Kinships","shelt");
                });

            modelBuilder.Entity("Caritas.ServiceAPI.Context.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MenuIcon");

                    b.Property<string>("MenuTittle");

                    b.Property<string>("PageName");

                    b.HasKey("Id");

                    b.ToTable("Menus","usr");
                });

            modelBuilder.Entity("Caritas.ServiceAPI.Context.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PermissionName");

                    b.Property<bool>("PermissionStatus");

                    b.HasKey("Id");

                    b.ToTable("Permissions","usr");
                });

            modelBuilder.Entity("Caritas.ServiceAPI.Context.Entities.Permission_Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Authorization");

                    b.Property<int>("MenuId");

                    b.Property<int>("PermissionId");

                    b.HasKey("Id");

                    b.ToTable("Permission_Menus","usr");
                });

            modelBuilder.Entity("Caritas.ServiceAPI.Context.Entities.Responsible", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("KinshipId");

                    b.Property<string>("Phone");

                    b.Property<string>("ResponsibleName");

                    b.HasKey("Id");

                    b.ToTable("Responsibles","shelt");
                });

            modelBuilder.Entity("Caritas.ServiceAPI.Context.Entities.ScheduleSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<DateTime>("InterviewDate");

                    b.Property<int>("KinshipId");

                    b.Property<string>("Observation");

                    b.Property<string>("ResponsibleAddress");

                    b.Property<string>("ResponsibleName");

                    b.Property<string>("ResponsiblePhone");

                    b.Property<DateTime>("ScheduleDate");

                    b.Property<string>("ScheduleResponsible");

                    b.Property<string>("ShelteredAddress");

                    b.Property<int>("ShelteredAge");

                    b.Property<string>("ShelteredName");

                    b.Property<string>("ShelteredPhone");

                    b.HasKey("Id");

                    b.ToTable("ScheduleSheets","shelt");
                });

            modelBuilder.Entity("Caritas.ServiceAPI.Context.Entities.Sheltered", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AcceptsToBeWelcomed");

                    b.Property<string>("Address");

                    b.Property<int>("Age");

                    b.Property<string>("AnotherInstitutionName");

                    b.Property<string>("ApprovalStatus");

                    b.Property<bool>("BeenAnotherInstitution");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("BloodTyping");

                    b.Property<string>("City");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<DateTime?>("DeceaseAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<DateTime>("EntryDate");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<int?>("GeneralSheltInfoId");

                    b.Property<bool>("HasIncome");

                    b.Property<string>("HowFindOutShelter");

                    b.Property<decimal>("IncomeAmount");

                    b.Property<string>("MaritalStatus");

                    b.Property<string>("Name");

                    b.Property<string>("Nationality");

                    b.Property<string>("Neighborhood");

                    b.Property<string>("PerfilImage");

                    b.Property<string>("Phone");

                    b.Property<string>("ResidesIn");

                    b.Property<string>("SourceOfIncome");

                    b.Property<int>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("GeneralSheltInfoId");

                    b.ToTable("Sheltereds","shelt");
                });

            modelBuilder.Entity("Caritas.ServiceAPI.Context.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Statuses","shelt");
                });

            modelBuilder.Entity("Caritas.ServiceAPI.Context.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int>("Role");

                    b.HasKey("Id");

                    b.ToTable("Users","usr");
                });

            modelBuilder.Entity("Caritas.ServiceAPI.Context.Entities.Visitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress");

                    b.Property<int>("KinshipId");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("RG");

                    b.Property<int>("ShelteredId");

                    b.Property<DateTime>("VisitDate");

                    b.HasKey("Id");

                    b.ToTable("Visitors","shelt");
                });

            modelBuilder.Entity("Caritas.ServiceAPI.Context.Entities.Sheltered", b =>
                {
                    b.HasOne("Caritas.ServiceAPI.Context.Entities.GeneralSheltInfo", "GeneralSheltInfo")
                        .WithMany()
                        .HasForeignKey("GeneralSheltInfoId");
                });
#pragma warning restore 612, 618
        }
    }
}
