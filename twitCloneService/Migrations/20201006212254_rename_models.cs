using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace twitCloneService.Migrations
{
    public partial class rename_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TweetData_UserData_UserModeluserId",
                table: "TweetData");

            migrationBuilder.DropIndex(
                name: "IX_TweetData_UserModeluserId",
                table: "TweetData");

            migrationBuilder.DropColumn(
                name: "UserModeluserId",
                table: "TweetData");

            migrationBuilder.CreateIndex(
                name: "IX_TweetData_userId",
                table: "TweetData",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_TweetData_UserData_userId",
                table: "TweetData",
                column: "userId",
                principalTable: "UserData",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TweetData_UserData_userId",
                table: "TweetData");

            migrationBuilder.DropIndex(
                name: "IX_TweetData_userId",
                table: "TweetData");

            migrationBuilder.AddColumn<Guid>(
                name: "UserModeluserId",
                table: "TweetData",
                type: "uniqueidentifier",
                nullable: true);

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
    }
}
