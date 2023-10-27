using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _521Assignment3.Data.Migrations
{
    public partial class addingredditformovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "RedditPost",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OverallSentiment",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "PercentScore",
                table: "Movie",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_RedditPost_MovieId",
                table: "RedditPost",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_RedditPost_Movie_MovieId",
                table: "RedditPost",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RedditPost_Movie_MovieId",
                table: "RedditPost");

            migrationBuilder.DropIndex(
                name: "IX_RedditPost_MovieId",
                table: "RedditPost");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "RedditPost");

            migrationBuilder.DropColumn(
                name: "OverallSentiment",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "PercentScore",
                table: "Movie");
        }
    }
}
