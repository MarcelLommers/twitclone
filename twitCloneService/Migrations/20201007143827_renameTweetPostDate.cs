using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace twitCloneService.Migrations
{
    public partial class renameTweetPostDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "postDate",
                table: "Tweets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.Sql("UPDATE dbo.Tweets SET postDate = postData");

            migrationBuilder.DropColumn(
                name: "postData",
                table: "Tweets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "postData",
                table: "Tweets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.Sql("UPDATE dbo.Tweets SET postData = postDate");

            migrationBuilder.DropColumn(
                name: "postDate",
                table: "Tweets");

        }
    }
}
