using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Domain.Entities.ArticleAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace News.Infrastructure.EntityConfigurations
{
    class ArticleEntityTypeConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("articles", NewsContext.DEFAULT_SCHEMA);

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseSqlServerIdentityColumn();
            builder.Property(a => a.PublicationDate).IsRequired(true);
        }
    }
}
