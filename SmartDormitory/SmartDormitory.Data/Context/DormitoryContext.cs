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
        public DbSet<SensorFromUser> Sensors { get; set; }
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
                //jsonManager.RegisterJson<Sensor>("sensors.json");
                //jsonManager.RegisterJson<SensorType>("sensorTypes.json");

                //var usersJson = File.ReadAllText(@".\JsonData\users.json");
                //var userRolesJson = File.ReadAllText(@".\JsonData\roles.json");
                //var rolesJson = File.ReadAllText(@".\JsonData\roles.json");
                //var sensorsJson = File.ReadAllText(@".\JsonData\roles.json");

                //var users = JsonConvert.DeserializeObject<User[]>(usersJson);
                //var roles = JsonConvert.DeserializeObject<IdentityRole[]>(rolesJson);
                //var userRoles = JsonConvert.DeserializeObject<IdentityUserRole<string>[]>(userRolesJson);

                //modelBuilder.Entity<User>().HasData(users);
                //modelBuilder.Entity<IdentityRole>().HasData(roles);
                //modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);

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
