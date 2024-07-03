﻿// <auto-generated />
using System;
using DevLink.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DevLink.Db.Migrations.Friendships
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240703163709_RefactorFriendships")]
    partial class RefactorFriendships
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DevLink.Db.Models.Friendship", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FriendId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "FriendId");

                    b.HasIndex("FriendId");

                    b.ToTable("Friendships");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("00000000-aaaa-aaaa-aaaa-000000000000"),
                            FriendId = new Guid("00000000-aaaa-aaaa-aaaa-555555555555")
                        },
                        new
                        {
                            UserId = new Guid("00000000-aaaa-aaaa-aaaa-000000000000"),
                            FriendId = new Guid("00000000-aaaa-aaaa-aaaa-666666666666")
                        });
                });

            modelBuilder.Entity("DevLink.Db.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-aaaa-aaaa-aaaa-000000000000"),
                            City = "",
                            Email = "admin@admin.ru",
                            FirstName = "admin",
                            Gender = "",
                            LastName = "admin",
                            Password = "aDMiN",
                            Phone = "",
                            Role = "admin",
                            UserName = "admin"
                        },
                        new
                        {
                            Id = new Guid("00000000-aaaa-aaaa-aaaa-555555555555"),
                            City = "Владикавказ",
                            Email = "",
                            FirstName = "Друг",
                            Gender = "Мужской",
                            LastName = "1",
                            Password = "1234",
                            Phone = "",
                            Role = "user",
                            UserName = "friend1"
                        },
                        new
                        {
                            Id = new Guid("00000000-aaaa-aaaa-aaaa-666666666666"),
                            City = "Владикавказ",
                            Email = "",
                            FirstName = "Друг",
                            Gender = "Мужской",
                            LastName = "2",
                            Password = "1234",
                            Phone = "",
                            Role = "user",
                            UserName = "friend2"
                        },
                        new
                        {
                            Id = new Guid("00000000-aaaa-aaaa-aaaa-777777777777"),
                            City = "Владикавказ",
                            Email = "",
                            FirstName = "Друг",
                            Gender = "Мужской",
                            LastName = "3",
                            Password = "1234",
                            Phone = "",
                            Role = "user",
                            UserName = "friend3"
                        },
                        new
                        {
                            Id = new Guid("00000000-aaaa-aaaa-aaaa-111111111111"),
                            City = "Владикавказ",
                            Email = "gioev.arsen15@list.ru",
                            FirstName = "Арсен",
                            Gender = "Мужской",
                            LastName = "Гиоев",
                            Password = "adek1234",
                            Phone = "+79888320415",
                            Role = "dev",
                            UserName = "adek"
                        },
                        new
                        {
                            Id = new Guid("00000000-aaaa-aaaa-aaaa-222222222222"),
                            City = "Владикавказ",
                            Email = "geor@mail.ru",
                            FirstName = "Георгий",
                            Gender = "Мужской",
                            LastName = "Гуссаов",
                            Password = "geor1234",
                            Phone = "",
                            Role = "dev",
                            UserName = "goose"
                        },
                        new
                        {
                            Id = new Guid("00000000-aaaa-aaaa-aaaa-333333333333"),
                            City = "Владикавказ",
                            Email = "oleg@mail.ru",
                            FirstName = "Олег",
                            Gender = "Мужской",
                            LastName = "Ярлынский",
                            Password = "oleg1234",
                            Phone = "",
                            Role = "dev",
                            UserName = "olegjarl"
                        },
                        new
                        {
                            Id = new Guid("00000000-aaaa-aaaa-aaaa-444444444444"),
                            City = "Владикавказ",
                            Email = "arthur@mail.ru",
                            FirstName = "Артур",
                            Gender = "Мужской",
                            LastName = "Санакоев",
                            Password = "arthur1234",
                            Phone = "",
                            Role = "dev",
                            UserName = "gleam"
                        });
                });

            modelBuilder.Entity("DevLink.Db.Models.Friendship", b =>
                {
                    b.HasOne("DevLink.Db.Models.User", "Friend")
                        .WithMany()
                        .HasForeignKey("FriendId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DevLink.Db.Models.User", "User")
                        .WithMany("Friendships")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Friend");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DevLink.Db.Models.User", b =>
                {
                    b.Navigation("Friendships");
                });
#pragma warning restore 612, 618
        }
    }
}