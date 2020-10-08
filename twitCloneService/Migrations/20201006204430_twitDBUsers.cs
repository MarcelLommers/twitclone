using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace twitCloneService.Migrations
{
    public partial class twitDBUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserModeluserId",
                table: "TweetData",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserData",
                columns: table => new
                {
                    userId = table.Column<Guid>(nullable: false),
                    userName = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserData", x => x.userId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TweetData_UserModeluserId",
                table: "TweetData",
                column: "UserModeluserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TweetData_UserData_UserModeluserId",
                table: "TweetData",
                column: "UserModeluserId",
                principalTable: "UserData",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TweetData_UserData_UserModeluserId",
                table: "TweetData");

            migrationBuilder.DropTable(
                name: "UserData");

            migrationBuilder.DropIndex(
                name: "IX_TweetData_UserModeluserId",
                table: "TweetData");

            migrationBuilder.DropColumn(
                name: "UserModeluserId",
                table: "TweetData");
        }
    }
}
