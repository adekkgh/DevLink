using Microsoft.EntityFrameworkCore.Migrations;

namespace DevLink.Db.Migrations.Friendships
{
    public partial class ChangeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendshipRequests_Users_AcceptorId",
                table: "FriendshipRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendshipRequests_Users_SenderId",
                table: "FriendshipRequests");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "FriendshipRequests",
                newName: "UserId1");

            migrationBuilder.RenameColumn(
                name: "AcceptorId",
                table: "FriendshipRequests",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FriendshipRequests_SenderId",
                table: "FriendshipRequests",
                newName: "IX_FriendshipRequests_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_FriendshipRequests_AcceptorId",
                table: "FriendshipRequests",
                newName: "IX_FriendshipRequests_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendshipRequests_Users_UserId",
                table: "FriendshipRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendshipRequests_Users_UserId1",
                table: "FriendshipRequests",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendshipRequests_Users_UserId",
                table: "FriendshipRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendshipRequests_Users_UserId1",
                table: "FriendshipRequests");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "FriendshipRequests",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "FriendshipRequests",
                newName: "AcceptorId");

            migrationBuilder.RenameIndex(
                name: "IX_FriendshipRequests_UserId1",
                table: "FriendshipRequests",
                newName: "IX_FriendshipRequests_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_FriendshipRequests_UserId",
                table: "FriendshipRequests",
                newName: "IX_FriendshipRequests_AcceptorId");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendshipRequests_Users_AcceptorId",
                table: "FriendshipRequests",
                column: "AcceptorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendshipRequests_Users_SenderId",
                table: "FriendshipRequests",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
