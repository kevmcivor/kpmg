using Microsoft.EntityFrameworkCore;
using News.Domain.Entities.ArticleAggregate;
using News.Infrastructure.EntityConfigurations;
using System;

namespace News.Infrastructure
{
    public class NewsContext : DbContext
    {
        public NewsContext()
        {
        }

        public NewsContext(DbContextOptions<NewsContext> options) : base(options) { }

        public const string DEFAULT_SCHEMA = "news";
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=PressfordConsulting;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ArticleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CommentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RatingEntityTypeConfiguration());
        }
    }
}
