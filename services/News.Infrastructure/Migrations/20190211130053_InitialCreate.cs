using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace News.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "news");

            migrationBuilder.CreateTable(
                name: "authors",
                schema: "news",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 450, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "content",
                schema: "news",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Headline = table.Column<string>(maxLength: 200, nullable: true),
                    Body = table.Column<string>(maxLength: 1000, nullable: false),
                    ImageUri = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_content", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "articles",
                schema: "news",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentId = table.Column<int>(nullable: true),
                    AuthorId = table.Column<string>(nullable: true),
                    PublicationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_articles_authors_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "news",
                        principalTable: "authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_articles_content_ContentId",
                        column: x => x.ContentId,
                        principalSchema: "news",
                        principalTable: "content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_articles_AuthorId",
                schema: "news",
                table: "articles",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_articles_ContentId",
                schema: "news",
                table: "articles",
                column: "ContentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles",
                schema: "news");

            migrationBuilder.DropTable(
                name: "authors",
                schema: "news");

            migrationBuilder.DropTable(
                name: "content",
                schema: "news");
        }
    }
}
