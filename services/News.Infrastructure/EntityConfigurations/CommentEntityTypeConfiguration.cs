using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Domain.Entities.ArticleAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace News.Infrastructure.EntityConfigurations
{
    class CommentEntityTypeConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("comment", NewsContext.DEFAULT_SCHEMA);

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseSqlServerIdentityColumn();

            builder.Property(a => a.Content)
                .IsRequired(true)
                .HasMaxLength(1000);
        }
    }
}
