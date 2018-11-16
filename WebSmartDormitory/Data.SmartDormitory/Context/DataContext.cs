using Data.SmartDormitory.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Data.SmartDormitory.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<SensorDataHistory> SensorDataHistories { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        private void LoadJson(ModelBuilder modelBuilder)
        {
            try
            {
                var usersAsJson = File.ReadAllText(@"..\Data.SmartDormitory\JsonLoad\users.json");
                var sensorAsJson = File.ReadAllText(@"..\Data.SmartDormitory\JsonLoad\sensors.json");

                var users = JsonConvert.DeserializeObject<User[]>(usersAsJson);
                var sensors = JsonConvert.DeserializeObject<Sensor[]>(sensorAsJson);
                var sensorHistory = JsonConvert.DeserializeObject<SensorDataHistory[]>(sensorAsJson);

                modelBuilder.Entity<User>().HasData(users);
                modelBuilder.Entity<Sensor>().HasData(sensors);
                modelBuilder.Entity<SensorDataHistory>().HasData(sensors);
            }
            catch (Exception)
            {
                return;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            LoadJson(modelBuilder);

            modelBuilder.Entity<User>().Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<User>().Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Sensor>().Property(sen => sen.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Sensor>().Property(sen => sen.URLSensorData)
                .IsRequired();
            modelBuilder.Entity<Sensor>().Property(sen => sen.Name)
                .IsRequired();
            modelBuilder.Entity<Sensor>().Property(sen => sen.PoolInterval)
                .IsRequired();
            modelBuilder.Entity<Sensor>().Property(sen => sen.IsPublic)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
