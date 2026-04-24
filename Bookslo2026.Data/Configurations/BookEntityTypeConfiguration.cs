using Bookslo2026.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookslo2026.Data.Configurations
{
    public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.Title)
             .IsRequired()
             .HasMaxLength(200);

            builder.Property(b => b.Price)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(b => b.PublishedDate)
                .IsRequired();

            builder.Property(b => b.IsActive)
                .IsRequired();

            builder.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(b => b.Title);

            builder.HasIndex(b => new { b.Title, b.AuthorId })
                .IsUnique();

            builder.HasData(
                new Book
                {
                    BookId = 1,
                    Title = "Foundation",
                    AuthorId = 1,
                    PublisherId = 1,
                    PublishedDate = new DateTime(1951, 1, 1),
                    Price = 15000,
                    IsActive = true
                },
                new Book
                {
                    BookId = 2,
                    Title = "Dune",
                    AuthorId = 2,
                    PublisherId = 2,
                    PublishedDate = new DateTime(1965, 1, 1),
                    Price = 18000,
                    IsActive = true
                },
                new Book
                {
                    BookId = 3,
                    Title = "2001: A Space Odyssey",
                    AuthorId = 3,
                    PublisherId = 3,
                    PublishedDate = new DateTime(1968, 1, 1),
                    Price = 17000,
                    IsActive = true
                },
                new Book
                {
                    BookId = 4,
                    Title = "Do Androids Dream of Electric Sheep?",
                    AuthorId = 4,
                    PublisherId = 4,
                    PublishedDate = new DateTime(1968, 1, 1),
                    Price = 16000,
                    IsActive = true
                },
                new Book
                {
                    BookId = 5,
                    Title = "Fahrenheit 451",
                    AuthorId = 1,
                    PublisherId = 1,
                    PublishedDate = new DateTime(1953, 1, 1),
                    Price = 14000,
                    IsActive = true
                }
            );
        }
    }
}
