using Microsoft.EntityFrameworkCore.Migrations;

namespace News.Infrastructure.Migrations
{
    public partial class RatingForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                schema: "news",
                table: "rating",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                schema: "news",
                table: "rating",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_rating_ArticleId",
                schema: "news",
                table: "rating",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_rating_AuthorId",
                schema: "news",
                table: "rating",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_rating_articles_ArticleId",
                schema: "news",
                table: "rating",
                column: "ArticleId",
                principalSchema: "news",
                principalTable: "articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_rating_authors_AuthorId",
                schema: "news",
                table: "rating",
                column: "AuthorId",
                principalSchema: "news",
                principalTable: "authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rating_articles_ArticleId",
                schema: "news",
                table: "rating");

            migrationBuilder.DropForeignKey(
                name: "FK_rating_authors_AuthorId",
                schema: "news",
                table: "rating");

            migrationBuilder.DropIndex(
                name: "IX_rating_ArticleId",
                schema: "news",
                table: "rating");

            migrationBuilder.DropIndex(
                name: "IX_rating_AuthorId",
                schema: "news",
                table: "rating");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                schema: "news",
                table: "rating");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                schema: "news",
                table: "rating");
        }
    }
}
