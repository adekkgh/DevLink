using DevLink.Db.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DevLink.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = new Guid("00000000-aaaa-aaaa-aaaa-000000000000"),
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin",
                Email = "admin@admin.ru",
                Phone = "",
                City = "",
                Gender = "",
                Password = "aDMiN",
                Role = "admin"
            });
        }
    }
}
