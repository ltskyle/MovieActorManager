using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _521Assignment3.Data.Migrations
{
    public partial class addingactorpercent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PercentScore",
                table: "Actor",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PercentScore",
                table: "Actor");
        }
    }
}
