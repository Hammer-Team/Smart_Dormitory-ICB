using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SmartDormitory.Data.Models;
using System.IO;

namespace SmartDormitory.Data.Context
{
    public class DormitoryContext : IdentityDbContext<User>
    {
        public DbSet<Sensor> Sensors { get; set; }

        public DormitoryContext(DbContextOptions<DormitoryContext> options)
            : base(options)
        {
        }

        private void LoadJsonDataInDatabase(ModelBuilder modelBuilder)
        {
            try
            {
                var usersJson = File.ReadAllText(@"..\SmartDormitory.Data\JsonData\users.json");
                var userRolesJson = File.ReadAllText(@"..\SmartDormitory.Data\JsonData\userRoles.json");
                var rolesJson = File.ReadAllText(@"..\SmartDormitory.Data\JsonData\roles.json");

                var users = JsonConvert.DeserializeObject<User[]>(usersJson);
                var roles = JsonConvert.DeserializeObject<IdentityRole[]>(rolesJson);
                var userRoles = JsonConvert.DeserializeObject<IdentityUserRole<string>[]>(userRolesJson);

                modelBuilder.Entity<User>().HasData(users);
                modelBuilder.Entity<IdentityRole>().HasData(roles);
                modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);

            }
            catch (System.Exception)
            {
                return;
            }
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
