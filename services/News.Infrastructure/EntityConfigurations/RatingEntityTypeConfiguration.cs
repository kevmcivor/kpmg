using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Domain.Entities.ArticleAggregate;

namespace News.Infrastructure.EntityConfigurations
{
    class RatingEntityTypeConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("rating", NewsContext.DEFAULT_SCHEMA);

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .UseSqlServerIdentityColumn();

            builder.Property(a => a.Rate)
                .IsRequired(true);
        }
    }
}
