using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace News.Infrastructure.Migrations
{
    public partial class RatingAndComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "news",
                table: "content",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Headline",
                schema: "news",
                table: "content",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                schema: "news",
                table: "content",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.CreateTable(
                name: "comment",
                schema: "news",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(maxLength: 1000, nullable: false),
                    AuthorId = table.Column<string>(nullable: true),
                    ArticleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comment_articles_ArticleId",
                        column: x => x.ArticleId,
                        principalSchema: "news",
                        principalTable: "articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comment_authors_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "news",
                        principalTable: "authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rating",
                schema: "news",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rating", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comment_ArticleId",
                schema: "news",
                table: "comment",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_AuthorId",
                schema: "news",
                table: "comment",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment",
                schema: "news");

            migrationBuilder.DropTable(
                name: "rating",
                schema: "news");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "news",
                table: "content",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "Headline",
                schema: "news",
                table: "content",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                schema: "news",
                table: "content",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
