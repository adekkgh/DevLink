using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevLink.Db.Migrations
{
    public partial class NewUsersToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "Email", "FirstName", "Gender", "LastName", "Password", "Phone", "Role", "UserId", "UserName" },
                values: new object[,]
                {
                    { new Guid("00000000-aaaa-aaaa-aaaa-111111111111"), "Владикавказ", "gioev.arsen15@list.ru", "Арсен", "Мужской", "Гиоев", "adek1234", "+79888320415", "dev", null, "adek" },
                    { new Guid("00000000-aaaa-aaaa-aaaa-222222222222"), "Владикавказ", "geor@mail.ru", "Георгий", "Мужской", "Гуссаов", "geor1234", "", "dev", null, "goose" },
                    { new Guid("00000000-aaaa-aaaa-aaaa-333333333333"), "Владикавказ", "oleg@mail.ru", "Олег", "Мужской", "Ярлынский", "oleg1234", "", "dev", null, "olegjarl" },
                    { new Guid("00000000-aaaa-aaaa-aaaa-444444444444"), "Владикавказ", "arthur@mail.ru", "Артур", "Мужской", "Санакоев", "arthur1234", "", "dev", null, "gleam" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-aaaa-aaaa-aaaa-111111111111"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-aaaa-aaaa-aaaa-222222222222"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-aaaa-aaaa-aaaa-333333333333"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-aaaa-aaaa-aaaa-444444444444"));
        }
    }
}
