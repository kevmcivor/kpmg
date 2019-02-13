using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Domain.Entities.ArticleAggregate;

namespace News.Infrastructure.EntityConfigurations
{
    class ContentEntityTypeConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.ToTable("content", NewsContext.DEFAULT_SCHEMA);

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Title)
                .IsRequired(true)
                .HasMaxLength(1000);

            builder.Property(a => a.Headline)
                .IsRequired(false)
                .HasMaxLength(1000);

            builder.Property(a => a.Body)
                .IsRequired(true)
                .HasColumnType("nvarchar(max)");

            builder.Property(a => a.ImageUri)
                .IsRequired(true)
                .HasMaxLength(100);
        }
    }
}
