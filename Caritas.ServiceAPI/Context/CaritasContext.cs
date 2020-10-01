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
        //public DbSet<Sheltered> Sheltereds { get; set; }
        //public DbSet<Responsible> Responsibles { get; set; }
        //public DbSet<Kinship> Kinships { get; set; }
        //public DbSet<ScheduleSheet> ScheduleSheets { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.Entity<UserModel>().ToTable("Users", "usr");
            //modelBuilder.Entity<Kinship>().ToTable("Kinships", "shelt");
            //modelBuilder.Entity<Responsible>().ToTable("Responsibles", "shelt");
            //modelBuilder.Entity<Sheltered>().ToTable("Sheltereds", "shelt");
            //modelBuilder.Entity<ScheduleSheet>().ToTable("ScheduleSheets", "shelt");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    }
}
