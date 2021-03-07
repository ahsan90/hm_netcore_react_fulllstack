using Microsoft.EntityFrameworkCore;
using Domain;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Test>()
                .HasData(
                    new Test { Id = 1, Name = "Test 1" },
                    new Test { Id = 2, Name = "Test 2" },
                    new Test { Id = 3, Name = "Test 3" }
                );

        }
    }
}
