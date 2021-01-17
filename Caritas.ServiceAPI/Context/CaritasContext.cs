using Caritas.ServiceAPI.Context.Entities;
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

        public DbSet<User> Users { get; set; }
        public DbSet<Sheltered> Sheltereds { get; set; }
        public DbSet<Responsible> Responsibles { get; set; }
        public DbSet<Kinship> Kinships { get; set; }
        public DbSet<ScheduleSheet> ScheduleSheets { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Permission_Menu> Permission_Menus { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.Entity<User>().ToTable("Users", "usr");
            modelBuilder.Entity<Kinship>().ToTable("Kinships", "shelt");
            modelBuilder.Entity<Responsible>().ToTable("Responsibles", "shelt");
            modelBuilder.Entity<Sheltered>().ToTable("Sheltereds", "shelt");
            modelBuilder.Entity<ScheduleSheet>().ToTable("ScheduleSheets", "shelt");
            modelBuilder.Entity<Status>().ToTable("Statuses", "shelt");
            modelBuilder.Entity<Menu>().ToTable("Menus", "usr");
            modelBuilder.Entity<Permission>().ToTable("Permissions", "usr");
            modelBuilder.Entity<Permission_Menu>().ToTable("Permission_Menus", "usr");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    }
}
