using Microsoft.EntityFrameworkCore.Migrations;

namespace News.Infrastructure.Migrations
{
    public partial class CommentAndRatingFieldNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                schema: "news",
                table: "rating",
                newName: "Rate");

            migrationBuilder.RenameColumn(
                name: "Value",
                schema: "news",
                table: "comment",
                newName: "Content");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rate",
                schema: "news",
                table: "rating",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Content",
                schema: "news",
                table: "comment",
                newName: "Value");
        }
    }
}
