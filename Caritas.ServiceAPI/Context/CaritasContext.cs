using Caritas.ServiceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Context
{
    public class CaritasContext : DbContext
    {
        public CaritasContext(DbContextOptions<CaritasContext> options)
            : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ShelteredModel> Sheltereds { get; set; }
        public DbSet<ResponsibleModel> Responsibles { get; set; }
        public DbSet<KinshipModel> Kinships { get; set; }
        public DbSet<ScheduleSheetModel> ScheduleSheets { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.Entity<UserModel>().ToTable("Users", "usr");
            modelBuilder.Entity<KinshipModel>().ToTable("Kinships", "shelt");
            modelBuilder.Entity<ResponsibleModel>().ToTable("Responsibles", "shelt");
            modelBuilder.Entity<ShelteredModel>().ToTable("Sheltereds", "shelt");
            modelBuilder.Entity<ScheduleSheetModel>().ToTable("ScheduleSheets", "shelt");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    }
}
