using Microsoft.EntityFrameworkCore;
using Domain;
using System;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Test>()
                .HasData(
                    new Test { Id = 1, Name = "Test 1" },
                    new Test { Id = 2, Name = "Test 2" },
                    new Test { Id = 3, Name = "Test 3" }
                );

        }
    }
}
