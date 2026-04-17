using Bookslo2026.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Data.Configurations
{
    public class BookEntityTypeConfiguration:IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.Title).IsRequired().HasMaxLength(50);
            builder.Property(b=>b.AuthorId).IsRequired();
            builder.Property(b => b.PublisherId).IsRequired();
            builder.Property(b => b.PublishedDate).IsRequired();
            builder.Property(b => b.Price).IsRequired().HasColumnType("decimal(18,2)");
            //builder.Property(b => b.IsActive).IsRequired();
        }
    }
}
