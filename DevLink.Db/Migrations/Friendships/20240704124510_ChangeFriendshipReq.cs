using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevLink.Db.Migrations.Friendships
{
    public partial class ChangeFriendshipReq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AcceptorId",
                table: "FriendshipRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SenderId",
                table: "FriendshipRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptorId",
                table: "FriendshipRequests");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "FriendshipRequests");
        }
    }
}
