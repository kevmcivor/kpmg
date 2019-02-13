using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Domain.Entities.ArticleAggregate;

namespace News.Infrastructure.EntityConfigurations
{
    class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("authors", NewsContext.DEFAULT_SCHEMA);

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasMaxLength(450);

            builder.Property(a => a.Name)
                .IsRequired(true)
                .HasMaxLength(100);
        }
    }
}
