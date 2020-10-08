using Microsoft.EntityFrameworkCore.Migrations;

namespace twitCloneService.Migrations
{
    public partial class CapitaliseModelProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tweets_Users_userId",
                table: "Tweets");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Tweets",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "postDate",
                table: "Tweets",
                newName: "PostDate");

            migrationBuilder.RenameColumn(
                name: "message",
                table: "Tweets",
                newName: "Message");

            migrationBuilder.RenameIndex(
                name: "IX_Tweets_userId",
                table: "Tweets",
                newName: "IX_Tweets_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tweets_Users_UserId",
                table: "Tweets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tweets_Users_UserId",
                table: "Tweets");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tweets",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "PostDate",
                table: "Tweets",
                newName: "postDate");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Tweets",
                newName: "message");

            migrationBuilder.RenameIndex(
                name: "IX_Tweets_UserId",
                table: "Tweets",
                newName: "IX_Tweets_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tweets_Users_userId",
                table: "Tweets",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
