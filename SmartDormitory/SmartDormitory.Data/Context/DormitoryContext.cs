using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SmartDormitory.Data.JsonTools;
using SmartDormitory.Data.Models;
using System;
using System.IO;

namespace SmartDormitory.Data.Context
{
    public class DormitoryContext : IdentityDbContext<User>
    {
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<SensorsFromUser> GetSensorsFromUsers { get; set; }
        public DbSet<SensorType> SensorTypes { get; set; }

        public DormitoryContext(DbContextOptions<DormitoryContext> options)
            : base(options)
        {

        }

        private void LoadJsonDataInDatabase(ModelBuilder modelBuilder)
        {
            var jsonManager = new JsonManager(modelBuilder);

            //try
            //{
                jsonManager.RegisterJson<User>("users.json");
                jsonManager.RegisterJson<IdentityUserRole<string>>("userRoles.json");
                jsonManager.RegisterJson<IdentityRole>("roles.json");
            //}
            //catch (Exception)
            //{
            //    return;
            //}
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            LoadJsonDataInDatabase(modelBuilder);

            modelBuilder.Entity<User>().Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<User>().Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(25);

            base.OnModelCreating(modelBuilder);
        }
    }
}
