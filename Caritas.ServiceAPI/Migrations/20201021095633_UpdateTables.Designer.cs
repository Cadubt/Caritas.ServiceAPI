﻿// <auto-generated />
using System;
using Caritas.ServiceAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Caritas.ServiceAPI.Migrations
{
    [DbContext(typeof(CaritasContext))]
    [Migration("20201021095633_UpdateTables")]
    partial class UpdateTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Caritas.ServiceAPI.Models.KinshipModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KinName");

                    b.HasKey("Id");

                    b.ToTable("Kinships","shelt");
                });

            modelBuilder.Entity("Caritas.ServiceAPI.Models.ResponsibleModel", b =>
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

            modelBuilder.Entity("Caritas.ServiceAPI.Models.ScheduleSheetModel", b =>
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

            modelBuilder.Entity("Caritas.ServiceAPI.Models.ShelteredModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("Age");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("BloodTyping");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<DateTime>("EntryDate");

                    b.Property<string>("Name");

                    b.Property<string>("PerfilImage");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Sheltereds","shelt");
                });

            modelBuilder.Entity("Caritas.ServiceAPI.Models.UserModel", b =>
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
#pragma warning restore 612, 618
        }
    }
}
