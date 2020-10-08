using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace twitCloneService.Migrations
{
    public partial class twitDBInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TweetData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    userId = table.Column<Guid>(nullable: false),
                    message = table.Column<string>(nullable: true),
                    postData = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TweetData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TweetData");
        }
    }
}
