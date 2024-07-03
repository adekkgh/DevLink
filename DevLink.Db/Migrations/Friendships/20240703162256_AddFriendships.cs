using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevLink.Db.Migrations.Friendships
{
    public partial class AddFriendships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FriendId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => new { x.UserId, x.FriendId });
                    table.ForeignKey(
                        name: "FK_Friendships_Users_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friendships_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "Email", "FirstName", "Gender", "LastName", "Password", "Phone", "Role", "UserName" },
                values: new object[] { new Guid("00000000-aaaa-aaaa-aaaa-555555555555"), "Владикавказ", "", "Друг", "Мужской", "1", "1234", "", "user", "friend1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "Email", "FirstName", "Gender", "LastName", "Password", "Phone", "Role", "UserName" },
                values: new object[] { new Guid("00000000-aaaa-aaaa-aaaa-666666666666"), "Владикавказ", "", "Друг", "Мужской", "2", "1234", "", "user", "friend2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "Email", "FirstName", "Gender", "LastName", "Password", "Phone", "Role", "UserName" },
                values: new object[] { new Guid("00000000-aaaa-aaaa-aaaa-777777777777"), "Владикавказ", "", "Друг", "Мужской", "3", "1234", "", "user", "friend3" });

            migrationBuilder.InsertData(
                table: "Friendships",
                columns: new[] { "FriendId", "UserId" },
                values: new object[] { new Guid("00000000-aaaa-aaaa-aaaa-555555555555"), new Guid("00000000-aaaa-aaaa-aaaa-000000000000") });

            migrationBuilder.InsertData(
                table: "Friendships",
                columns: new[] { "FriendId", "UserId" },
                values: new object[] { new Guid("00000000-aaaa-aaaa-aaaa-666666666666"), new Guid("00000000-aaaa-aaaa-aaaa-000000000000") });

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_FriendId",
                table: "Friendships",
                column: "FriendId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-aaaa-aaaa-aaaa-777777777777"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-aaaa-aaaa-aaaa-555555555555"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-aaaa-aaaa-aaaa-666666666666"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserId",
                table: "Users",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
