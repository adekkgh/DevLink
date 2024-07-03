using DevLink.Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DevLink.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Friendship> Friendships { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Friendship>()
                .HasKey(f => new { f.UserId, f.FriendId });

            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.User)
                .WithMany(u => u.Friendships)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.Friend)
                .WithMany()
                .HasForeignKey(f => f.FriendId)
                .OnDelete(DeleteBehavior.Restrict);

            var admin = new User()
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
            };

            var testFriends = new List<User>()
            {
                new User()
                {
                    Id = new Guid("00000000-aaaa-aaaa-aaaa-555555555555"),
                    FirstName = "Друг",
                    LastName = "1",
                    UserName = "friend1",
                    Email = "",
                    Phone = "",
                    City = "Владикавказ",
                    Gender = "Мужской",
                    Password = "1234",
                    Role = "user"
                },
                new User()
                {
                    Id = new Guid("00000000-aaaa-aaaa-aaaa-666666666666"),
                    FirstName = "Друг",
                    LastName = "2",
                    UserName = "friend2",
                    Email = "",
                    Phone = "",
                    City = "Владикавказ",
                    Gender = "Мужской",
                    Password = "1234",
                    Role = "user"
                },
                new User()
                {
                    Id = new Guid("00000000-aaaa-aaaa-aaaa-777777777777"),
                    FirstName = "Друг",
                    LastName = "3",
                    UserName = "friend3",
                    Email = "",
                    Phone = "",
                    City = "Владикавказ",
                    Gender = "Мужской",
                    Password = "1234",
                    Role = "user"
                }
            };

            modelBuilder.Entity<User>().HasData(new List<User>()
            {
                admin,
                testFriends[0],
                testFriends[1],
                testFriends[2],
                new User()
                {
                    Id = new Guid("00000000-aaaa-aaaa-aaaa-111111111111"),
                    FirstName = "Арсен",
                    LastName = "Гиоев",
                    UserName = "adek",
                    Email = "gioev.arsen15@list.ru",
                    Phone = "+79888320415",
                    City = "Владикавказ",
                    Gender = "Мужской",
                    Password = "adek1234",
                    Role = "dev"
                },
                new User()
                {
                    Id = new Guid("00000000-aaaa-aaaa-aaaa-222222222222"),
                    FirstName = "Георгий",
                    LastName = "Гуссаов",
                    UserName = "goose",
                    Email = "geor@mail.ru",
                    Phone = "",
                    City = "Владикавказ",
                    Gender = "Мужской",
                    Password = "geor1234",
                    Role = "dev"
                },
                new User()
                {
                    Id = new Guid("00000000-aaaa-aaaa-aaaa-333333333333"),
                    FirstName = "Олег",
                    LastName = "Ярлынский",
                    UserName = "olegjarl",
                    Email = "oleg@mail.ru",
                    Phone = "",
                    City = "Владикавказ",
                    Gender = "Мужской",
                    Password = "oleg1234",
                    Role = "dev"
                },
                new User()
                {
                    Id = new Guid("00000000-aaaa-aaaa-aaaa-444444444444"),
                    FirstName = "Артур",
                    LastName = "Санакоев",
                    UserName = "gleam",
                    Email = "arthur@mail.ru",
                    Phone = "",
                    City = "Владикавказ",
                    Gender = "Мужской",
                    Password = "arthur1234",
                    Role = "dev"
                }
            });

            modelBuilder.Entity<Friendship>().HasData(
                new Friendship
                {
                    UserId = admin.Id,
                    FriendId = testFriends[0].Id
                },
                new Friendship
                {
                    UserId = admin.Id,
                    FriendId = testFriends[1].Id
                }
            );
        }
    }
}
