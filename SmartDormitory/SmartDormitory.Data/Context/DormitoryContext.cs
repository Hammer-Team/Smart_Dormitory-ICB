using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartDormitory.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDormitory.Data.Context
{
    public class DormitoryContext : IdentityDbContext<User>
    {
        public DbSet<Sensor> Sensors { get; set; }

        public DormitoryContext(DbContextOptions<DormitoryContext> options)
            :base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
