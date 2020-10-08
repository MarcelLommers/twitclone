using Microsoft.EntityFrameworkCore.Migrations;

namespace twitCloneService.Migrations
{
    public partial class updateContextNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TweetData_UserData_userId",
                table: "TweetData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserData",
                table: "UserData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TweetData",
                table: "TweetData");

            migrationBuilder.RenameTable(
                name: "UserData",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "TweetData",
                newName: "Tweets");

            migrationBuilder.RenameIndex(
                name: "IX_TweetData_userId",
                table: "Tweets",
                newName: "IX_Tweets_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tweets",
                table: "Tweets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tweets_Users_userId",
                table: "Tweets",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tweets_Users_userId",
                table: "Tweets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tweets",
                table: "Tweets");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserData");

            migrationBuilder.RenameTable(
                name: "Tweets",
                newName: "TweetData");

            migrationBuilder.RenameIndex(
                name: "IX_Tweets_userId",
                table: "TweetData",
                newName: "IX_TweetData_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserData",
                table: "UserData",
                column: "userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TweetData",
                table: "TweetData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TweetData_UserData_userId",
                table: "TweetData",
                column: "userId",
                principalTable: "UserData",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
